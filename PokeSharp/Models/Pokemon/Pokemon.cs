using Newtonsoft.Json;
using System;

namespace PokeSharp.Models.Pokemon
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("front_default")]
        public Uri Img { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
