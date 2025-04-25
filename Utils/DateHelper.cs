namespace GymTrackerAPI.Utils
{
    public static class DateHelper
    {
        public static List<(DateTime Start, DateTime End)> GetLogicalWeeksInMonth(int year, int month)
        {
            var result = new List<(DateTime Start, DateTime End)>();

            var firstDay = new DateTime(year, month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            var currentStart = firstDay;

            while (currentStart <= lastDay)
            {
                var currentEnd = currentStart.AddDays(6);
                if (currentEnd > lastDay)
                    currentEnd = lastDay;

                result.Add((currentStart, currentEnd));
                currentStart = currentEnd.AddDays(1);
            }

            return result;
        }


    }
}
