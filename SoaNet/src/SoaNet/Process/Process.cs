using SoaNet.Step;
using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoaNet.Process
{
    public class Process
    {
        #region Constructors
        public Process(ProcessBuilder builder)
        {
            Reference = Guid.NewGuid();
            Steps = builder.Steps;
        }

        public Process(ProcessBuilder builder, string name)
        {
            Reference = Guid.NewGuid();
            Name = name;
            Steps = builder.Steps;
        }

        public Process(ProcessBuilder builder, Guid reference)
        {
            Reference = reference;
            Steps = builder.Steps;
        }

        public Process(ProcessBuilder builder, Guid reference, string name)
        {
            Reference = reference;
            Name = name;
            Steps = builder.Steps;
        }
        #endregion

        public Guid Reference { get; set; }
        public string Name { get; set; }
        public DateTime? Start { get; private set; }
        public DateTime? End { get; private set; }
        public IList<IStep> Steps { get; private set; }
        public bool IsStopped { get; set; }
        public DateTime? StopDate { get; set; }
        public bool IsFinished { get; set; }

        public bool HasErrors { get { return Steps.Any(s => s.HasExecutionError); } }
        public bool ShouldEnd { get { return Steps.Any(s => !s.ShouldStop()); } }


        private void SetStart()
        {
            Start = DateTime.Now;
        }

        private void SetEnd()
        {
            End = DateTime.Now;
            IsFinished = true;
        }

        public void Stop()
        {
            IsStopped = true;
            StopDate = DateTime.Now;
        }

        public void Run()
        {
            SetStart();

            foreach (var step in Steps)
            {
                step.ExecuteStep();

                if (step.ShouldStop())
                {
                    Stop();

                    break;
                }
            }

            if (ShouldEnd) SetEnd();
        }

        public void SetStepOptions(StepOptions options)
        {
            if (options == null) return;

            foreach (var step in Steps) step.SetOptions(options);
        }
    }
}
