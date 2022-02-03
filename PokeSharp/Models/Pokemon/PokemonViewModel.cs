using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PokeSharp.Models.Pokemon
{
    public class PokemonViewModel
    {
        [JsonProperty("abilities")]
        public IEnumerable<AbilitiesViewModel> Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExp { get; set;}

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("front_default")]
        public string Img { get; set; }

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
