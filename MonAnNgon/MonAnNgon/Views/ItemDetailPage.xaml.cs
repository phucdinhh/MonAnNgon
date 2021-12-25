﻿using MonAnNgon.Models;
using MonAnNgon.ViewModels;
using System;
using Xamarin.Forms;

namespace MonAnNgon.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        readonly Food food;
        public ItemDetailViewModel test;
        private Favorite favorFood;

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = test = new ItemDetailViewModel();
            

        }

        public ItemDetailPage(Food food)
        {
            InitializeComponent();
            foodImage.Source = food.ImageUrl;
            foodName.Text = food.Name;
            this.food = food;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Database db = new Database();
            ToolbarItems.Clear();
            if (db.CheckFavorite(test.ItemId))
            {
                ToolbarItems.Add(DeleteFavoriteBtn);
            }
            else ToolbarItems.Add(AddFavoriteBtn);
        }

        private void Tab1Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.FromHex("#7c1ca0");
            Tab2.BackgroundColor = Color.White;
            Tab3.BackgroundColor = Color.White;
            stkTab1.IsVisible = true;
            stkTab2.IsVisible = false;
            stkTab3.IsVisible = false;
        }

        private void Tab2Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.White;
            Tab2.BackgroundColor = Color.FromHex("#7c1ca0");
            Tab3.BackgroundColor = Color.White;
            stkTab1.IsVisible = false;
            stkTab2.IsVisible = true;
            stkTab3.IsVisible = false;
        }

        private void Tab3Clicked(object sender, EventArgs e)
        {
            Tab1.BackgroundColor = Color.White;
            Tab2.BackgroundColor = Color.White;
            Tab3.BackgroundColor = Color.FromHex("#7c1ca0");
            stkTab1.IsVisible = false;
            stkTab2.IsVisible = false;
            stkTab3.IsVisible = true;
        }

        private void AddFavoriteBtn_Clicked(object sender, EventArgs e)
        {
            favorFood = new Favorite
            {
                Id = test.Id,
                Name = test.Name,
                Ingredients = test.Ingredient,
                Instruction = test.Instruction,
                ImageUrl = test.ImageUrl,
            };

            Database db = new Database();
            if (db.AddFavorite(favorFood))
            {
                if (ToolbarItems.Contains(AddFavoriteBtn)) {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(DeleteFavoriteBtn);
                };
                test.CheckFav = true;
                DisplayAlert("Notification", "Added to favorite list!", "OK");
            }
            else
            {
                DisplayAlert("Notification", "Failed!" , "OK");
            }
        }

        private void DeleteFavoriteBtn_Clicked(object sender, EventArgs e)
        {
            favorFood = new Favorite
            {
                Id = test.Id,
                Name = test.Name,
                Ingredients = test.Ingredient,
                Instruction = test.Instruction,
                ImageUrl = test.ImageUrl,
            };

            Database db = new Database();
            if (db.DeleteOneFavorite(favorFood))
            {
                if (ToolbarItems.Contains(DeleteFavoriteBtn)) 
                {
                    ToolbarItems.Clear();
                    ToolbarItems.Add(AddFavoriteBtn);
                }
                test.CheckFav = false;
                DisplayAlert("Notification", "Delete successful!", "OK");
            }
            else
            {
                DisplayAlert("Notification", "Delete Failed!", "OK");
            }
        }
    }
}