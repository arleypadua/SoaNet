using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class StepDefinition
    {
        public StepDefinition()
        {
            StepDefinitionId = Guid.NewGuid();
        }

        public Guid StepDefinitionId { get; set; }
        public string StepDefinitionName { get; set; }
        public string StepUrl { get; set; }
        public string StepMethod { get; set; }
    }
}
