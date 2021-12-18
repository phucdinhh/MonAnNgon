using MonAnNgon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonAnNgon.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private long itemId;
        private string name;
        private string ingredient;
        private string instruction;
        private Media[] image;
        private string imageUrl;

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

        public async void LoadItemId(long itemId)
        {
            IsBusy = true;

            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Ingredient = item.Ingredients;
                Name = item.Name;
                Instruction = item.Instruction;
                Image = item.Image;
                ImageUrl = item.ImageUrl;
                Relateds.Clear();
                var relatedFoods = await DataStore.GetItemsAsync(true);
                foreach (var relatedFood in relatedFoods)
                {
                    if (Relateds.Count <= 5 && item.Id != relatedFood.Id)
                    {
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
        public ItemDetailViewModel()
        {
            Relateds = new ObservableCollection<Food>();
        }
    }
}
