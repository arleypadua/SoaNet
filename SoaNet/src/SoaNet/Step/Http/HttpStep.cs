using SoaNet.Step.Dynamics;
using System.Net.Http;

namespace SoaNet.Step.Http
{
    /// <summary>
    /// A class representing a step in a process
    /// </summary>
    public class HttpStep : DynamicStep
    {
        public HttpStep(string url, HttpMethod method, object data)
        {
            Url = url;
            Method = method;
            RequestData = data;
        }

        public string Url { get; private set; }
        public HttpMethod Method { get; private set; }
        public object RequestData { get; private set; }

        protected override void Execute()
        {
            var result = HttpHelper.HttpServiceRequest.RequestServiceAsync<dynamic>(Url, Method, RequestData).Result;
            Result = new DynamicStepResult(result);
        }
    }
}
