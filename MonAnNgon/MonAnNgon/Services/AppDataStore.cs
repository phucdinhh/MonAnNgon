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
        private Pagination foodPagination;
        private List<CategoryExample> categories;
        private Pagination categoryPagination;

        public AppDataStore()
        {
            foods = new List<Food>() { };
            categories = new List<CategoryExample>() { };
            foodPagination = new Pagination
            {
                Page = 0,
                PageSize = 0,
                PageCount = 0,
                Total = 0
            };
            categoryPagination = new Pagination
            {
                Page = 0,
                PageSize = 0,
                PageCount = 0,
                Total = 0
            };
        }

        public async Task<Food> GetItemAsync(long id)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/foods/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Food result = JsonConvert.DeserializeObject<Food>(responseBody);
            result.ImageUrl = "http://52.243.101.54:1337" + result.Image[0].Url;
            return await Task.FromResult(result);
        }

        public async Task<CategoryExample> GetCategoryAsync(long id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id == id));
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
                HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/foods?pagination[page]=1&pagination[pageSize]=10");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                FoodApiResult page = JsonConvert.DeserializeObject<FoodApiResult>(responseBody);
                foods = page.Results.ToList();
                foodPagination = page.Pagination;
                return await Task.FromResult(foods);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(foods);
            }
        }
        
        public async Task<IEnumerable<Food>> GetFoodsByCategoryIdAsync(long categoryId, bool forceRefresh = false)
        {
            if (!forceRefresh)
            {
                return await Task.FromResult(foods);
            }

            try
            {
                var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/foods?pagination[page]=1&pagination[pageSize]=10&filters[category]=" + categoryId);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                FoodApiResult page = JsonConvert.DeserializeObject<FoodApiResult>(responseBody);
                foods.Clear();
                foods = foods.Concat(page.Results.ToList()).ToList();
                foodPagination = page.Pagination;
                return await Task.FromResult(foods);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(foods);
            }
        }

        public async Task<IEnumerable<Food>> LoadMoreFoodsByCategoryIdAsync(long categoryId)
        {
            try
            {
                var httpClient = new HttpClient();
                foodPagination.Page++;
                HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/foods?pagination[page]=" + foodPagination.Page + "&pagination[pageSize]=10&filters[category]=" + categoryId);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                FoodApiResult page = JsonConvert.DeserializeObject<FoodApiResult>(responseBody);
                List<Food> more = page.Results.ToList();
                foods.Concat(more);
                foodPagination = page.Pagination;
                return await Task.FromResult(more);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(new List<Food>());
            }
        }

        public async Task<IEnumerable<Food>> LoadMoreItemsAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                foodPagination.Page++;
                HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/foods?pagination[page]=" + foodPagination.Page + "&pagination[pageSize]=10");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                FoodApiResult page = JsonConvert.DeserializeObject<FoodApiResult>(responseBody);
                List<Food> more = page.Results.ToList();
                foods.Concat(more);
                foodPagination = page.Pagination;
                return await Task.FromResult(more);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(new List<Food>());
            }
        }

        public async Task<IEnumerable<CategoryExample>> GetCategoriesAsync(bool forceRefresh = false)
        {
            if (!forceRefresh)
            {
                return await Task.FromResult(categories);
            }

            try
            {
                var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/categories?pagination[page]=1&pagination[pageSize]=10");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                CategoryApiResult page = JsonConvert.DeserializeObject<CategoryApiResult>(responseBody);
                categories = page.Results.ToList();
                categoryPagination = page.Pagination;
                return await Task.FromResult(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(categories);
            }
        }

        public async Task<IEnumerable<CategoryExample>> LoadMoreCategoriesAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                categoryPagination.Page++;
                HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/categories?pagination[page]=" + categoryPagination.Page + "&pagination[pageSize]=10");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                CategoryApiResult page = JsonConvert.DeserializeObject<CategoryApiResult>(responseBody);
                List<CategoryExample> more = page.Results.ToList();
                categories.Concat(more);
                categoryPagination = page.Pagination;
                return await Task.FromResult(more);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(new List<CategoryExample>());
            }
        }

        public async Task<IEnumerable<Food>> GetRelatedItemsAsync(long id, int numberItems)
        {
            try
            {
                var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("http://52.243.101.54:1337/api/foods?pagination[page]=1&pagination[pageSize]=" + numberItems + "&filters[id][$ne]=" + id);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                FoodApiResult page = JsonConvert.DeserializeObject<FoodApiResult>(responseBody);
                return await Task.FromResult(page.Results);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return await Task.FromResult(new List<Food>() { });
            }
        }
    }
}
