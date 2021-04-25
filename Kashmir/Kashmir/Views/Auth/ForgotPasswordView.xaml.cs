using Kashmir.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kashmir.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordView : ContentPage
    {

        public ForgotPasswordViewModel ViewModel 
        { 
            get => base.BindingContext as ForgotPasswordViewModel;
            set => base.BindingContext = value as ForgotPasswordViewModel;
        }

        public ForgotPasswordView()
        {
            this.ViewModel = new ForgotPasswordViewModel();
            InitializeComponent();
        }
    }
}