using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kashmir.Services.Basic.Abstracts
{
    public class APIBaseService
    {

        private const string SERVER_URL = "http://192.168.43.83:8989";

        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            if (Task.Run<bool>(async () => await App.Auth.Check()).Result)
            {
                //client.DefaultRequestHeaders.Add("Authorization", Task.Run<string>(async () => await (new Auth.Auth()).GetAccessToken()).Result);
                string token = Task.Run<string>(async () => await (new Auth.Auth()).GetAccessToken()).Result;
                 //Helpers.Helpers.DisplayAleryAsync("Auth", token, "ok");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            client.MaxResponseContentBufferSize = 256000;
            client.BaseAddress = new Uri(SERVER_URL);
            return client;
        }

        protected async Task<T> HttpResponseDeserializeObjectAsync<T>(HttpResponseMessage httpResponse)
        {
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
    }
}
