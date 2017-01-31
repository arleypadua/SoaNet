using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class ProcessData
    {
        public ProcessData()
        {
            ProcessDataId = Guid.NewGuid();
        }

        public Guid ProcessDataId { get; set; }
        public Guid ProcessId { get; set; }
        public Guid DataDefinitionId { get; set; }
        public string Value { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual Process Process { get; set; }
        public virtual DataDefinition DataDefinition { get; set; }
    }
}
