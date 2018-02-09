using System;

namespace TVDBSharp.Common
{
    /// <summary>
    /// Provides Date and Time extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        public static DateTimeOffset ToDateTime(this long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime);
        }

        public static long ToEpoch(this DateTime date)
        {
            DateTimeOffset offset = new DateTimeOffset(date);
            return offset.ToUnixTimeSeconds();
        }
    }
}