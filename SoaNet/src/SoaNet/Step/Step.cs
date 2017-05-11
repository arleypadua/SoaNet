using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step
{
    public class Step : IStepProtocol
    {
        public Step(string url, string method, object data)
        {
            Reference = Guid.NewGuid();

            Url = url;
            Method = method;
            RequestData = data;
        }

        public Guid Reference { get; private set; }

        public StepResult Result { get; private set; }

        public string Url { get; private set; }
        public string Method { get; private set; }
        public object RequestData { get; private set; }

        public void ExecuteStep()
        {
            var result = HttpHelper.HttpServiceRequest.RequestService<object>(Url, Method, RequestData).Result;
            Result = new StepResult(result);

            return;
        }
    }
}
