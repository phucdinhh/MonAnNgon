using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonAnNgon.Models;
using MonAnNgon.ViewModels;

namespace MonAnNgon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        readonly SearchViewModel _viewModel;
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SearchViewModel();
            //MyListView.ItemsSource = GetList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private static IEnumerable<Category> GetList(string searchText = null)
        {
            List<Category> contacts = new List<Category>
            {
                new Category { id = "1", name = "Bánh", img = "CanhThinhDuDu.jpg" },
                new Category { id = "2", name = "Chiên Xào", img = "green_spinach.jpg" },
                new Category { id = "3", name = "Nướng", img = "ot_chuong_hai_san.jpg" },
                new Category { id = "4", name = "Kho", img = "salad.jpg" },
                new Category { id = "2", name = "Chiên Xào", img = "green_spinach.jpg" },
                new Category { id = "3", name = "Nướng", img = "ot_chuong_hai_san.jpg" },
                new Category { id = "4", name = "Kho", img = "salad.jpg" },
                new Category { id = "2", name = "Chiên Xào", img = "green_spinach.jpg" },
                new Category { id = "3", name = "Nướng", img = "ot_chuong_hai_san.jpg" },
                new Category { id = "4", name = "Kho", img = "salad.jpg" },
                new Category { id = "2", name = "Chiên Xào", img = "green_spinach.jpg" },
                new Category { id = "3", name = "Nướng", img = "ot_chuong_hai_san.jpg" },
                new Category { id = "4", name = "Kho", img = "salad.jpg" },
            };

            return string.IsNullOrEmpty(searchText) ? contacts : contacts
                .Where(c => c.name.ToLower()
                .StartsWith(searchText.ToLower()));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MyListView.ItemsSource = GetList(e.NewTextValue);
        }

        private void MyListView_Refreshing(object sender, EventArgs e)
        {
            //MyListView.ItemsSource = GetList();
            //MyListView.EndRefresh();
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //if (e.Item is Category contact) DisplayAlert("Following", contact.name, "Ok", "Cancel");
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //MyListView.SelectedItem = null;
        }
    }
}