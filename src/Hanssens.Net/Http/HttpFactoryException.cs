using System;

namespace Hanssens.Net.Http
{
    /// <summary>
    /// Represents errors that occur when executing http requests through the HttpFactory utility class.
    /// </summary>
    public class HttpFactoryException : Exception
    {
        public HttpFactoryException() : base() { }
        public HttpFactoryException(string message) : base(message) { }
        public HttpFactoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}