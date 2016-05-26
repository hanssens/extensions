using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace Hanssens.Net.IO
{
    /// <summary>
    /// Provides access to a set of wrappers that allow simple execution of (JSON) web requests.
    /// </summary>
    /// <remarks>
    /// Besides being a simple utility belt for quickly calling external JSON webservices, this also
    /// conforms to RFC4627 (setting the 'accept' type) and RFC2616 10.4.12 (setting the 'content-length').
    /// </remarks>
    public static class JsonRequest
    {
        /// <summary>
        /// Executes a JSON webrequest, using DELETE, and returns the raw JSON response as string.
        /// </summary>
        /// <param name="requestUri">The full request URI / endpoint to call.</param>
        /// <param name="args">[Optional]Any given object which will be serialized to JSON and included as message body</param>
        /// <param name="headers">[Optional] Provide custom headers that will be appended to the available header collection</param>
        public static JsonResponse Delete(string requestUri, object args = null,
            Dictionary<string, string> headers = null)
        {
            var response = _Execute(requestUri, "DELETE", args, headers);
            return response;
        }

        /// <summary>
        /// Executes a JSON webrequest, using GET, and returns the raw JSON response as string.
        /// </summary>
        /// <param name="requestUri">The full request URI / endpoint to call.</param>
        /// <param name="headers">[Optional] Provide custom headers that will be appended to the available header collection</param>
        public static JsonResponse Get(string requestUri, Dictionary<string, string> headers = null)
        {
            var response = _Execute(requestUri, "GET", args: null, headers: headers);
            return response;
        }

        /// <summary>
        /// Executes a JSON webrequest, using POST, and returns the raw JSON response as string.
        /// </summary>
        /// <param name="requestUri">The full request URI / endpoint to call.</param>
        /// <param name="args">[Optional]Any given object which will be serialized to JSON and included as message body</param>
        /// <param name="headers">[Optional] Provide custom headers that will be appended to the available header collection</param>
        public static JsonResponse Post(string requestUri, object args = null, Dictionary<string, string> headers = null)
        {
            var response = _Execute(requestUri, "POST", args, headers);
            return response;
        }

        /// <summary>
        /// Executes a JSON webrequest, using PUT, and returns the raw JSON response as string.
        /// </summary>
        /// <param name="requestUri">The full request URI / endpoint to call.</param>
        /// <param name="args">[Optional]Any given object which will be serialized to JSON and included as message body</param>
        /// <param name="headers">[Optional] Provide custom headers that will be appended to the available header collection</param>
        public static JsonResponse Put(string requestUri, object args = null, Dictionary<string, string> headers = null)
        {
            var response = _Execute(requestUri, "PUT", args, headers);
            return response;
        }

        private static JsonResponse _Execute(string requestUri, string httpMethod)
        {
            return _Execute(requestUri, httpMethod, args: null, headers: null);
        }

        private static JsonResponse _Execute(string requestUri, string httpMethod, object args,
            Dictionary<string, string> headers = null)
        {
            // prepare the request for a specific json call
            var request = (HttpWebRequest) WebRequest.Create(requestUri);
            request.Accept = "application/json";

            // define the method, e.g. GET, POST, PUT etc.
            request.Method = httpMethod;

            // define the content length, as per RFC2616 10.4.12:
            //   The server refuses to accept the request without a defined Content-
            //   Length. The client MAY repeat the request if it adds a valid
            //   Content-Length header field containing the length of the message-body
            //   in the request message.
            // now, by default we're setting it to '0' and later on, only if there are indeed
            // arguments (e.g. a message body) provided, the actual size will be calculated
            request.ContentLength = 0;

            // some APIs want you to supply the appropriate "Accept" header 
            // in the request to get the wanted response type.
            // For example if an API can return data in XML and JSON and you 
            // want the JSON result, you would need to set the HttpWebRequest.Accept 
            // property to "application/json". See also: http://stackoverflow.com/a/5197548/1039247
            // Also, specs at RFC4627: http://www.ietf.org/rfc/rfc4627.txt
            request.ContentType = "application/json; charset=utf-8";

            if (headers != null && headers.Any())
            {
                // if provided, append the custom headers to the header collection
                // note that replacing them, for examply by initializing a new WebHeaderCollection,
                // will kill all previously set headers (see also https://github.com/hanssens/extensions/issues/19)
                foreach (var h in headers)
                    request.Headers.Add(h.Key, h.Value);
            }

            // determine if there are any arguments provided, which needs to be serialized to json and
            // embedded into the request body, before we actually start asking for a response
            if (args != null)
            {
                // serialize the arguments to json
                var jsonSerializedArguments = JsonConvert.SerializeObject(args);

                // remember we said all that stuff about ContentLength earlier in this function? Well,
                // if there is a content body, calculate its length here
                var contentLengthBytes = System.Text.Encoding.UTF8.GetBytes(jsonSerializedArguments);
                request.ContentLength = contentLengthBytes.Length;

                // ... and bake them into the request
                using (var requestStream = new StreamWriter(request.GetRequestStream()))
                {
                    requestStream.Write(jsonSerializedArguments);
                    requestStream.Flush();
                    requestStream.Close();
                }
            }

            var returnValue = new JsonResponse();

            // before the actual call is made to the remote server,
            // make sure we persist the request that we're sending
            returnValue.RawRequest = JsonConvert.SerializeObject(request, Formatting.Indented);

            // initialize a stopwatch, to start counting the duration
            var stopwatch = Stopwatch.StartNew();

            try
            {
                using (var client = new HttpClient())
                {

                }
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        // set the 'value'
                        returnValue.Value = reader.ReadToEnd();

                        // persist the success response from the remote service
                        returnValue.RawResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
                        returnValue.StatusCode = response.StatusCode;

                        // indicate that the operation was a success
                        returnValue.Success = true;
                    }
                }
            }
            catch (WebException ex)
            {
                returnValue.Exception = ex;
                returnValue.ErrorMessage = ex.Message;

                // although the call wasn't a success, the remote service still returned a response
                returnValue.RawResponse = JsonConvert.SerializeObject(ex.Response, Formatting.Indented);
                returnValue.StatusCode = ((HttpWebResponse) ex.Response).StatusCode;
            }
            catch (Exception ex)
            {
                returnValue.Exception = ex;
                returnValue.ErrorMessage = ex.ToString();
            }
            finally
            {
                // stop the clock
                stopwatch.Stop();
                returnValue.Duration = stopwatch.ElapsedMilliseconds;
            }

            return returnValue;
        }

    }
}