using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoaNet.HttpHelper
{
    /// <summary>
    /// A class that helps calling REST Api's
    /// </summary>
    public class HttpServiceRequest
    {
        public static async Task<T> RequestServiceAsync<T>(string url, HttpMethod method, object requestData)
        {
            HttpClient client = new HttpClient();
            if (method == HttpMethod.Get)
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var stringResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            else if (method == HttpMethod.Post)
            {
                var serializedObject = JsonConvert.SerializeObject(requestData);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(serializedObject, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            else if (method == HttpMethod.Put)
            {
                var serializedObject = JsonConvert.SerializeObject(requestData);
                HttpResponseMessage response = await client.PutAsync(url, new StringContent(serializedObject, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            else if (method == HttpMethod.Delete)
            {
                var serializedObject = JsonConvert.SerializeObject(requestData);
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            else
            {
                return await Task.FromResult((T)(object)null);
            }
        }
    }
}
