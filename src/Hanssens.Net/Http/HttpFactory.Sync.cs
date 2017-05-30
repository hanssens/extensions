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
        public HttpResponseMessage Delete(string requestUri)
        {
            return DeleteAsync(requestUri).Result;
        }

        public HttpResponseMessage Get(string requestUri)
        {
            return GetAsync(requestUri).Result;
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
