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

        private int TapCount { get; set; }
        public ObservableCollection<Food> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command LoadItemsIncrementally { get; }
        public Command AddItemCommand { get; }
        public Command<Food> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Food>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsIncrementally = new Command(async () => await ExecuteLoadItemsIncrementallyCommand());

            ItemTapped = new Command<Food>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            TapCount = 0;
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

        async Task ExecuteLoadItemsIncrementallyCommand()
        {
            try
            {
                if (IsBusy || Items.Count == 0)
                    return;

                var items = await DataStore.LoadMoreItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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

        private void OnAddItem(object obj)
        {
        }

        async void OnItemSelected(Food item)
        {
            if (item == null || TapCount > 0)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            TapCount++;
            await Shell.Current.GoToAsync($"{nameof(Views.ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            TapCount--;
        }

    }
}