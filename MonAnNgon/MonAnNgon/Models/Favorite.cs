using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class Favorite
    {
        [PrimaryKey, AutoIncrement]
        public int FavorId { get; set; }
        public int Id { get; set; }
    }
}
