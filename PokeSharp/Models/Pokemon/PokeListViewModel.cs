using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PokeSharp.Models.Pokemon
{
    public class PokeListViewModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public Uri Previous { get; set; }
        public int Amount { get; set; }
        public int CurrentPage { get; set; }

        [JsonProperty("results")]
        public IEnumerable<PokemonViewModel> Pokemons { get; set; }
    }
}
