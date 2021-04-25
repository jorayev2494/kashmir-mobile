using Kashmir.Services;
using Kashmir.Services.Auth.Interfaces;
using Kashmir.Services.Basic;
using Kashmir.Views.Auth;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kashmir
{
    public partial class App : Application
    {

        public static IAuth Auth = new Services.Auth.Auth();
        public static IAuthorizeService AuthorizeService = new AuthorizeService();


        public App()
        {
            InitializeComponent();
            base.MainPage = new NavigationPage(new LoginView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
