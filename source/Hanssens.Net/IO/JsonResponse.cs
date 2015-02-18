using System;

namespace Hanssens.Net
{
	/// <summary>
	/// Json response.
	/// </summary>
	public class JsonResponse
	{
		/// <summary>
		/// Indicates if the actual web request succeeded, or not.
		/// </summary>
		/// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
		public bool Success { get; set; }

		/// <summary>
		/// In case of a (server) exception, the server response will be contained here.
		/// </summary>
		/// <value>The error message.</value>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// The raw server response as value.
		/// </summary>
		/// <value>The value.</value>
		public string Value { get; set; }
	}
}

