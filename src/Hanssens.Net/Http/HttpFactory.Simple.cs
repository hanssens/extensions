using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
