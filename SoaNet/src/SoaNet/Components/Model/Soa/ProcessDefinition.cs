using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class ProcessDefinition
    {
        public ProcessDefinition()
        {
            ProcessDefinitionId = Guid.NewGuid();
        }

        public Guid ProcessDefinitionId { get; set; }
        public string ProcessDefinitionName { get; set; }
    }
}
