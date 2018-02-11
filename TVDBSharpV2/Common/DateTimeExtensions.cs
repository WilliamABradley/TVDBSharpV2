using System;

namespace TVDBSharp.Common
{
    /// <summary>
    /// Provides Date and Time extension methods.
    /// </summary>
    internal static class DateTimeExtensions
    {
        /// <summary>
        /// Converts Epoch time to DateTime.
        /// </summary>
        /// <param name="unixTime">Epoch Value for conversion</param>
        public static DateTimeOffset ToDateTime(this long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime);
        }

        /// <summary>
        /// Converts DateTime to Epoch time.
        /// </summary>
        /// <param name="date">Datetime for conversion</param>
        /// <returns>Epoch time</returns>
        public static long ToEpoch(this DateTime date)
        {
            DateTimeOffset offset = new DateTimeOffset(date);
            return offset.ToUnixTimeSeconds();
        }
    }
}