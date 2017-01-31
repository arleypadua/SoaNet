using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Http
{
    public class HttpSoaRequest
    {
        public HttpSoaRequest()
        {
            HttpSoaRequestId = Guid.NewGuid();
        }

        public Guid HttpSoaRequestId { get; set; }
        public string RequestUrl { get; set; }
        public string Method { get; set; }
        public string RequestBody { get; set; }

        public virtual ICollection<HttpSoaRequestHeader> HttpSoaRequestHeaders { get; set; }
    }
}
