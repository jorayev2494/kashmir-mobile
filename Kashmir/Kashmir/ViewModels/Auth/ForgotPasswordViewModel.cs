
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Kashmir.ViewModels.Auth
{
    public class ForgotPasswordViewModel : BaseViewModel
    {

        private string email;
        public string Email 
        {
            get => this.email;
            set => base.SetProperty(ref email, value);
        }

        public ICommand SendResetLinkEmailCommand { get; private set; }
        public ICommand GoToLoginCommand { get; private set; }

        public ForgotPasswordViewModel()
        {
            this.SendResetLinkEmailCommand = new Command(async () => await SendResetLinkEmail());
            this.GoToLoginCommand = new Command(async () => await GoToLogin());
        }

        private async Task SendResetLinkEmail()
        {
            base.IsLoadingToggle();
            bool isSentLink = await App.AuthorizeService.ForgotPasswordAsync(this.email);
            base.IsLoadingToggle();

            if (isSentLink)
            {
                Helpers.Helpers.ShowToastShortMessage("Link for recovery password succesfull sent");
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        private async Task GoToLogin()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
