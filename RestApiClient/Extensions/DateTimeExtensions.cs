using System;
using FluentAssertions;

namespace RestApiClient.Extensions
{
    public static class DateTimeExtensions
    {
        private const string AzoresStandardTimeId = "Azores Standard Time";

        public static DateTime ToAzoresStandardTime(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime,
                TimeZoneInfo.FindSystemTimeZoneById(AzoresStandardTimeId));
        }

        public static DateTime ToUtcAsAzoresStandardTime(this DateTime dateTime)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(AzoresStandardTimeId);
            DateTime utc = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToAzoresStandardTime(), tz);

            return utc;
        }

        public static DateTime TruncateMilliseconds(this DateTime original)
        {
            return original.AddTicks(-(original.Ticks % TimeSpan.TicksPerSecond));
        }

        public static DateTime TruncateMilliseconds(this DateTime? original)
        {
            original.Should().NotBeNull();
            return original!.Value.AddTicks(-(original.Value.Ticks % TimeSpan.TicksPerSecond));
        }
    }
}
