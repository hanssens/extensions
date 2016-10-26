using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Replaces an entry in an editable collection (IList).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// Original concept by Ruslan L. (http://stackoverflow.com/questions/17188966/how-to-replace-list-item-in-best-way/38728879#387288790
        /// </remarks>
        public static int Replace<T>(this IList<T> source, T oldValue, T newValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var index = source.IndexOf(oldValue);
            if (index >= 0)
                source[index] = newValue;

            return index;
        }

        /// <summary>
        /// Returns the provided collection with the old and new value replaced.
        /// </summary>
        /// <remarks>
        /// Original concept by Ruslan L. (http://stackoverflow.com/questions/17188966/how-to-replace-list-item-in-best-way/38728879#387288790
        /// </remarks>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, T oldValue, T newValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.Select(x => EqualityComparer<T>.Default.Equals(x, oldValue) ? newValue : x);
        }
    }
}
