using Newtonsoft.Json;
using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace SoaNet.Step
{
    public class StepResult
    {
        public StepResult(dynamic data)
        {
            this.data = data;
        }

        private dynamic data;
        public dynamic Data
        {
            get
            {
                return data;
            }
        }
    }
}
