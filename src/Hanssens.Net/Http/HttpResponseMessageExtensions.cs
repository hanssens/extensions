using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.Http
{
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Extension allowing easy access to get the value from a HttpResponseMessage.
        /// </summary>
        public static string Value(this HttpResponseMessage httpResponse)
        {
            var response = httpResponse.Content.ReadAsStringAsync().Result;
            return response;
        }

        /// <summary>
        /// Extension allowing easy access to get the value from a HttpResponseMessage.
        /// </summary>
        public static async Task<string> ValueAsync(this HttpResponseMessage httpResponse)
        {
            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
