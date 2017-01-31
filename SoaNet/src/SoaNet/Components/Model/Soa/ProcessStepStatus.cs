using System;

namespace SoaNet.Components.Model.Soa
{
    public class ProcessStepStatus
    {
        public ProcessStepStatus()
        {
            ProcessStepStatusId = Guid.NewGuid();
        }

        public Guid ProcessStepStatusId { get; set; }
        public string Status { get; set; }
    }
}