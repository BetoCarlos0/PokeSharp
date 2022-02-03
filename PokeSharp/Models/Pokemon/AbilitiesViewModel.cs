using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeSharp.Models.Pokemon
{
    public class AbilitiesViewModel
    {
        [JsonProperty("ability")]
        public Ability ability { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }

    public class Ability
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
