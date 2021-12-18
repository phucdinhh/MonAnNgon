using MonAnNgon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace MonAnNgon.Services
{
    public class AppDataStore
    {
        private List<Food> foods;
        private Pagination pagination;

        public AppDataStore()
        {
            foods = new List<Food>() { };
        }
        public async Task<bool> AddItemAsync(Food item)
        {
            foods.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Food item)
        {
            var oldItem = foods.Where((Food arg) => arg.Id == item.Id).FirstOrDefault();
            foods.Remove(oldItem);
            foods.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync()
        {
            return await Task.FromResult(true);
        }

        public async Task<Food> GetItemAsync(long id)
        {
            return await Task.FromResult(foods.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Food>> GetItemsAsync(bool forceRefresh = false)
        {
            if (!forceRefresh)
            {
                return await Task.FromResult(foods);
            }

            try
            {
                var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("http://172.19.0.1:1337/api/foods?pagination[page]=1&pagination[pageSize]=10");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                FoodApiResult page = JsonConvert.DeserializeObject<FoodApiResult>(responseBody);
                foods = page.Results.ToList();
                pagination = page.Pagination;
                return await Task.FromResult(foods);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(foods);
            }
        }

        public async Task<IEnumerable<Food>> LoadMoreItemsAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                pagination.Page++;
                HttpResponseMessage response = await httpClient.GetAsync("http://172.19.0.1:1337/api/foods?pagination[page]=" + pagination.Page + "&pagination[pageSize]=10");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                FoodApiResult page = JsonConvert.DeserializeObject<FoodApiResult>(responseBody);
                List<Food> more = page.Results.ToList();
                foods.Concat(more);
                pagination = page.Pagination;
                return await Task.FromResult(more);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(new List<Food>());
            }
        }

        public async Task<IEnumerable<Food>> GetRelatedItemsAsync()
        {
            return await Task.FromResult(foods.Take(2));
        }

        public Pagination GetPagination()
        {
            return pagination;
        }
    }
}
