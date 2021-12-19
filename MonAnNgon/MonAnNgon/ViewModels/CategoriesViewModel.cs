using MonAnNgon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonAnNgon.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private CategoryExample _selectedCategory;
        private int TapCount { get; set; }
        public ObservableCollection<CategoryExample> Categories { get; }
        public Command LoadCategoriesCommand { get; }
        public Command LoadCategoriesIncrementally { get; }
        public Command<CategoryExample> CategoryTapped { get; }

        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<CategoryExample>();
            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());
            LoadCategoriesIncrementally = new Command(async () => await ExecuteLoadCategoriesIncrementallyCommand());
            CategoryTapped = new Command<CategoryExample>(OnCategorySelected);
            TapCount = 0;
        }

        async Task ExecuteLoadCategoriesCommand()
        {
            IsBusy = true;
            try
            {
                Categories.Clear();
                var categories = await DataStore.GetCategoriesAsync(true);
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadCategoriesIncrementallyCommand()
        {
            try
            {
                if (IsBusy || Categories.Count == 0)
                    return;

                var categories = await DataStore.LoadMoreCategoriesAsync();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCategory = null;
        }

        public CategoryExample SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);
                OnCategorySelected(value);
            }
        }

        async void OnCategorySelected(CategoryExample item)
        {
            if (item == null || TapCount > 0)
                return;

            TapCount++;
            await Shell.Current.GoToAsync($"{nameof(Views.FoodsPage)}?{nameof(FoodsViewModel.CategoryId)}={item.Id}&{nameof(FoodsViewModel.CategoryName)}={item.Name}");
            TapCount--;
        }
    }
}
