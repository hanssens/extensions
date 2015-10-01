using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.Cryptography
{
    public static class Encode
    {
        /// <summary>
        /// Encodes a string using base64.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns>Returns a base64 encoded string.</returns>
        /// <remarks>Thanks to http://stackoverflow.com/a/11743162/1039247 </remarks>
        public static string Base64Encode(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) throw new ArgumentNullException(nameof(plainText));

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decodes a base64 string to 'plain text'.
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns>Returns the base64 decoded 'plain text'.</returns>
        /// <remarks>Thanks to http://stackoverflow.com/a/11743162/1039247 </remarks>
        public static string Base64Decode(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData)) throw new ArgumentNullException(nameof(base64EncodedData));

            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
