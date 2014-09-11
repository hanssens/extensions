using System;
using System.Text.RegularExpressions;

namespace Hanssens.Net
{
	public static class ToSeoFriendlyStringExtensions
	{
		/// <summary>
		/// Returns a lowercase copy of the string, with non-compliant characters for a url stripped out.
		/// </summary>
		/// <returns>The seo friendly string.</returns>
		public static string ToSeoFriendlyString(this string input)
		{
			return Regex.Replace(input, @"[^A-Za-z0-9\.~]+", "-")
				.ToLowerInvariant();
		}
	}
}

