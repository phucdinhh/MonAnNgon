using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class Pagination
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("pageSize")]
        public long PageSize { get; set; }

        [JsonProperty("pageCount")]
        public long PageCount { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
