using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet
{
    public class Process
    {
        public Process(ProcessBuilder builder)
        {
            Steps = builder.Steps;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public IList<IStepProtocol> Steps { get; private set; }


        public void SetStart()
        {
            Start = DateTime.Now;
        }

        public void SetEnd()
        {
            End = DateTime.Now;
        }

        public void Run()
        {
            SetStart();

            foreach (var step in Steps)
            {
                step.ExecuteStep();
            }

            SetEnd();
        }
    }
}
