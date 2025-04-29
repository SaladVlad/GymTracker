using GymTrackerAPI.DTOs.Workouts;
using GymTrackerAPI.Models;
using GymTrackerAPI.Repositories.Interfaces;
using GymTrackerAPI.Services.Interfaces;
using GymTrackerAPI.Utils;

namespace GymTrackerAPI.Services
{
    public class WorkoutService : IWorkoutService
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

        public async Task<List<WeeklyProgressDto>> GetAllWeeksProgressFromMonthAsync(Guid userId, int year, int month)
        {
            var weeks = DateHelper.GetLogicalWeeksInMonth(year, month);
            var result = new List<WeeklyProgressDto>();

            foreach (var (range, index) in weeks.Select((range, index) => (range, index)))
            {
                var workouts = await _workoutRepo.GetWorkoutsByDateRangeAsync(userId, range.Start, range.End);

                var weekStats = new WeeklyProgressDto
                {
                    WeekIndex = index,
                    StartDate = range.Start,
                    EndDate = range.End,
                    TotalDuration = workouts.Workouts.Sum(w => w.DurationMinutes),
                    WorkoutCount = workouts.Workouts.Count,
                    AvgIntensity = workouts.Workouts.Any() ? Math.Round(workouts.Workouts.Average(w => w.Intensity), 2) : 0,
                    AvgFatigue = workouts.Workouts.Any() ? Math.Round(workouts.Workouts.Average(w => w.Fatigue), 2) : 0
                };

                result.Add(weekStats);
            }

            return result;
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
