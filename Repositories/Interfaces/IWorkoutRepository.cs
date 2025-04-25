using GymTrackerAPI.DTOs.Workouts;
using GymTrackerAPI.Models;

namespace GymTrackerAPI.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        Task CreateWorkoutAsync(Workout workout);
        Task<UserWorkoutsResponseDto?> GetAllUserWorkoutsAsync(Guid userId);
        Task<UserWorkoutsResponseDto?> GetWorkoutsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);
    }
}
