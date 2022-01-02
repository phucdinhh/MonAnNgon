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
                connection.CreateTable<Auth>();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public Auth getAuth()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                var data = connection.Table<Auth>();

                var d1 = data.FirstOrDefault();
                if (d1 == null)
                {
                    Auth d2 = new Auth()
                    {
                        Id = 1,
                        IsLoggedIn = false,
                    };
                    connection.Insert(d2);
                    return d2;
                }

                return d1;
            }
            catch (Exception e)
            {

                App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                return new Auth() { IsLoggedIn = false };
            }
        }

        public bool AddAuth(Auth auth)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                var data = connection.Table<Auth>();

                var d1 = data.Where(x => x.Id == auth.Id).FirstOrDefault();
                if (d1 == null) connection.Insert(auth);
                else connection.Update(auth);
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool DeleteAuth()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                var data = connection.Table<Auth>();
                Auth auth = data.FirstOrDefault();
                connection.Delete(auth);
                return true;
            }
            catch
            {
                return false;
            }
        }

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

        public bool CheckFavorite(long foodId)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "monanngon.db");
                var connection = new SQLiteConnection(path);
                var abc = connection.Table<Favorite>().Where(x => x.Id == foodId).Count();
                if (abc != 0) return true;
                else return false;
            }
            catch
            {
                return false;
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
