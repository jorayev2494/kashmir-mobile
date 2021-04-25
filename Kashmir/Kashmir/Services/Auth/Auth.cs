using Kashmir.Models;
using Kashmir.Services.Auth.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Kashmir.Services.Auth
{
    public class Auth : IAuth
    {
        private const string GUARD = "user";

        public async Task SetAuth(string accessToken, User model)
        {
            await SetAccessToken(accessToken);
            await SetUser(model);

        }
        public async Task<User> GetAuth()
        {
            return await GetUser();
        }

        public void RemoveAuth()
        {
            RemoveAccessToken();
            RemoveUser();
        }

        public async Task<bool> Check()
        {
            return await GetCheck() == true.ToString();
        }

        #region Access Token
        public async Task SetAccessToken(string accessToken)
        {
            Preferences.Set("accessToken", accessToken);
            await SecureStorage.SetAsync("accessToken", accessToken);
        }

        public async Task<string> GetAccessToken()
        {
            return "Bearer " + await SecureStorage.GetAsync("accessToken");
        }

        public string GetAccessTokenTest()
        {
            return Preferences.Get("accessToken", string.Empty);
        }

        public bool RemoveAccessToken()
        {
            return SecureStorage.Remove("accessToken");
        }

        public bool RemoveAccessTokenTest()
        {
            //return SecureStorage.Remove("accessToken");
            Preferences.Remove("accessToken");
            return true;
        }
        #endregion

        #region User Data
        public async Task<User> SetUser(User model)
        {
            User user = model as User;

            if (user is User)
            {
                string userDataStr = JsonConvert.SerializeObject(user);
                Debug.Write(userDataStr);
                await SecureStorage.SetAsync("userData", userDataStr);
                return user;
            }

            return null;
        }

        public async Task<User> GetUser()
        {
            string userDataStr = await SecureStorage.GetAsync("userData");
            User user = JsonConvert.DeserializeObject<User>(userDataStr);
            return user is User ? user : null;
        }

        public bool RemoveUser()
        {
            return SecureStorage.Remove("userData");
        }
        #endregion

        private async Task SetCheck()
        {
            await SecureStorage.SetAsync("check", true.ToString());
        }

        private async Task<string> GetCheck()
        {
           return  await SecureStorage.GetAsync("check");
        }
    }
}
