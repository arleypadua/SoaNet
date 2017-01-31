using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Http
{
    public class HttpSoaRequestHeader : HttpSoaHeader
    {
        public HttpSoaRequestHeader()
        {
            HttpSoaRequestHeaderId = Guid.NewGuid();
        }

        public Guid HttpSoaRequestHeaderId { get; set; }
        public Guid HttpSoaRequestId { get; set; }
        
        public virtual HttpSoaRequest HttpSoaRequest { get; set; }
    }
}
