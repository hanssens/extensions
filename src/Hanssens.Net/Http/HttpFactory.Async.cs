﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hanssens.Net.Http
{
    public partial class HttpFactory
    {
        public async Task<HttpResponseMessage> DeleteAsync(string requestUri, Dictionary<string, string> headers = null)
        {
            // TODO: investigate the proper use of a 'body' in a DELETE operation
            // see also: http://stackoverflow.com/questions/299628/is-an-entity-body-allowed-for-an-http-delete-request
            return await Execute(HttpMethod.Delete, requestUri, body: string.Empty, headers: headers);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, Dictionary<string, string> headers = null)
        {
            return await Execute(HttpMethod.Get, requestUri, body: string.Empty, headers: headers);
        }

        public async Task<HttpResponseMessage> PatchAsync<T>(string requestUri, T body, Dictionary<string, string> headers = null)
        {
            return await Execute(new HttpMethod("PATCH"), requestUri, body, headers);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string requestUri, T body, Dictionary<string, string> headers = null)
        {
            return await Execute(HttpMethod.Post, requestUri, body, headers);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string requestUri, T body, Dictionary<string, string> headers = null)
        {
            return await Execute(HttpMethod.Put, requestUri, body, headers);
        }
    }
}
