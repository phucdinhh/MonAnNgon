using Newtonsoft.Json;
﻿using SQLite;
using System;
using System.Collections.Generic;

namespace MonAnNgon.Models
{
    public class Food
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("viewCount")]
        public long ViewCount { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("category")]
        public CategoryExample Category { get; set; }

        [JsonProperty("image")]
        public Media[] Image { get; set; }

        public string ImageUrl { get; set; }

    }
}