using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step.Dynamics
{
    public class DynamicStepResult : StepResult<dynamic>
    {
        public DynamicStepResult(dynamic data)
        {
            Data = data;
        }
    }
}
