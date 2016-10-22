using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    public static class RandomizerExtensions
    {
        /// <summary>
        /// Fetches a random value from a collection.
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="list">Collection to fetch a random entry from</param>
        public static T Random<T>(this IEnumerable<T> list)
        {
            var returnValue = default(T);

            using (var randomizer = new Randomizer())
                returnValue = randomizer.Random(list);

            return returnValue;
        }
    }
}
