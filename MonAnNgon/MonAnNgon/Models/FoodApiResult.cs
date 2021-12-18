using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    class FoodApiResult
    {
        [JsonProperty("results")]
        public Food[] Results { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
