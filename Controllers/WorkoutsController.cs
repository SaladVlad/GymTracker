using GymTrackerAPI.DTOs.Workouts;
using GymTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymTrackerAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutsController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateWorkoutResponseDto))]
        public async Task<IActionResult> CreateWorkout(CreateWorkoutDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _workoutService.CreateWorkoutAsync(userId, dto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserWorkoutsResponseDto))]
        public async Task<IActionResult> GetUserWorkouts()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var workouts = await _workoutService.GetUserWorkoutsAsync(userId);
            return Ok(workouts);
        }

        [HttpGet("weeks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WeekRangeDto>))]
        public IActionResult GetWeekRanges([FromQuery] int year, [FromQuery] int month)
        {
            var weekRanges = _workoutService.GetLogicalWeeks(year, month)
                .Select((w, i) => new WeekRangeDto
                {
                    Index = i,
                    Start = w.Start,
                    End = w.End
                })
                .ToList();

            return Ok(weekRanges);
        }

        [HttpGet("range")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserWorkoutsResponseDto))]
        public async Task<IActionResult> GetWorkoutsInRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var workouts = await _workoutService.GetWorkoutsByDateRangeAsync(userId, startDate, endDate);
            return Ok(workouts);
        }

        [HttpGet("progress/month")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WeeklyProgressDto>))]
        public async Task<IActionResult> GetMonthlyProgress([FromQuery] int year, [FromQuery] int month)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var progress = await _workoutService.GetAllWeeksProgressFromMonthAsync(userId, year, month);
            return Ok(progress);
        }


    }
}
