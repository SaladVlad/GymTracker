using GymTrackerAPI.DTOs.Workouts;

namespace GymTrackerAPI.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<CreateWorkoutResponseDto?> CreateWorkoutAsync(Guid userId, CreateWorkoutDto dto);
        Task<UserWorkoutsResponseDto?> GetUserWorkoutsAsync(Guid userId);

        List<(DateTime Start, DateTime End)> GetLogicalWeeks(int year, int month);
        Task<UserWorkoutsResponseDto?> GetWorkoutsByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);

        Task<List<WeeklyProgressDto>> GetAllWeeksProgressFromMonthAsync(Guid userId, int year, int month);

    }
}
