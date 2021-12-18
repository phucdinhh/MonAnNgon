using MonAnNgon.Models;
using MonAnNgon.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace MonAnNgon.ViewModels
{
    [QueryProperty(nameof(CategoryId), nameof(CategoryId))]
    public class FoodsViewModel : BaseViewModel
    {
        private Food _selectedItem;
        private long _categoryId;
        private bool alreadySetCategoryId;
        private int TapCount { get; set; }
        public ObservableCollection<Food> Foods { get; }
        public Command LoadItemsIncrementally { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Food> ItemTapped { get; }

        public FoodsViewModel()
        {
            Title = "Browse";
            Foods = new ObservableCollection<Food>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsIncrementally = new Command(async () => await ExecuteLoadItemsIncrementallyCommand());
            ItemTapped = new Command<Food>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
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
                //alreadySetCategoryId = true;
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
                var items = await DataStore.GetFoodsByCategoryIdAsync(_categoryId, true);
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

        async Task ExecuteLoadItemsIncrementallyCommand()
        {
            try
            {
                if (IsBusy || Foods.Count == 0)
                    return;

                var items = await DataStore.LoadMoreFoodsByCategoryIdAsync(_categoryId);
                foreach (var item in items)
                {
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
