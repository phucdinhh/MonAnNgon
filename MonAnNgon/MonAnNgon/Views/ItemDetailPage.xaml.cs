using MonAnNgon.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MonAnNgon.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        readonly RelatedItemsViewModel _viewModel;

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
            ItemsListView.BindingContext = _viewModel = new RelatedItemsViewModel();
            //BindingContext = new ItemDetailPageModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           _viewModel.OnAppearing();
        }
    }
}