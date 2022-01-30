using Newtonsoft.Json;
using System;

namespace PokeSharp.Models.Pokemon
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
