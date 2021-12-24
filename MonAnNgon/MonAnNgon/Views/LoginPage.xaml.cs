using MonAnNgon.Models;
using MonAnNgon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonAnNgon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Database db = new Database();
            Auth auth = db.getAuth();
            if (auth.IsLoggedIn)
            {
                await Shell.Current.GoToAsync($"//{nameof(CategoriesPage)}");
            }
        }
    }
}