using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SoaNet.Step;
using SoaNet.Step.Dynamics;

namespace SoaNet.Process
{
    public class ProcessBuilder
    {
        public ProcessBuilder()
        {
            Steps = new List<IStep>();
        }

        public IList<IStep> Steps { get; set; }
        public StepOptions StepOptions { get; set; }

        public ProcessBuilder AddStep(IStep step)
        {
            Steps.Add(step);

            return this;
        }

        public ProcessBuilder AddAsyncSteps(params IStep[] steps)
        {
            Guid reference = Guid.Empty;
            return AddAsyncSteps(out reference, steps);
        }

        public ProcessBuilder AddAsyncSteps(out Guid reference, params IStep[] steps)
        {
            var asyncStep = new AsyncSteps(steps);
            reference = asyncStep.Reference;
            Steps.Add(asyncStep);

            return this;
        }

        /// <summary>
        /// Forces every step of the process to use the default options.
        /// Don't use this if you have steps with your own options.
        /// </summary>
        /// <returns></returns>
        public ProcessBuilder ForceUseDefaultStepOptions()
        {
            StepOptions = StepOptions.Default;
            return this;
        }

        public IStep GetStep(Guid reference)
        {
            return Steps.FirstOrDefault(s => s.Reference == reference);
        }

        public Process Build()
        {
            var process = new Process(this);
            process.SetStepOptions(StepOptions);

            return process;
        }

        public Process Build(Guid reference)
        {
            var process = new Process(this, reference);
            process.SetStepOptions(StepOptions);

            return process;
        }

        public Process Build(string name)
        {
            var process = new Process(this, name);
            process.SetStepOptions(StepOptions);

            return process;
        }

        public Process Build(Guid reference, string name)
        {
            var process = new Process(this, reference, name);
            process.SetStepOptions(StepOptions);

            return process;
        }
    }
}
