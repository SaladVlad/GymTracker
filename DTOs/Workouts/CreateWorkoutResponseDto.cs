namespace GymTrackerAPI.DTOs.Workouts
{
    public class CreateWorkoutResponseDto
    {
        public Guid Id { get; set; }
        public required string Type { get; set; }
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public int Intensity { get; set; }
        public int Fatigue { get; set; }
        public string? Notes { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}
