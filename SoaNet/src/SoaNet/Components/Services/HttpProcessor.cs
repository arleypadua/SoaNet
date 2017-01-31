using SoaNet.Components.Model.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoaNet.Components.Services
{
    public class HttpProcessor
    {
        public static HttpSoaResponse Request(HttpSoaRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (var header in request.HttpSoaRequestHeaders)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                HttpResponseMessage response = null;

                if (request.Method == HttpMethod.Get.Method)
                {
                    var encodedUrl = WebUtility.UrlEncode(request.RequestUrl);
                    var resultTask = client.GetAsync(encodedUrl);
                    resultTask.Wait();
                    response = resultTask.Result;
                }
                else if (request.Method == HttpMethod.Post.Method)
                {
                    HttpContent content = new StringContent(request.RequestBody, System.Text.Encoding.UTF8);

                    var encodedUrl = WebUtility.UrlEncode(request.RequestUrl);
                    var resultTask = client.PostAsync(encodedUrl, content);
                    resultTask.Wait();
                    response = resultTask.Result;
                }
                else if (request.Method == HttpMethod.Put.Method)
                {
                    HttpContent content = new StringContent(request.RequestBody, System.Text.Encoding.UTF8);

                    var encodedUrl = WebUtility.UrlEncode(request.RequestUrl);
                    var resultTask = client.PutAsync(encodedUrl, content);
                    resultTask.Wait();
                    response = resultTask.Result;
                }
                else if (request.Method == HttpMethod.Delete.Method)
                {
                    var encodedUrl = WebUtility.UrlEncode(request.RequestUrl);
                    var resultTask = client.DeleteAsync(encodedUrl);
                    resultTask.Wait();
                    response = resultTask.Result;
                }

                if (response == null)
                    return new HttpSoaResponse { ResponseBody = string.Empty, StatusCode = -1, HttpSoaRequest = request };

                var responseObj = new HttpSoaResponse()
                {
                    HttpSoaRequest = request,
                    StatusCode = (int)response.StatusCode
                };
                responseObj.HttpSoaResponseHeaders = response.Headers.Select(h =>
                    new HttpSoaResponseHeader
                    {
                        HttpSoaResponseId = responseObj.HttpSoaResponseId,
                        Key = h.Key,
                        Value = string.Join(string.Empty, h.Value)
                    }).ToList();

                return responseObj;
            }
        }
    }
}
