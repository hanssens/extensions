namespace Hanssens.Net.Cryptography
{
    /// <summary>
    /// Helpers for encoding to and decoding from Base64 format.
    /// </summary>
    public static class Base64
    {
        /// <summary>
        /// Decodes the specified base64 string to plain text.
        /// </summary>
        /// <param name="base64EncodedData">Encoded base64 string.</param>
        public static string Decode(string base64EncodedData) {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Encodes the specifiek text to base64.
        /// </summary>
        /// <param name="plainText">Text to be encoded to base64.</param>
        public static string Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}