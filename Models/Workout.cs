namespace GymTrackerAPI.Models
{
    public class Workout
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public WorkoutType Type { get; set; }
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public int Intensity { get; set; }
        public int Fatigue { get; set; }
        public string? Notes { get; set; } = null;
        public DateTime PerformedAt { get; set; }
    }

    public enum WorkoutType
    {
        Cardio,
        Strength,
        Flexibility,
        Balance,
        Endurance,
        HIIT,
        CircuitTraining,
        Pilates,
        Yoga
    };
}
