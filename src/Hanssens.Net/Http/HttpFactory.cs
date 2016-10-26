using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hanssens.Net.Http
{
    /// <summary>
    /// Http utility, optimized for multiple http calls.
    /// </summary>
    public class HttpFactory : IDisposable
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

        public HttpResponseMessage Delete(string requestUri)
        {
            return DeleteAsync(requestUri).Result;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return await http.DeleteAsync(requestUri);
        }

        public HttpResponseMessage Get(string requestUri)
        {
            return GetAsync(requestUri).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await http.GetAsync(requestUri);
        }

        public HttpResponseMessage Post<T>(string requestUri, T body)
        {
            return PostAsync(requestUri, body).Result;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string requestUri, T body)
        {
            // TODO: determine type of body, to determine the correct content serializer
            // for now, default to StringContent
            var content = new StringContent(body.ToString());
            return await http.PostAsync(requestUri, content);
        }

        public HttpResponseMessage Put<T>(string requestUri, T body)
        {
            return PutAsync(requestUri, body).Result;
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string requestUri, T body)
        {
            // TODO: determine type of body, to determine the correct content serializer
            // for now, default to StringContent
            var content = new StringContent(body.ToString());
            return await http.PutAsync(requestUri, content);
        }

        public void Dispose()
        {
            if (self_disposable)
                http.Dispose();
        }

        /// <summary>
        /// Provides 'simple', shorthand functions intended for quickly making a single http call.
        /// </summary>
        public static class Simple
        {
            private static readonly HttpFactory Factory;

            static Simple()
            {
                Factory = new HttpFactory();
            }

            public static HttpResponseMessage Delete(string requestUri)
            {
                return Factory.DeleteAsync(requestUri).Result;
            }

            public static async Task<HttpResponseMessage> DeleteAsync(string requestUri)
            {
                return await Factory.DeleteAsync(requestUri);
            }

            /// <summary>
            /// Executes a single 'GET' request.
            /// </summary>
            /// <param name="requestUri">Endpoint to the remote resource</param>
            public static HttpResponseMessage Get(string requestUri)
            {
                return Factory.Get(requestUri);
            }

            /// <summary>
            /// Executes a single async 'GET' request.
            /// </summary>
            /// <param name="requestUri">Endpoint to the remote resource</param>
            public static async Task<HttpResponseMessage> GetAsync(string requestUri)
            {
                return await Factory.GetAsync(requestUri);
            }

            public static HttpResponseMessage Post<T>(string requestUri, T body) where T: class
            {
                return Factory.Post(requestUri, body);
            }

            public static async Task<HttpResponseMessage> PostAsync<T>(string requestUri, T body) where T : class
            {
                return await Factory.PostAsync(requestUri, body);
            }

            public static HttpResponseMessage Put<T>(string requestUri, T body) where T : class
            {
                return Factory.Put(requestUri, body);
            }

            public static async Task<HttpResponseMessage> PutAsync<T>(string requestUri, T body) where T : class
            {
                return await Factory.PutAsync(requestUri, body);
            }
        }
    }
}
