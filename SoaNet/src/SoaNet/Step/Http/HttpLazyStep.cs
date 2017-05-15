using SoaNet.Step.Dynamics;
using System;
using System.Net.Http;

namespace SoaNet.Step.Http
{
    /// <summary>
    /// A class that represents a step that hava a lazy loaded request data
    /// </summary>
    public class HttpLazyStep : DynamicStep
    {
        public HttpLazyStep(string url, HttpMethod method, Func<object> lazyData)
        {
            Url = url;
            Method = method;
            RequestLazyData = lazyData;
        }
        
        public string Url { get; private set; }
        public HttpMethod Method { get; private set; }
        public Func<object> RequestLazyData { get; private set; }

        protected override void Execute()
        {
            var lazyData = RequestLazyData();
            var result = HttpHelper.HttpServiceRequest.RequestServiceAsync<dynamic>(Url, Method, lazyData).Result;
            Result = new DynamicStepResult(result);
        }
    }
}
