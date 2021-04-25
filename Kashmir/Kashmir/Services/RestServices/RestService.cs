using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Kashmir.Services.Basic.Abstracts;

namespace Kashmir.Services.RestServices
{
    public class RestService : APIBaseService, IRestService
    {
        public async Task<T> GetAsync<T>(string url) where T: new()
        {
            HttpClient client = base.GetClient();
            HttpResponseMessage httpResponse = await client.GetAsync(url);

            if (httpResponse.StatusCode >= HttpStatusCode.OK && httpResponse.StatusCode < HttpStatusCode.Ambiguous)
            {
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                T response = JsonConvert.DeserializeObject<T>(responseStr);
                return response;
            }
            else
            {
                await Helpers.Helpers.ServerExceptions(httpResponse);
                return default(T);
            }
        }

        public async Task<T> PostAsync<T>(string url, object data) where T: new()
        {
            HttpClient client = base.GetClient();

            string dataObjectStr = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(dataObjectStr, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PostAsync(url, stringContent);

            if (httpResponse.StatusCode >= HttpStatusCode.OK && httpResponse.StatusCode < HttpStatusCode.Ambiguous)
            {
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                T response = JsonConvert.DeserializeObject<T>(responseStr);
                return response;
            }
            else
            {
                await Helpers.Helpers.ServerExceptions(httpResponse);
                return default(T);
            }
        }

        public async Task<T> PutAsync<T>(string url, object data) where T: new()
        {
            HttpClient client = base.GetClient();

            string dataObjectStr = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(dataObjectStr, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PutAsync(url, stringContent);

            if (httpResponse.StatusCode >= HttpStatusCode.OK && httpResponse.StatusCode < HttpStatusCode.Ambiguous)
            {
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                T response = JsonConvert.DeserializeObject<T>(responseStr);
                return response;
            }
            else
            {
                await Helpers.Helpers.ServerExceptions(httpResponse);
                return default(T);
            }
        }

        public async Task<T> DeleteAsync<T>(string url) where T: new()
        {
            HttpClient client = base.GetClient();
            HttpResponseMessage httpResponse = await client.DeleteAsync(url);
            return await base.HttpResponseDeserializeObjectAsync<T>(httpResponse);
        }

        
    }
}
