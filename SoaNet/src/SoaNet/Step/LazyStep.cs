using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step
{
    public class LazyStep : IStepProtocol
    {
        public LazyStep(string url, string method, Func<object> lazyData)
        {
            Reference = Guid.NewGuid();
            
            Url = url;
            Method = method;
            RequestLazyData = lazyData;
        }
        
        public Guid Reference { get; private set; }
        public StepResult Result { get; private set; }
        public string Url { get; private set; }
        public string Method { get; private set; }
        public Func<object> RequestLazyData { get; private set; }

        public void ExecuteStep()
        {
            var lazyData = RequestLazyData();
            var result = HttpHelper.HttpServiceRequest.RequestService<object>(Url, Method, lazyData).Result;
            Result = new StepResult(result);

            return;
        }
    }
}
