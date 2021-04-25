using Kashmir.Models;
using Kashmir.Services.Auth;
using Kashmir.Services.Auth.Interfaces;
using Kashmir.Views.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kashmir.ViewModels.Profile
{
    public class ProfileViewModel : BaseViewModel
    {

        public User User { get; private set; }

        public ICommand LogoutCommand { get; private set; }

        public ProfileViewModel()
        {
            this.User =  Task.Run<User>(async () => await App.Auth.GetAuth()).Result;
            this.LogoutCommand = new Command(async () => await Logout());
        }

        private async Task Logout()
        {
            bool isLogouted = await App.AuthorizeService.LogoutAsync();

            if (isLogouted)
            {
                Helpers.Helpers.ShowToastShortMessage("You successful logouted");
                App.Current.MainPage = new NavigationPage(new LoginView());
            }
        }

    }
}
