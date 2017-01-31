using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Model.Soa
{
    public class ProcessStep
    {
        public ProcessStep()
        {
            ProcessStepId = Guid.NewGuid();
        }

        public Guid ProcessStepId { get; set; }
        public Guid ProcessId { get; set; }
        public Guid ProcessStepStatusId { get; set; }
        public Guid StepDefinitionId { get; set; }
        public bool IsProcessed { get; set; }

        public DateTime InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }

        public virtual Process Process { get; set; }
        public virtual ProcessStepStatus ProcessStepStatus { get; set; }
        public virtual StepDefinition StepDefinition { get; set; }
    }
}
