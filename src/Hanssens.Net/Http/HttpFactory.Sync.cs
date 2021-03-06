﻿using System.Collections.Generic;
using System.Net.Http;

namespace Hanssens.Net.Http
{
    public partial class HttpFactory
    {
        public HttpResponseMessage Delete(string requestUri, Dictionary<string, string> headers = null)
        {
            return DeleteAsync(requestUri, headers).Result;
        }

        public HttpResponseMessage Get(string requestUri, Dictionary<string, string> headers = null)
        {
            return GetAsync(requestUri, headers).Result;
        }

        public HttpResponseMessage Patch<T>(string requestUri, T body, Dictionary<string, string> headers = null)
        {
            return PatchAsync(requestUri, body: body, headers: headers).Result;
        }

        public HttpResponseMessage Post<T>(string requestUri, T body, Dictionary<string, string> headers = null)
        {
            return PostAsync(requestUri, body: body, headers: headers).Result;
        }

        public HttpResponseMessage Put<T>(string requestUri, T body, Dictionary<string, string> headers = null)
        {
            return PutAsync(requestUri, body: body, headers: headers).Result;
        }
    }
}
