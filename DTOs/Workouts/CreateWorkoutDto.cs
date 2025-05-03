namespace GymTrackerAPI.DTOs.Workouts
{
    public class CreateWorkoutDto
    {
        public required string Type { get; set; }
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public int Intensity { get; set; } // 1–10
        public int Fatigue { get; set; }   // 1–10
        public string? Notes { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}
