using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class CategoryExample
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("foodCount")]
        public object FoodCount { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
