using Newtonsoft.Json;
using System;

namespace PokeSharp.Models.Pokemon
{
    public class PokemonViewModel
    {
        [JsonProperty("base_experience")]
        public int BaseExp { get; set;}

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("front_default")]
        public Uri Img { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("wight")]
        public int Weight { get; set; }
    }
}
