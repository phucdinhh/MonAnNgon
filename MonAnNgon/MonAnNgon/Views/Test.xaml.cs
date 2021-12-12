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
    public partial class Test : ContentPage
    {
        public Test()
        {
            InitializeComponent();
        }
        private void Tab1Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.FromHex("#2196F3");
            Tab2.BackgroundColor = Color.White;
            Tab3.BackgroundColor = Color.White;
            stkTab1.IsVisible = true;
            stkTab2.IsVisible = false;
            stkTab3.IsVisible = false;
        }

        private void Tab2Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.White;
            Tab2.BackgroundColor = Color.FromHex("#2196F3");
            Tab3.BackgroundColor = Color.White;
            stkTab1.IsVisible = false;
            stkTab2.IsVisible = true;
            stkTab3.IsVisible = false;
        }

        private void Tab3Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.White;
            Tab2.BackgroundColor = Color.White;
            Tab3.BackgroundColor = Color.FromHex("#2196F3");
            stkTab1.IsVisible = false;
            stkTab2.IsVisible = false;
            stkTab3.IsVisible = true;
        }
    }
}