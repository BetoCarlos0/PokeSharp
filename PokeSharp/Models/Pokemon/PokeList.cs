using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PokeSharp.Models.Pokemon
{
    public class PokeList
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public Uri Previous { get; set; }

        [JsonProperty("results")]
        public IEnumerable<Pokemon> Pokemons { get; set; }
    }
}
