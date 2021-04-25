using Kashmir.Helpers;
using Kashmir.Models;
using Kashmir.Services.Auth;
using Kashmir.Services.Auth.Interfaces;
using Kashmir.Services.Basic;
using Kashmir.Views.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kashmir.ViewModels.Auth
{
    public class RegisterViewModel : BaseViewModel
    {

        private string firstName;
        public string FirstName 
        {
            get => this.firstName;
            set => base.SetProperty(ref this.firstName, value);
        }

        private string lastName;
        public string LastName 
        {
            get => this.lastName;
            set => base.SetProperty(ref this.lastName, value); 
        }

        private string email;
        public string Email { 
            get => this.email; 
            set => base.SetProperty(ref this.email, value); 
        }

        private string password;
        public string Password 
        {
            get => this.password;
            set => base.SetProperty(ref this.password, value);
        }

        private string passwordConfirmation;
        public string PasswordConfirmation 
        {
            get => this.passwordConfirmation;
            set => base.SetProperty(ref this.passwordConfirmation, value);
        }

        public ICommand RegisterCommand { get; private set; }
        public ICommand GoToLoginCommand { get; private set; }

        public RegisterViewModel()
        {
            Services.Auth.Auth auth = new Services.Auth.Auth();
            auth.SetAccessToken("testToken");
            Helpers.Helpers.DisplayAleryAsync("Saved", "testToken", "Ok");

            this.RegisterCommand = new Command(async () => await Register());
            this.GoToLoginCommand = new Command(async () => await GoToLogin());
        }

        private async Task Register()
        {
            base.IsLoadingToggle();
            bool isRegistered = await App.AuthorizeService.RegisterAsync(this.firstName, this.lastName, this.email, this.password, this.passwordConfirmation);
            base.IsLoadingToggle();

            if (isRegistered)
            {
                Helpers.Helpers.ShowToastShortMessage("Succesfull registered!");
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        private async Task GoToLogin()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
