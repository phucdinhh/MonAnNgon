using MonAnNgon.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MonAnNgon.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}