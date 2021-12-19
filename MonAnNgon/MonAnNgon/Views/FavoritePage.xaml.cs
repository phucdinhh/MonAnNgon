using System;
using System.Collections.Generic;
using System.Linq;
using MonAnNgon.Models;
using MonAnNgon.ViewModels;
using MonAnNgon.Views;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonAnNgon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        readonly FavoriteViewModel _viewModel;

        public FavoritePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FavoriteViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            db.DeleteAllData();
        }
    }
}