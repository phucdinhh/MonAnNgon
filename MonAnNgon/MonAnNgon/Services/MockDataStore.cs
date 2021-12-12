using MonAnNgon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonAnNgon.Services
{
    public class MockDataStore : IDataStore<Food>
    {
        readonly List<Food> items;

        public MockDataStore()
        {
            items = new List<Food>()
            {
                new Food {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Pizza",
                    Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n"+
                                "- Thịt bò: đập dập, thái miếng mỏng\n"+
                                "- Hải sản\n"+
                                "- Tỏi băm nhuyễn\n"+
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n"+
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n"+
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                    Instruction="- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó",
                    Image="pizza.jpg"
                },
                new Food {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Mì tôm",
                    Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n"+
                                "- Thịt bò: đập dập, thái miếng mỏng\n"+
                                "- Hải sản\n"+
                                "- Tỏi băm nhuyễn\n"+
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n"+
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n"+
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                    Instruction="- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó", 
                    Image="noodle.jpg" 
                },
                new Food {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Salad",
                    Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n"+
                                "- Thịt bò: đập dập, thái miếng mỏng\n"+
                                "- Hải sản\n"+
                                "- Tỏi băm nhuyễn\n"+
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n"+
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n"+
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                    Instruction="- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó",
                    Image="salad.jpg"
                },
                new Food {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Hamburger",
                    Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n"+
                                "- Thịt bò: đập dập, thái miếng mỏng\n"+
                                "- Hải sản\n"+
                                "- Tỏi băm nhuyễn\n"+
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n"+
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n"+
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                    Instruction="- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó",
                    Image="hamburger.jpg"
                },
            };
        }

        public async Task<bool> AddItemAsync(Food item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Food item)
        {
            var oldItem = items.Where((Food arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Food arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Food> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Food>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Food>> GetRelatedItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items.Take(2));
        }
    }
}