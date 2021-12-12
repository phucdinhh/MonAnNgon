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
        private string itemId;
        private string name;
        private string ingredient;
        private string instruction;
        private string image;

        public string Id { get; set; }

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

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public ObservableCollection<Food> Relateds { get; set; }

        public string ItemId
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

        public async void LoadItemId(string itemId)
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
