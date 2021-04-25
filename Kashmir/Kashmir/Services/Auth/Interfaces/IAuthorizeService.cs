using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kashmir.Services.Auth.Interfaces
{
    public interface IAuthorizeService
    {
        Task<bool> RegisterAsync(string firstName, string lastName, string email, string pwd, string pwdCon);
        Task<bool> LoginAsync(string email, string pwd);
        Task<bool> LogoutAsync();
        Task<bool> RefreshToken();
        Task<bool> ForgotPasswordAsync(string email);
    }
}
