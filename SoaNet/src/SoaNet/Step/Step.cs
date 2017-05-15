using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step
{
    public abstract class Step : IStep
    {
        public Step()
        {
            Reference = Guid.NewGuid();
        }

        public Guid Reference { get; protected set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool StopProcessOnError { get; set; }
        public bool HasExecutionError { get; set; }

        public event OnStartStepDelegate OnStart;
        public event OnSuccessStepDelegate OnSuccess;
        public event OnFailStepDelegate OnFail;
        public event OnFinishStepDelegate OnFinish;

        protected abstract void Execute();

        public void ExecuteStep()
        {
            try
            {
                SetStart();
                OnStart?.Invoke(Reference);

                Execute();
                OnSuccess?.Invoke(Reference, this);

                SetEnd();
            }
            catch (Exception e)
            {
                HasExecutionError = true;
                OnFail?.Invoke(Reference, e);
            }
            finally
            {
                OnFinish?.Invoke(Reference);
            }
        }

        public virtual bool ShouldStop()
        {
            return StopProcessOnError && HasExecutionError;
        }

        public void SetOptions(StepOptions options)
        {
            StopProcessOnError = options.StopProcessOnError;

            if (options.OnStart != null) OnStart += options.OnStart.Invoke;
            if (options.OnSuccess != null) OnSuccess += options.OnSuccess.Invoke;
            if (options.OnFail != null) OnFail += options.OnFail.Invoke;
            if (options.OnFinish != null) OnFinish += options.OnFinish.Invoke;
        }

        private void SetStart()
        {
            Start = DateTime.Now;
        }

        private void SetEnd()
        {
            End = DateTime.Now;
        }
    }

    public abstract class Step<TResult> : Step, IStep<TResult>
    {

        public IStepResult<TResult> Result { get; protected set; }
    }
}
