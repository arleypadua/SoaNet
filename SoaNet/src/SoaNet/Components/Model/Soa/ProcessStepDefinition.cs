using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class ProcessStepDefinition
    {
        public ProcessStepDefinition()
        {
            ProcessStepDefinitionId = Guid.NewGuid();
        }

        public Guid ProcessStepDefinitionId { get; set; }
        public Guid ThisStepDefinitionId { get; set; }
        public Guid NextStepDefinitionId { get; set; }
    }
}
