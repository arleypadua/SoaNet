using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoaNet.HttpHelper
{
    public class HttpServiceRequest
    {
        public static async Task<T> RequestService<T>(string url, string method, object requestData)
        {
            HttpClient client = new HttpClient();
            if (method == "GET")
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var stringResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            else if (method == "POST")
            {
                var serializedObject = JsonConvert.SerializeObject(requestData);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(serializedObject, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            else if (method == "PUT")
            {
                var serializedObject = JsonConvert.SerializeObject(requestData);
                HttpResponseMessage response = await client.PutAsync(url, new StringContent(serializedObject, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
            else if (method == "DELETE")
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
