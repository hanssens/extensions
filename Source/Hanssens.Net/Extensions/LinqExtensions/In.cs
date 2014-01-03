using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    /// <summary>
    /// Provides extensions for the System.Linq namespace.
    /// </summary>
    public static class InExtensions
    {
        /// <summary>
        /// Filters a collection by a list of parameters, equivalant to a 'WHERE IN' clause.
        /// </summary>
        /// <typeparam name="T">TypeOf IEnumerable source</typeparam>
        /// <param name="source">The source object</param>
        /// <param name="list">List to filter by</param>
        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }
    }
}
