using MonAnNgon.Models;
using MonAnNgon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonAnNgon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHeader : ContentView
    {
        LoginPageViewModel _viewModel;
        public FlyoutHeader()
        {
            InitializeComponent();
            _viewModel = new LoginPageViewModel();
            BindingContext = _viewModel;
            Database db = new Database();
            Auth auth = db.getAuth();
            if (auth.IsLoggedIn)
            {
                LoginContainer.IsVisible = false;
                GreetingContainer.IsVisible = true;
                Greeting.Text = $"Hi, {auth.FullName}";
            }
            else
            {
                GreetingContainer.IsVisible = false;
                LoginContainer.IsVisible = true;
            }

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
            }
        }
    }
}