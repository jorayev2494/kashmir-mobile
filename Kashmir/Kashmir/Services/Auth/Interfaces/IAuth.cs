using Kashmir.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kashmir.Services.Auth.Interfaces
{
    public interface IAuth
    {
        // Task<string> GetAccessToken();
        Task SetAuth(string accessToken, User model);
        Task<User> GetAuth();
        void RemoveAuth();
        Task<bool> Check();
    }
}
