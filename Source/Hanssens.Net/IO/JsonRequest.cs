using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Hanssens.Net.IO
{
	public static class JsonRequest
	{
		/// <summary>
		/// Executes a JSON webrequest, using GET, and returns the raw JSON response as string.
		/// </summary>
		public static string JsonGet(string requestUri){

			var json = string.Empty;

			// prepare the request for a specific json call
			var request = (HttpWebRequest)WebRequest.Create(requestUri);
			request.Accept = "application/json";
			request.Method = WebRequestMethods.Http.Get;

			// Some APIs want you to supply the appropriate "Accept" header 
			// in the request to get the wanted response type.
			// For example if an API can return data in XML and JSON and you 
			// want the JSON result, you would need to set the HttpWebRequest.Accept 
			// property to "application/json". See also: http://stackoverflow.com/a/5197548/1039247
			// Also, specs at RFC4627: http://www.ietf.org/rfc/rfc4627.txt
			request.ContentType = "application/json; charset=utf-8";

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				// parse
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					json = reader.ReadToEnd();
				}
			}

			return json;
		}
			
	}
}

