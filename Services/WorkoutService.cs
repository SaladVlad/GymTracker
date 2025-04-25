using GymTrackerAPI.DTOs.Workouts;
using GymTrackerAPI.Models;
using GymTrackerAPI.Repositories.Interfaces;
using GymTrackerAPI.Services.Interfaces;
using GymTrackerAPI.Utils;

namespace GymTrackerAPI.Services
{
    public class WorkoutService:IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepo;
        public WorkoutService(IWorkoutRepository workoutRepo)
        {
            _workoutRepo = workoutRepo;
        }

        public async Task<CreateWorkoutResponseDto?> CreateWorkoutAsync(Guid userId, CreateWorkoutDto dto)
        {
            var workout = new Workout
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = Enum.Parse<WorkoutType>(dto.Type, ignoreCase: true),
                DurationMinutes = dto.DurationMinutes,
                CaloriesBurned = dto.CaloriesBurned,
                Intensity = dto.Intensity,
                Fatigue = dto.Fatigue,
                Notes = dto.Notes,
                PerformedAt = dto.PerformedAt

            };

            await _workoutRepo.CreateWorkoutAsync(workout);

            return new CreateWorkoutResponseDto
            {
                Id = workout.Id,
                Type = workout.Type.ToString(),
                DurationMinutes = workout.DurationMinutes,
                CaloriesBurned = workout.CaloriesBurned,
                Intensity = workout.Intensity,
                Fatigue = workout.Fatigue,
                Notes = workout.Notes,
                PerformedAt = workout.PerformedAt
            };
        }

        public List<(DateTime Start, DateTime End)> GetLogicalWeeks(int year, int month)
        {
            return DateHelper.GetLogicalWeeksInMonth(year, month);
        }

        public async Task<UserWorkoutsResponseDto?> GetUserWorkoutsAsync(Guid userId)
        {
            return await _workoutRepo.GetAllUserWorkoutsAsync(userId);
        }

        public async Task<UserWorkoutsResponseDto?> GetWorkoutsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate)
        {
            return await _workoutRepo.GetWorkoutsByDateRangeAsync(userId, startDate, endDate);
        }
    }
}
