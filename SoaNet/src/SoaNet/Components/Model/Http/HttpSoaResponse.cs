using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Http
{
    public class HttpSoaResponse
    {
        public HttpSoaResponse()
        {
            HttpSoaResponseId = Guid.NewGuid();
        }

        public Guid HttpSoaResponseId { get; set; }
        public Guid HttpSoaRequestId { get; set; }
        public string ResponseBody { get; set; }
        public int StatusCode { get; set; }

        public virtual HttpSoaRequest HttpSoaRequest { get; set; }
        public virtual ICollection<HttpSoaResponseHeader> HttpSoaResponseHeaders { get; set; }
    }
}
