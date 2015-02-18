﻿using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Hanssens.Net.IO
{
	/// <summary>
	/// Provides access to a set of wrappers that allow simple execution of (JSON) web requests.
	/// </summary>
	public static class JsonRequest
	{
		/// <summary>
		/// Executes a JSON webrequest, using GET, and returns the raw JSON response as string.
		/// </summary>
		/// <param name="requestUri">The full request URI / endpoint to call.</param>
		/// <param name="args">[Optional]Any given object which will be serialized to JSON and included as message body</param>
		public static string Get(string requestUri, object args = null){

			var response = _Execute (requestUri, "GET", args);
			return response;
		}

		/// <summary>
		/// Executes a JSON webrequest, using POST, and returns the raw JSON response as string.
		/// </summary>
		/// <param name="requestUri">The full request URI / endpoint to call.</param>
		/// <param name="args">[Optional]Any given object which will be serialized to JSON and included as message body</param>
		public static string Post(string requestUri, object args = null){

			var response = _Execute (requestUri, "POST", args);
			return response;
		}
			
		private static string _Execute(string requestUri, string httpMethod) {
			return _Execute (requestUri, httpMethod, null);
		}

		private static string _Execute(string requestUri, string httpMethod, object args) {
		
			// prepare the request for a specific json call
			var request = (HttpWebRequest)WebRequest.Create(requestUri);
			request.Accept = "application/json";
			request.Method = httpMethod;

			// some APIs want you to supply the appropriate "Accept" header 
			// in the request to get the wanted response type.
			// For example if an API can return data in XML and JSON and you 
			// want the JSON result, you would need to set the HttpWebRequest.Accept 
			// property to "application/json". See also: http://stackoverflow.com/a/5197548/1039247
			// Also, specs at RFC4627: http://www.ietf.org/rfc/rfc4627.txt
			request.ContentType = "application/json; charset=utf-8";

			// determine if there are any arguments provided, which needs to be serialized to json and
			// embedded into the request body, before we actually start asking for a response
			if (args != null) {

				// serialize the arguments to json
				var jsonSerializedArguments = JsonConvert.SerializeObject(args);

				// ... and bake them into the request
				using (var requestStream = new StreamWriter (request.GetRequestStream ())) {
					requestStream.Write (jsonSerializedArguments);
					requestStream.Flush ();
					requestStream.Close ();
				}
			}

			var jsonResponse = string.Empty;

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					jsonResponse = reader.ReadToEnd();
				}
			}

			return jsonResponse;
		}
			
	}
}

