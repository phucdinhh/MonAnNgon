using MonAnNgon.ViewModels;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonAnNgon.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailViewModel test;

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Tab1Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.FromHex("#7c1ca0");
            Tab2.BackgroundColor = Color.White;
            Tab3.BackgroundColor = Color.White;
            stkTab1.IsVisible = true;
            stkTab2.IsVisible = false;
            stkTab3.IsVisible = false;
        }

        private void Tab2Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.White;
            Tab2.BackgroundColor = Color.FromHex("#7c1ca0");
            Tab3.BackgroundColor = Color.White;
            stkTab1.IsVisible = false;
            stkTab2.IsVisible = true;
            stkTab3.IsVisible = false;
        }

        private void Tab3Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.White;
            Tab2.BackgroundColor = Color.White;
            Tab3.BackgroundColor = Color.FromHex("#7c1ca0");
            stkTab1.IsVisible = false;
            stkTab2.IsVisible = false;
            stkTab3.IsVisible = true;
        }
    }
}