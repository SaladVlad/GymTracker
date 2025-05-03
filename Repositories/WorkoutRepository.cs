using GymTrackerAPI.Data;
using GymTrackerAPI.DTOs.Workouts;
using GymTrackerAPI.Models;
using GymTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _context;
        public WorkoutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateWorkoutAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }

        public async Task<UserWorkoutsResponseDto?> GetAllUserWorkoutsAsync(Guid userId)
        {
            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId)
                .Select(w => new GetWorkoutResponseDto
                {
                    Id = w.Id,
                    Type = w.Type.ToString(),
                    DurationMinutes = w.DurationMinutes,
                    CaloriesBurned = w.CaloriesBurned,
                    Intensity = w.Intensity,
                    Fatigue = w.Fatigue,
                    Notes = w.Notes,
                    PerformedAt = w.PerformedAt
                }).OrderByDescending(w => w.PerformedAt)
                .ToListAsync();

            return new UserWorkoutsResponseDto
            {
                Workouts = workouts
            };
        }

        public async Task<UserWorkoutsResponseDto?> GetWorkoutsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate)
        {
            var workouts = await _context.Workouts
            .Where(w => w.UserId == userId && w.PerformedAt >= startDate && w.PerformedAt <= endDate)
            .Select(w => new GetWorkoutResponseDto
            {
                Id = w.Id,
                Type = w.Type.ToString(),
                DurationMinutes = w.DurationMinutes,
                CaloriesBurned = w.CaloriesBurned,
                Intensity = w.Intensity,
                Fatigue = w.Fatigue,
                Notes = w.Notes,
                PerformedAt = w.PerformedAt
            })
            .OrderBy(w => w.PerformedAt)
            .ToListAsync();

            return new UserWorkoutsResponseDto
            {
                Workouts = workouts
            };
        }
    }
}
