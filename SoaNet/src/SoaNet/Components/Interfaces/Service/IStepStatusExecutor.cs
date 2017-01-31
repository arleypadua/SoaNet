using SoaNet.Components.Model.Soa;
using SoaNet.Components.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Interfaces.Service
{
    public interface IStepStatusExecutor
    {
        IEnumerable<ProcessStep> GetProcessSteps();
        ExecuteStepResult ExecuteStep(ProcessStep step);

        ProcessStepStatus ThisStatus { get; }
    }
}
