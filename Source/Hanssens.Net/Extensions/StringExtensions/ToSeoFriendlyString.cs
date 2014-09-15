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
		/// <remarks>
		/// Supported characters are: 
		/// - letters (a-z), in both uppercase as well as lowercase
		/// - numbers (0-9)
		/// </remarks>
		public static string ToSeoFriendlyString(this string input)
		{
			// strip all non-supported characters
			var stripped = Regex.Replace(input, @"[^A-Za-z0-9]+", "-")
				.ToLowerInvariant();

			// make sure the string doesn't start or end with a hyphin/dash,
			// whilst also trimming it from spaces
			var trimmed = Regex.Replace (stripped, @"(^-+)|(-+$)", string.Empty).Trim(); 

			return trimmed;
		}
	}
}

