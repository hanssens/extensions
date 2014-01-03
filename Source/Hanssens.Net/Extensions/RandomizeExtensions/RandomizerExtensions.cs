using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    public static class RandomizerExtensions
    {

        public static T Random<T>(this IEnumerable<T> list)
        {
            var returnValue = default(T);
            using (var randomizer = new Randomizer())
                returnValue = randomizer.Random(list);

            return returnValue;
        }
    }
}
