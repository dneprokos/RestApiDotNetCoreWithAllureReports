using System;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper
{
    public static class DateGenerator
    {
        public static string GetRandomDate(int startYear = 1960, string outputDateFormat = "yyyy-MM-dd")
        {
            DateTime start = new DateTime(startYear, 1, 1);
            var gen = new Random();
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString(outputDateFormat);
        }
    }
}
