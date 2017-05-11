using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step.Interfaces
{
    public interface IStepProtocol
    {
        Guid Reference { get; }
        StepResult Result { get; }

        void ExecuteStep();
    }
}
