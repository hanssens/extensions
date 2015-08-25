using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.IO
{
    /// <summary>
    /// Provides access to a set of wrappers that allow simple execution of (XML) web requests.
    /// </summary>
    public class XmlRequest
    {
        public XmlResponse Create(string url, string data)
        {
            var response = new XmlResponse();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var request = System.Net.WebRequest.Create(url);
                request.ContentType = "text/xml";
                request.Method = "POST";

                var bytes = Encoding.ASCII.GetBytes(data);
                request.ContentLength = bytes.Length;

                using (var os = request.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                }

                using (var xmlResponse = request.GetResponse())
                {
                    using (var reader = new StreamReader(xmlResponse.GetResponseStream()))
                    {
                        response.Response = reader.ReadToEnd().Trim();
                        response.Success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Response = "Error: " + ex.Message;
            }
            finally
            {
                stopwatch.Stop();
                response.Duration = stopwatch.ElapsedMilliseconds;
            }

            return response;
        }
    }
}
