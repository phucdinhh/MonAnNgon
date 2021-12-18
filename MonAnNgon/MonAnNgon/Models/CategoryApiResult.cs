using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    class CategoryApiResult
    {
        [JsonProperty("results")]
        public CategoryExample[] Results { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
