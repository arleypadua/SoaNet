using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Http
{
    public class HttpSoaResponseHeader : HttpSoaHeader
    {
        public HttpSoaResponseHeader()
        {
            HttpSoaResponseHeaderId = Guid.NewGuid();
        }

        public Guid HttpSoaResponseHeaderId { get; set; }
        public Guid HttpSoaResponseId { get; set; }

        public virtual HttpSoaResponse HttpSoaResponse { get; set; }
    }
}
