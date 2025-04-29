namespace GymTrackerAPI.DTOs.Workouts
{
    public class WeeklyProgressDto
    {
        public int WeekIndex { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDuration { get; set; }
        public int WorkoutCount { get; set; }
        public double AvgIntensity { get; set; }
        public double AvgFatigue { get; set; }
    }
}
