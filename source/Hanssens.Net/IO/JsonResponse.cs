using System;

namespace Hanssens.Net.IO
{
	/// <summary>
	/// Json response.
	/// </summary>
	public class JsonResponse
	{
		/// <summary>
		/// The duration of the JsonRequest roundtrip call to the backend, in milliseconds.
		/// </summary>
		/// <value>The duration in ms.</value>
		/// <remarks>
		/// Note that the calculation tries to minimize the overhead of casting, validating etc.
		/// and only focusses on the actual roundtrip to the server (e.g. the request for response).
		/// </remarks>
		public long Duration { get; set; }

		/// <summary>
		/// In case of a (server) exception, the server response will be contained here.
		/// </summary>
		/// <value>The error message.</value>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Indicates if the actual web request succeeded, or not.
		/// </summary>
		/// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
		public bool Success { get; set; }

		/// <summary>
		/// The raw server response, when the operation is successfully executed.
		/// </summary>
		/// <value>The value.</value>
		public string Value { get; set; }

		/// <summary>
		/// JSON serialized representation of the actual request, incl. headers, that is sent to the remote service.
		/// </summary>
		public string RawRequest { get; set; }

		/// <summary>
		/// JSON serialized representation of the actual response, incl. headers, that is received to the remote service.
		/// </summary>
		public string RawResponse { get; set; }
	}
}

