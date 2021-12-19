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

        public Favorite GetOneFavorite(long foodId)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Favorite>().Where(x => x.Id == foodId).FirstOrDefault();
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
