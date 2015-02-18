using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hanssens.Net.Extensions
{
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Indicates whether the specified collection is null or contains no elements.
		/// </summary>
		/// <returns>Only returns true if the collection if null or has no elements.</returns>
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) {
			if (collection == null) return true;
			//return false;
			return !collection.Any();
		}
	}
}

