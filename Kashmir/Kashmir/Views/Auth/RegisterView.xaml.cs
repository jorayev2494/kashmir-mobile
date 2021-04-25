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
    public partial class RegisterView : ContentPage
    {
        public RegisterViewModel ViewModel 
        {
            get => base.BindingContext as RegisterViewModel;
            set => base.BindingContext = value as RegisterViewModel; 
        }

        public RegisterView()
        {
            this.ViewModel = new RegisterViewModel();
            InitializeComponent();
        }
    }
}