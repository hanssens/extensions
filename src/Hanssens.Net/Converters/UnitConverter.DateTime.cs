using System;

namespace Hanssens.Net.Converters
{
    public static partial class UnitConverter
    {
        /// <summary>
        /// Epoch, or unix timestamp, starting date (1 Jan, 1970).
        /// </summary>
        public static readonly DateTime EpochStartDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts a unix epoch timestamp to a DateTime.
        /// </summary>
        /// <param name="epoch">Unix timestamp (a.k.a. POSIX, or Epoch)</param>
        /// <remarks>
        /// Unix time (also known as POSIX time or Epoch time) is a system for describing
        /// instants in time, defined as the number of seconds that have elapsed since
        /// 00:00:00 Coordinated Universal Time (UTC), Thursday, 1 January 1970.
        /// </remarks>
        public static DateTime ConvertFromUnixEpoch(double epoch)
        {
            return EpochStartDate.AddSeconds(epoch);
        }

        /// <summary>
        /// Converts a DateTime to a unix epoch timestamp.
        /// </summary>
        /// <remarks>
        /// The opposite operation can be used through UnitConverter.ConvertFromUnixEpoch().
        /// </remarks>
        public static double ToEpoch(this DateTime date)
        {
            return Convert.ToInt64((date - EpochStartDate).TotalSeconds);
        }
    }
}