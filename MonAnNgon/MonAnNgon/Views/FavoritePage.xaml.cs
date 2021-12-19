using MonAnNgon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonAnNgon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        public FavoritePage()
        {
            InitializeComponent();
            FavoriteInit();
        }

        void FavoriteInit()
        {
            List<Food> foods = new List<Food>();
            Database db = new Database();
            List<Favorite> favorites = db.GetFavorite();
            List<Food> foodtble = db.GetFood();

            foreach (Favorite favorite in favorites)
            {
                var foodId = favorite.Id;
                List<Food> temp = db.GetOneFood(foodId);
                if (temp.Count > 0)
                {
                    temp.ElementAt(0).FavorId = favorite.FavorId;
                    foods.Add(temp.ElementAt(0));
                }

            };
            ListFavorite.ItemsSource = foods;
        }

        private void ListFavorite_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Food seletedFood = e.SelectedItem as Food;
            Navigation.PushAsync(new ItemDetailPage(seletedFood));
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            db.DeleteAllData();
        }
    }
}