using MonAnNgon.Models;
using MonAnNgon.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonAnNgon.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Food _selectedItem;

        private int tapCount { get; set; }
        public ObservableCollection<Food> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Food> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Food>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Food>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            tapCount = 0;
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Food SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Food item)
        {
            if (item == null || tapCount > 0)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            tapCount++;
            await Shell.Current.GoToAsync($"{nameof(Views.ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            tapCount--;
        }

    }
}