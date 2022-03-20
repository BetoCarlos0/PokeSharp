using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokeSharp.Models.Pokemon
{
    public class PokeListViewModel
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public Uri Next { get; set; }

        [JsonPropertyName("previous")]
        public Uri Previous { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<Pokemons> Pokemons { get; set; }

        public int Amount { get; set; }
        public int CurrentPage { get; set; }
    }
    public class Pokemons
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        public string Img { get; set; }

        public int Id { get; set; }
    }
}
