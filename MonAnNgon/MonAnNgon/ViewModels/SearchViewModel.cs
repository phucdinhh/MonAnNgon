using System;
using System.Collections.Generic;
using System.Text;
using MonAnNgon.Models;
using MonAnNgon.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace MonAnNgon.ViewModels
{
    [QueryProperty(nameof(CategoryId), nameof(CategoryId))]
    [QueryProperty(nameof(CategoryName), nameof(CategoryName))]
    public class SearchViewModel : BaseViewModel
    {
        private Food _selectedItem;
        private long _categoryId;
        private string _categoryName;
        private int TapCount { get; set; }
        public ObservableCollection<Food> Foods { get; set; }
        public Command LoadItemsIncrementally { get; }
        public Command LoadItemsCommand { get; }
        public Command<Food> ItemTapped { get; }

        public Command<string> SearchItem { get; set; }

        public ICommand searchCommand => new Command<string>(ExecuteLoadSearchItemCommand);

        public SearchViewModel()
        {
            Foods = new ObservableCollection<Food>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsIncrementally = new Command(async () => await ExecuteLoadItemsIncrementallyCommand());
            ItemTapped = new Command<Food>(OnItemSelected);
            TapCount = 0;
        }
        public long CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                Title = value;
                _categoryName = value;
            }
        }

        public async void LoadFoodsByCategoryId(long categoryId)
        {
            IsBusy = true;
            try
            {
                Foods.Clear();
                var items = await DataStore.GetFoodsByCategoryIdAsync(categoryId, true);
                foreach (var item in items)
                {
                    Foods.Add(item);
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

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Foods.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    item.ImageUrl = "http://52.243.101.54:1337" + item.Image[0].Url;
                    Foods.Add(item);
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

        public void ExecuteLoadSearchItemCommand(string itemName)
        {
            IsBusy = true;
            Foods.Clear();
            Task.Run(async () =>
            {
                try
                {
                    Foods.Clear();
                    var items = await DataStore.GetSearchItemsAsync(itemName);
                    foreach (var item in items)
                    {
                        item.ImageUrl = "http://52.243.101.54:1337" + item.Image[0].Url;
                        Foods.Add(item);
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
            });
        }

        async Task ExecuteLoadItemsIncrementallyCommand()
        {
            try
            {
                if (IsBusy || Foods.Count == 0)
                    return;

                var items = await DataStore.LoadMoreItemsAsync();
                foreach (var item in items)
                {
                    item.ImageUrl = "http://52.243.101.54:1337" + item.Image[0].Url;
                    Foods.Add(item);
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
