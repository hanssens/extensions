using System;

namespace Hanssens.Net.Converters
{
    public static partial class UnitConverter
    {
        /// <summary>
        /// 1 kilometer = 0.621371192 miles
        /// </summary>
        public const double AmountOfKilometersInMile = 1.609344;

        /// <summary>
        /// 1 mile = 1.609344 kilometers
        /// </summary>
        public const double AmountOfMilesInKilometer = 0.621371192;

        /// <summary>
        /// Converts the provided amount of kilometers to miles.
        /// </summary>
        /// <returns>The amount of miles.</returns>
        public static double KilometersToMiles(double kilometers)
        {
            return kilometers * AmountOfKilometersInMile;
        }

        /// <summary>
        /// Converts the provided amount of miles to kilometers.
        /// </summary>
        /// <returns>The amount of kilometers.</returns>
        public static double MilesToKilometers(double miles)
        {
            return miles * AmountOfMilesInKilometer;
        }
    }
}
