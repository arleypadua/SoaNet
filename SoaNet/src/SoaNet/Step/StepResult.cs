using Newtonsoft.Json;
using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace SoaNet.Step
{
    /// <summary>
    /// A class containing the step execution result
    /// </summary>
    public class StepResult<TResult> : IStepResult<TResult>
    {
        public StepResult()
        {
        }

        public StepResult(TResult data)
        {
            this.data = data;
        }

        private TResult data;

        public TResult Data
        {
            get
            {
                return data;
            }

            protected set
            {
                data = value;
            }
        }
    }
}
