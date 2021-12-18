using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonAnNgon.Models
{
    public class Media
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public Uri Name { get; set; }

        [JsonProperty("alternativeText")]
        public Uri AlternativeText { get; set; }

        [JsonProperty("caption")]
        public Uri Caption { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("formats")]
        public Formats Formats { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("ext")]
        public string Ext { get; set; }

        [JsonProperty("mime")]
        public string Mime { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("previewUrl")]
        public object PreviewUrl { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("provider_metadata")]
        public object ProviderMetadata { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class Formats
    {
        [JsonProperty("small")]
        public Format Small { get; set; }

        [JsonProperty("thumbnail")]
        public Format Thumbnail { get; set; }
    }

    public class Format
    {
        [JsonProperty("ext")]
        public string Ext { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("mime")]
        public string Mime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public object Path { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}
