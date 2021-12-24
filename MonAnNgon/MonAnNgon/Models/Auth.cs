﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class Auth
    {
        [PrimaryKey]
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Token { get; set; }

        public bool IsLoggedIn { get; set; }
    }
}
