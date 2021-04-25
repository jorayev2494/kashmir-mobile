using Kashmir.Exceptions;
using Kashmir.Models;
using Kashmir.Services.Auth;
using Kashmir.Services.Auth.Interfaces;
using Kashmir.Services.Auth.Responces;
using Kashmir.Services.Basic.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Kashmir.Services.Basic
{
    public class AuthorizeService : APIBaseService, IAuthorizeService
    {

        private Auth.Auth auth = new Auth.Auth();

        public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string pwd, string pwdCon)
        {

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || 
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(pwdCon))
            {
                await Helpers.Helpers.DisplayAleryAsync("Error", "Please write all properties", "Ok");
                return false;
            }

            if (pwd != pwdCon)
            {
                string msg = "Password not confirmation";
                // await Helpers.Helpers.DisplayAleryAsync("Error", msg, "Ok");
                Helpers.Helpers.ShowToastLongMessage(msg);
                return false;
            }

            HttpClient client = GetClient();
            object dataObject = new { 
                first_name              = firstName,
                last_name               = lastName,
                email                   = email,
                password                = pwd,
                password_confirmation   = pwdCon,
            };

            string dataObjectStr = JsonConvert.SerializeObject(dataObject);
            HttpContent httpContent = new StringContent(dataObjectStr, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PostAsync("/api/auth/register", httpContent);

            if (httpResponse.StatusCode >= HttpStatusCode.OK && httpResponse.StatusCode < HttpStatusCode.Ambiguous)
            {
                return true;
            } 
            else
            {
                await Helpers.Helpers.ServerExceptions(httpResponse);
                return false;
            }
        }

        public async Task<bool> LoginAsync(string email, string pwd)
        {

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd))
            {
                string msg = "Please write all properties";
                Helpers.Helpers.ShowToastShortMessage(msg);
                return false;
            }

            HttpClient client = GetClient();
            string dataObjectStr = JsonConvert.SerializeObject(new { email = email, password = pwd });
            HttpContent httpContent = new StringContent(dataObjectStr, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await client.PostAsync("/api/auth/login", httpContent);
            if (httpResponse.StatusCode >= HttpStatusCode.OK && httpResponse.StatusCode < HttpStatusCode.Ambiguous) 
            {
                string responseStr = await httpResponse.Content.ReadAsStringAsync();
                AuthLginResponce authLginResponce = JsonConvert.DeserializeObject<AuthLginResponce>(responseStr);
                await App.Auth.SetAuth(authLginResponce.accessToken as string, authLginResponce.userData as User);
                return true;
            }
            else
            {
                await Helpers.Helpers.ServerExceptions(httpResponse);
                return false;
            }
        }

        public async Task<bool> LogoutAsync()
        {
            HttpClient client = GetClient();
            HttpResponseMessage httpResponse = await client.PostAsync("/api/auth/logout", null);
            App.Auth.RemoveAuth();
            return true;
        }

        public async Task<bool> RefreshToken()
        {
            HttpClient client = GetClient();

            if (await auth.Check())
            {
                string accessToken = await auth.GetAccessToken();
                HttpResponseMessage httpResponse = await client.GetAsync("/api/auth/token/refresh");
                JObject jObject = (JObject)JsonConvert.SerializeObject(httpResponse.Content.ReadAsStringAsync());
                string responseAccessToken = jObject.Value<string>("token");
                if (responseAccessToken is string)
                {
                    await auth.SetAccessToken(responseAccessToken);
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                Helpers.Helpers.ShowToastShortMessage("Plase write your email");
                return false;
            }

            HttpClient client = GetClient();
            string dataObjectStr = JsonConvert.SerializeObject(new { email = email });
            HttpContent httpContent = new StringContent(dataObjectStr, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PostAsync("/api/auth/forgot_password/email", httpContent);

            if (httpResponse.StatusCode >= HttpStatusCode.OK && httpResponse.StatusCode < HttpStatusCode.Ambiguous)
            {
                await Helpers.Helpers.DisplayAleryAsync("Success", string.Format("Link sent your email: {0}", email), "Ok");
                return true;
            }
            else
            {
                App.Auth.RemoveAuth();
                await Helpers.Helpers.ServerExceptions(httpResponse);
                return false;
            }
        }
    }
}
