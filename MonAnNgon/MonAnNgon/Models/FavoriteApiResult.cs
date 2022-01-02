using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class FavoriteApiResult
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        public string ImageUrl { get; set; }

        [JsonProperty("image")]
        public Media[] Image { get; set; }
    }
}
