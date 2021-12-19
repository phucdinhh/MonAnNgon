using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class Favorite
    {
        [PrimaryKey]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Instruction { get; set; }

        public string ImageUrl { get; set; }
    }
}
