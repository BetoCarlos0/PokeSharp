using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PokeSharp.Models.Pokemon
{
    public class PokemonViewModel
    {
        [JsonPropertyName("abilities")]
        public IEnumerable<Abilities> Abilities { get; set; }

        [JsonPropertyName("base_experience")]
        [Display(Name="Base Exp")]
        public int BaseExp { get; set;}

        [JsonPropertyName("forms")]
        public IEnumerable<Species> Forms { get; set; }

        [JsonProperty("game_indices", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<GameIndex> GameIndices { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("held_items")]
        public List<object> HeldItems { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }

        [JsonProperty("moves", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Move> Moves { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("past_types")]
        public IEnumerable<object> PastTypes { get; set; }

        [JsonPropertyName("species")]
        public Species Species { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }

        [JsonPropertyName("stats")]
        public IEnumerable<Stat> Stats { get; set; }

        [JsonPropertyName("types")]
        public IEnumerable<TypeElement> Types { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }
    }

    public class Abilities
    {
        [JsonPropertyName("ability")]
        public Species Ability { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("slot")]
        public long Slot { get; set; }
    }
    public class Species
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
    public class GameIndex
    {
        [JsonPropertyName("game_index")]
        public long GameIndexGameIndex { get; set; }

        [JsonPropertyName("version")]
        public Species Version { get; set; }
    }
    public partial class Move
    {
        [JsonPropertyName("move")]
        public Species MoveMove { get; set; }

        [JsonPropertyName("version_group_details")]
        public IEnumerable<VersionGroupDetail> VersionGroupDetails { get; set; }
    }
    public class VersionGroupDetail
    {
        [JsonPropertyName("level_learned_at")]
        public long LevelLearnedAt { get; set; }

        [JsonPropertyName("move_learn_method")]
        public Species MoveLearnMethod { get; set; }

        [JsonPropertyName("version_group")]
        public Species VersionGroup { get; set; }
    }
    public partial class GenerationV
    {
        [JsonPropertyName("black-white")]
        public Sprites BlackWhite { get; set; }
    }

    public class GenerationIv
    {
        [JsonPropertyName("diamond-pearl")]
        public Sprites DiamondPearl { get; set; }

        [JsonPropertyName("heartgold-soulsilver")]
        public Sprites HeartgoldSoulsilver { get; set; }

        [JsonPropertyName("platinum")]
        public Sprites Platinum { get; set; }
    }

    public class Versions
    {
        [JsonPropertyName("generation-i")]
        public GenerationI GenerationI { get; set; }

        [JsonPropertyName("generation-ii")]
        public GenerationIi GenerationIi { get; set; }

        [JsonPropertyName("generation-iii")]
        public GenerationIii GenerationIii { get; set; }

        [JsonPropertyName("generation-iv")]
        public GenerationIv GenerationIv { get; set; }

        [JsonPropertyName("generation-v")]
        public GenerationV GenerationV { get; set; }

        [JsonPropertyName("generation-vi")]
        public Dictionary<string, Home> GenerationVi { get; set; }

        [JsonPropertyName("generation-vii")]
        public GenerationVii GenerationVii { get; set; }

        [JsonPropertyName("generation-viii")]
        public GenerationViii GenerationViii { get; set; }
    }

    public class Sprites
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_female")]
        public object BackFemale { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_female")]
        public object BackShinyFemale { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }

        [JsonPropertyName("other")]
        public Other Other { get; set; }

        //[JsonIgnore]
        [JsonPropertyName("versions")]
        public Versions Versions { get; set; }

        [JsonPropertyName("animated")]
        public Sprites Animated { get; set; }
    }

    public class GenerationI
    {
        [JsonPropertyName("red-blue")]
        public RedBlue RedBlue { get; set; }

        [JsonPropertyName("yellow")]
        public RedBlue Yellow { get; set; }
    }

    public class RedBlue
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_gray")]
        public string BackGray { get; set; }

        [JsonPropertyName("back_transparent")]
        public string BackTransparent { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_gray")]
        public string FrontGray { get; set; }

        [JsonPropertyName("front_transparent")]
        public string FrontTransparent { get; set; }
    }

    public class GenerationIi
    {
        [JsonPropertyName("crystal")]
        public Crystal Crystal { get; set; }

        [JsonPropertyName("gold")]
        public Gold Gold { get; set; }

        [JsonPropertyName("silver")]
        public Gold Silver { get; set; }
    }

    public class Crystal
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_transparent")]
        public string BackShinyTransparent { get; set; }

        [JsonPropertyName("back_transparent")]
        public string BackTransparent { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_transparent")]
        public string FrontShinyTransparent { get; set; }

        [JsonPropertyName("front_transparent")]
        public string FrontTransparent { get; set; }
    }

    public class Gold
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_transparent")]
        public string FrontTransparent { get; set; }
    }

    public class GenerationIii
    {
        [JsonPropertyName("emerald")]
        public Emerald Emerald { get; set; }

        [JsonPropertyName("firered-leafgreen")]
        public Gold FireredLeafgreen { get; set; }

        [JsonPropertyName("ruby-sapphire")]
        public Gold RubySapphire { get; set; }
    }

    public class Emerald
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class Home
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class GenerationVii
    {
        [JsonPropertyName("icons")]
        public DreamWorld Icons { get; set; }

        [JsonPropertyName("ultra-sun-ultra-moon")]
        public Home UltraSunUltraMoon { get; set; }
    }

    public class DreamWorld
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }
    }

    public class GenerationViii
    {
        [JsonPropertyName("icons")]
        public DreamWorld Icons { get; set; }
    }

    public class Other
    {
        [JsonPropertyName("dream_world")]
        public DreamWorld DreamWorld { get; set; }

        [JsonPropertyName("home")]
        public Home Home { get; set; }

        [JsonPropertyName("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public class OfficialArtwork
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("effort")]
        public int Effort { get; set; }

        [JsonPropertyName("stat")]
        public Species StatStat { get; set; }
    }

    public class TypeElement
    {
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("type")]
        public Species Type { get; set; }
    }
}
