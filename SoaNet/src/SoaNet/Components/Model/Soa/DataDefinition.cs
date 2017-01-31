using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class DataDefinition
    {
        public DataDefinition()
        {
            DataDefinitionId = Guid.NewGuid();
        }

        public Guid DataDefinitionId { get; set; }
        public string DataDefinitionName { get; set; }
        public bool IsHeaderData { get; set; }
    }
}
