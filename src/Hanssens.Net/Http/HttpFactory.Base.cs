using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hanssens.Net.Http
{
    /// <summary>
    /// Http utility, optimized for multiple http calls.
    /// </summary>
    public partial class HttpFactory : IDisposable
    {
        /// <summary>
        /// Single instance of the HttpClient.
        /// </summary>
        /// <remarks>
        /// There is a lot of debate about wh. 
        /// The choice in this part is that the HttpClient, even after disposing,
        /// will keep connections open for a certain amount of time. This is done
        /// at the OS-level, meaning that reusing existing HttpClients will benefit
        /// in terms of .
        /// TODO: add source
        /// </remarks>
        protected HttpClient http { get; private set; }

        /// <summary>
        /// Indicates if the factory should cleanup itself. Defaults to 'true',
        /// but is not disposed when an external httpclient is passed through the constructor.
        /// </summary>
        private bool self_disposable { get; set; } = true;

        /// <summary>
        /// Initializes a new instance of the HttpClient, which will self dispose.
        /// </summary>
        public HttpFactory()
        {
            http = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the HttpClient, with a reusable HttpClient.
        /// Using this overload, the provided HttpClient is not explicitely disposed when 
        /// the HttpFactory is disposed.
        /// </summary>
        /// <param name="httpClient"></param>
        public HttpFactory(HttpClient httpClient)
        {
            http = httpClient;
            self_disposable = false;
        }

        private async Task<HttpResponseMessage> Execute<T>(HttpMethod httpMethod, string requestUri, T body, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(httpMethod, requestUri);

            var contentLength = 0;

            if (body != null)
            {
                // serialize the request body to json
                var jsonSerializedArguments = JsonConvert.SerializeObject(body);

                // make sure the body has an actual value (and isn't just null or empty)
                var token = JToken.Parse(jsonSerializedArguments);
                if (token.HasValues)
                {
                    var contentLengthBytes = System.Text.Encoding.UTF8.GetBytes(jsonSerializedArguments);
                    contentLength = contentLengthBytes.Length;

                    // TODO: determine type of body, to determine the correct content serializer
                    request.Content = new StringContent(jsonSerializedArguments);
                }
                else
                {
                    // in case the body is empty, also set the content to empty
                    // this is required for content headers, which are set later on
                    request.Content = new StringContent("");
                }
            }

            try
            {
                // some APIs want you to supply the appropriate "Accept" header
                // in the request to get the wanted response type.
                // For example if an API can return data in XML and JSON and you
                // want the JSON result, you would need to set the HttpWebRequest.Accept
                // property to "application/json". See also: http://stackoverflow.com/a/5197548/1039247
                // Also, specs at RFC4627: http://www.ietf.org/rfc/rfc4627.txt
                //request.Content.Headers.Add("Content-Type", "application/json; charset=utf-8");
                //request.Headers.Add("Accept", "application/json");
                http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // by default, the content header 'content-type' may already be provided
                // in this case, reset it so we can make sure the appropriate header is set
                // incl. the charset. Having charset utf8 is OUR convention in this library.
                request.Content.Headers.Remove("Content-Type");
                request.Content.Headers.Add("Content-Type", "application/json; charset=utf-8");
                

                // define the content length, as per RFC2616 10.4.12:
                //   The server refuses to accept the request without a defined Content-
                //   Length. The client MAY repeat the request if it adds a valid
                //   Content-Length header field containing the length of the message-body
                //   in the request message.
                // now, by default we're setting it to '0' and later on, only if there are indeed
                // arguments (e.g. a message body) provided, the actual size will be calculated
                request.Content.Headers.Add("Content-Length", contentLength.ToString());

                // apply custom headers, if any are provided
                if (headers != null)
                {
                    foreach (var customHeader in headers)
                    {
                        // note: in the .net implementation of the HttpHeaders class there is a lot
                        // of stuff preventing your from simply "adding headers". basically, the
                        // implementation forces you to add ContentHeaders, AuthorizationHeaders etc.
                        // also, there is way too much validation on this, where a simple .Contains()
                        // triggers this validation as well and even throws InvalidOperationExceptions. 
                        // simply put, we are being stubborn and add the values anyhow, without
                        // meddling validation. more info:
                        // https://github.com/dotnet/corefx/blob/master/src/System.Net.Http/src/System/Net/Http/Headers/HttpHeaders.cs
                        request.Headers.TryAddWithoutValidation(customHeader.Key, customHeader.Value);
                    }
                }

                // execute the request
                return await http.SendAsync(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (self_disposable)
                http.Dispose();
        }

    }
}
