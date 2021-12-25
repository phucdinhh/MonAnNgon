using MonAnNgon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonAnNgon.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(Local), nameof(Local))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private long itemId;
        private bool local;
        private string name;
        private string ingredient;
        private string instruction;
        private Media[] image;
        private string imageUrl;
        private int TapCount { get; set; }
        public Command<Food> ItemTapped { get; }
        private bool checkFav;

        public long Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Ingredient
        {
            get => ingredient;
            set => SetProperty(ref ingredient, value);
        }

        public string Instruction
        {
            get => instruction;
            set => SetProperty(ref instruction, value);
        }

        public Media[] Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public string ImageUrl
        {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
        }

        public ObservableCollection<Food> Relateds { get; set; }

        public long ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        
        public bool Local
        {
            get
            {
                return local;
            }
            set
            {
                local = value;
            }
        }

        public ItemDetailViewModel()
        {
            Relateds = new ObservableCollection<Food>();
            ItemTapped = new Command<Food>(OnItemSelected);
            TapCount = 0;
        }
        
        public bool CheckFav
        {
            get
            {
                return checkFav;
            }
            set
            {
                checkFav = value;
            }
        }

        public async void LoadItemId(long itemId)
        {
            IsBusy = true;

            try
            {
                var current = Connectivity.NetworkAccess;

                if (current != NetworkAccess.Internet)
                {
                    var item = Db.GetOneFavorite(itemId);
                    Id = item.Id;
                    Ingredient = item.Ingredients;
                    Name = item.Name;
                    Instruction = item.Instruction;
                    ImageUrl = item.ImageUrl;
                    Relateds.Clear();
                    var relatedFoods = await DataStore.GetRelatedItemsAsync(item.Id, 5);
                    foreach (var relatedFood in relatedFoods)
                    {
                        relatedFood.ImageUrl = relatedFood.Image[0].Url;
                        Relateds.Add(relatedFood);
                    }
                }
                else
                {
                    var item = await DataStore.GetItemAsync(itemId);
                    Id = item.Id;
                    Ingredient = item.Ingredients;
                    Name = item.Name;
                    Instruction = item.Instruction;
                    Image = item.Image;
                    ImageUrl = item.ImageUrl;
                    Relateds.Clear();
                    var relatedFoods = await DataStore.GetRelatedItemsAsync(item.Id, 5);
                    foreach (var relatedFood in relatedFoods)
                    {
                        relatedFood.ImageUrl = "http://52.243.101.54:1337" + relatedFood.Image[0].Url;
                        Relateds.Add(relatedFood);
                    }
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
