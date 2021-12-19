using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class Database
    {
        readonly string folder = System.Environment.GetFolderPath
        (System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                connection.CreateTable<Food>();
                if(connection.Table<Food>().Count() == 0)
                {
                    connection.Insert(new Food
                    {
                        Id = 1,
                        Name = "Pizza",
                        Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n" +
                                "- Thịt bò: đập dập, thái miếng mỏng\n" +
                                "- Hải sản\n" +
                                "- Tỏi băm nhuyễn\n" +
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n" +
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n" +
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                        Instruction = "- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó",
                        Image = "pizza.jpg"
                    });
                    connection.Insert(new Food
                    {
                        Id = 2,
                        Name = "Mì tôm",
                        Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n" +
                                "- Thịt bò: đập dập, thái miếng mỏng\n" +
                                "- Hải sản\n" +
                                "- Tỏi băm nhuyễn\n" +
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n" +
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n" +
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                        Instruction = "- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó",
                        Image = "noodle.jpg"
                    });
                    connection.Insert(new Food
                    {
                        Id = 3,
                        Name = "Salad",
                        Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n" +
                                "- Thịt bò: đập dập, thái miếng mỏng\n" +
                                "- Hải sản\n" +
                                "- Tỏi băm nhuyễn\n" +
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n" +
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n" +
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                        Instruction = "- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó",
                        Image = "salad.jpg"
                    });
                    connection.Insert(new Food
                    {
                        Id = 4,
                        Name = "Hamburger",
                        Ingredients = "- Bông cải xanh cắt thành từng bông nhỏ\n" +
                                "- Bắp cải tím bào mỏng\n" +
                                "- Thịt bò: đập dập, thái miếng mỏng\n" +
                                "- Hải sản\n" +
                                "- Tỏi băm nhuyễn\n" +
                                "- Gia vị: (gợi ý, tùy mức độ ăn cay mà bạn có thể gia giảm gia vị) 2 thìa canh ớt bột Hàn Quốc, 3 thìa canh tương ớt, 1 thìa cafe đường, 1 muỗng hạt nêm\n" +
                                "- Kimchi cắt lát hoặc cắt thành từng miếng vuông nhỏ\n" +
                                "- Mì gói: bạn có thể dùng mì trứng (cho thời gian nấu nhanh hơn) hoặc mì Hàn Quốc (cần thời gian nấu lâu nhưng sẽ chuẩn vị hơn)",
                        Instruction = "- Chần mì qua nước sôi đến khi sợi mì vừa chín\n" +
                                "- Đổ phần nước đó đi. Rồi thêm gói gia vị vào mì, trộn đều. Lưu ý là gói gia vị trong mì thường rất nhiều để làm mì đậm đà. Nhưng bạn chỉ cần dùng 2/3 gói là đã đủ dùng rồi nhé.\n" +
                                "- Cuối cùng cho phần nước sôi mới vào vừa đủ ngập mì. Vậy là bạn đã có thể dùng rồi đó",
                        Image = "hamburger.jpg"
                    });
                }
                connection.CreateTable<Favorite>();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool addbook(book book)
        //{
        //    try
        //    {
        //        string path = system.io.path.combine(folder, "bookstore.db");
        //        var connection = new sqliteconnection(path);
        //        connection.insert(book);
        //        return true;
        //    }
        //    catch
        //    {

        //        return false;
        //    }
        //}

        //public List<Book> GetAllBooks()
        //{
        //    try
        //    {
        //        string path = System.IO.Path.Combine(folder, "bookstore.db");
        //        var connection = new SQLiteConnection(path);
        //        return connection.Table<Book>().ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public bool DeleteOneFavorite(Favorite favorite)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                connection.Delete(favorite);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAllData()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                connection.DeleteAll<Favorite>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool UpdateOnebook(Book book)
        //{
        //    try
        //    {
        //        string path = System.IO.Path.Combine(folder, "bookstore.db");
        //        var connection = new SQLiteConnection(path);
        //        connection.Update(book);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public bool AddFavorite(Favorite favorite)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                var data = connection.Table<Favorite>();

                var d1 = data.Where(x => x.Id == favorite.Id).FirstOrDefault();
                if (d1 == null) connection.Insert(favorite);
                else connection.Update(favorite);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<Favorite> GetFavorite()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Favorite>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Food> GetFood()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Food>().ToList();
            }
            catch
            {
                return null;
            }
        }

        //public bool DeleteItemFavorite(Favorite favorite)
        //{
        //    try
        //    {
        //        string path = System.IO.Path.Combine(folder, "monanngon.db");
        //        var connection = new SQLiteConnection(path);
        //        connection.Delete(favorite);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public List<Food> GetOneFood(int foodId)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                List<Food> abc = connection.Query<Food>("select * from Food where id = ?", foodId);
                return abc;
            }
            catch
            {
                return null;
            }
        }

        //public bool AddUser(User user)
        //{
        //    try
        //    {
        //        string path = System.IO.Path.Combine(folder, "bookstore.db");
        //        var connection = new SQLiteConnection(path);
        //        connection.Insert(user);
        //        return true;
        //    }
        //    catch
        //    {

        //        return false;
        //    }
        //}

        //public List<User> GetUser()
        //{
        //    try
        //    {
        //        string path = System.IO.Path.Combine(folder, "bookstore.db");
        //        var connection = new SQLiteConnection(path);
        //        return connection.Table<User>().ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
