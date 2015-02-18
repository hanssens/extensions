using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hanssens.Net.Extensions
{
	public static class JsonExtensions
	{
		/// <summary>
		/// Determines if the provided raw json string is 'valid'.
		/// </summary>
		/// <returns><c>true</c> if it is valid json; otherwise, <c>false</c>.</returns>
		/// <param name="json">The raw json string to be validated.</param>
		public static bool IsValidJson(string json){
			try {
				var result = JContainer.Parse (json);
				if (result == null) throw new NullReferenceException();

				return true;
			} catch (JsonReaderException) {
				// the message could not be parsed
				return false;
			}
		}
	}
}

