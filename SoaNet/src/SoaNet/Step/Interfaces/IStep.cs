using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step.Interfaces
{
    public interface IStep
    {
        Guid Reference { get; }
        DateTime? Start { get; set; }
        DateTime? End { get; set; }
        bool StopProcessOnError { get; set; }
        bool HasExecutionError { get; set; }

        event OnStartStepDelegate OnStart;
        event OnSuccessStepDelegate OnSuccess;
        event OnFailStepDelegate OnFail;
        event OnFinishStepDelegate OnFinish;

        void ExecuteStep();
        bool ShouldStop();
        void SetOptions(StepOptions options);
    }

    public interface IStep<TResult> : IStep
    {
        IStepResult<TResult> Result { get; }
    }
}
