namespace GymTrackerAPI.Utils
{
    public static class DateHelper
    {
        public static List<(DateTime Start, DateTime End)> GetLogicalWeeksInMonth(int year, int month)
        {
            var result = new List<(DateTime Start, DateTime End)>();

            var firstOfMonth = DateTime.SpecifyKind(new DateTime(year, month, 1), DateTimeKind.Utc);
            var lastOfMonth = DateTime.SpecifyKind(firstOfMonth.AddMonths(1).AddDays(-1), DateTimeKind.Utc);

            var current = firstOfMonth;
            int diff = (7 + ((int)current.DayOfWeek - 1)) % 7; // Monday = 1
            current = current.AddDays(-diff);

            while (current <= lastOfMonth)
            {
                var weekStart = current;
                var weekEnd = current.AddDays(6);

                // Clamp inside the actual month
                var clampedStart = weekStart < firstOfMonth ? firstOfMonth : weekStart;
                var clampedEnd = weekEnd > lastOfMonth ? lastOfMonth : weekEnd;

                result.Add((clampedStart, clampedEnd));
                current = current.AddDays(7);
            }

            return result;
        }



    }
}
