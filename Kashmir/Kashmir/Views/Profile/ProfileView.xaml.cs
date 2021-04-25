using Kashmir.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kashmir.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {

        private ProfileViewModel ViewModel 
        {
            get => base.BindingContext as ProfileViewModel;
            set => base.BindingContext = value as ProfileViewModel;
        }

        public ProfileView()
        {
            this.ViewModel = new ProfileViewModel();
            InitializeComponent();
        }
    }
}