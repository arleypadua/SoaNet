using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class Process
    {
        public Process()
        {
            ProcessId = Guid.NewGuid();
        }
        public Guid ProcessId { get; set; }
        public Guid ProcessDefinitionId { get; set; }
        public DateTime ProcessDate { get; set; }

        public virtual ProcessDefinition ProcessDefinition { get; set; }
    }
}
