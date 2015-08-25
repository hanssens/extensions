using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.IO
{
    public class XmlResponse
    {
        /// <summary>
        /// Indicates if the XmlRequest operation succeeded.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Duration of the request, in milliseconds.
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// Actual response returned from the service.
        /// </summary>
        public string Response { get; set; }
    }
}
