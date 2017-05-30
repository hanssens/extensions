using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hanssens.Net.Http
{
    public partial class HttpFactory
    {
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

            public static HttpResponseMessage Delete(string requestUri, Dictionary<string, string> headers = null)
            {
                return Factory.DeleteAsync(requestUri, headers).Result;
            }

            public static async Task<HttpResponseMessage> DeleteAsync(string requestUri, Dictionary<string, string> headers = null)
            {
                return await Factory.DeleteAsync(requestUri, headers);
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
            public static async Task<HttpResponseMessage> GetAsync(string requestUri, Dictionary<string, string> headers = null)
            {
                return await Factory.GetAsync(requestUri, headers);
            }

            public static HttpResponseMessage Patch<T>(string requestUri, T body) where T : class
            {
                return Factory.Patch(requestUri, body);
            }

            public static async Task<HttpResponseMessage> PatchAsync<T>(string requestUri, T body) where T : class
            {
                return await Factory.PatchAsync(requestUri, body);
            }

            public static HttpResponseMessage Post<T>(string requestUri, T body) where T : class
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
