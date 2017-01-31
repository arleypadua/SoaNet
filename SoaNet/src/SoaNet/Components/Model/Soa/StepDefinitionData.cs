using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class StepDefinitionData
    {
        public StepDefinitionData()
        {
            StepDefinitionDataId = Guid.NewGuid();
        }

        public Guid StepDefinitionDataId { get; set; }
        public Guid StepDefinitionId { get; set; }
        public Guid DataDefinitionId { get; set; }

        public virtual StepDefinition StepDefinition { get; set; }
        public virtual DataDefinition DataDefinition { get; set; }
    }
}
