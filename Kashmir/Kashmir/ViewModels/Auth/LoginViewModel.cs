using Kashmir.Views.Auth;
using Kashmir.Views.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kashmir.ViewModels.Auth
{
    public class LoginViewModel : BaseViewModel
    {

        public string email;
        public string Email 
        { 
            get => this.email; 
            set => base.SetProperty(ref email, value);
        }

        public string password;
        public string Password 
        { 
            get => this.password; 
            set => base.SetProperty(ref password, value);
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand GoToRegisterCommand { get; private set; }
        public ICommand GoToForgotPasswordCommand { get; private set; }

        public LoginViewModel()
        {
            Services.Auth.Auth auth = new Services.Auth.Auth();
            this.Email = auth.GetAccessTokenTest();
            Helpers.Helpers.DisplayAleryAsync("Get", "testToken: " + this.Email, "Ok");

            this.LoginCommand = new Command(async () => await Login());
            this.GoToRegisterCommand = new Command( async () => await GoToRegister());
            this.GoToForgotPasswordCommand = new Command(async () => await GoToForgotPassword());
        }

        private async Task Login()
        {
            Services.Auth.Auth auth = new Services.Auth.Auth();
            bool str = auth.RemoveAccessTokenTest();
            await Helpers.Helpers.DisplayAleryAsync("LLLLLLLL", "testToken: Removed" + str, "Ok");

            App.Current.MainPage.IsBusy = true;
            base.IsLoadingRun();
            bool isLogined = await App.AuthorizeService.LoginAsync(this.email, this.password);
            base.IsLoadingStop();
            App.Current.MainPage.IsBusy = false;

            if (isLogined)
            {
                App.Current.MainPage = new NavigationPage(new ProfileView());
                Helpers.Helpers.ShowToastShortMessage("Succesfull logined");
            }
        }

        private async Task GoToRegister()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterView());
        }

        private async Task GoToForgotPassword()
        {
            Services.Auth.Auth auth = new Services.Auth.Auth();
            string str = auth.GetAccessTokenTest();
            await Helpers.Helpers.DisplayAleryAsync("Gettttt", "testToken: " + str, "Ok");
            await App.Current.MainPage.Navigation.PushAsync(new ForgotPasswordView());
        }
    }
}
