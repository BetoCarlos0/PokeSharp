using Microsoft.AspNetCore.Mvc;
using PokeSharp.Models.Pokemon;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace PokeSharp.Controllers
{
    public class PokemonController : Controller
    {
        string UrlBase = "https://pokeapi.co/api/v2/";
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            int limit = 36;
            ViewBag.limit = limit;
            ViewData["CurrentFilter"] = searchString;

            PokeListViewModel pokeList = new PokeListViewModel();

            page = (page == null) ? 0 : (page - 1);

            if (!String.IsNullOrEmpty(searchString))
            {
                pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(await GetRresponse(UrlBase +"pokemon?limit=1118&offset=0"));

                pokeList.Pokemons = pokeList.Pokemons.Where(s => s.Name.Contains(searchString));

                pokeList = await GetImageSr(pokeList);

                ViewBag.Hidden = "d-none";

                return View(pokeList);
            }
            else
            {
                pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(await GetRresponse(UrlBase + "pokemon?offset=" + page * limit + "&limit=" + limit));

                int count = (int)page * limit;
                int skip = 9102 + count;
                foreach (var item in pokeList.Pokemons)
                {
                    if (count < 898)
                    {
                        item.Img = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + ++count + ".png";
                        item.Id = count;
                        ++skip;
                    }
                    else
                    {
                        item.Img = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + ++skip + ".png";
                        item.Id = skip;
                    }
                }
            }
            
            ViewBag.Page = page + 1;

            return View(pokeList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            PokemonViewModel pokemon = new PokemonViewModel();

            pokemon = JsonConvert.DeserializeObject<PokemonViewModel>(await GetRresponse(UrlBase + "pokemon/" + id));

            return View(pokemon);
        }
        public async Task<PokeListViewModel> GetImageSr(PokeListViewModel pokemon)
        {
            foreach (var item in pokemon.Pokemons)
            {
                string response = await GetRresponse("https://pokeapi.co/api/v2/pokemon/" + item.Name);

                item.Img = GetImageUrl(response);
                item.Id = GetIdPoke(response);
            }

            string GetImageUrl(string response)
            {
                JObject jsonO = JObject.Parse(response);
                string json = (string)jsonO.SelectToken("sprites.other.official-artwork.front_default");
                
                return json;
            }

            int GetIdPoke(string response)
            {
                JObject jsonO = JObject.Parse(response);
                int json = (int)jsonO.SelectToken("id");

                return json;
            }
            return pokemon;
        }

        public async Task<string> GetRresponse(string url)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.ContentLength <= -1 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "Erro!");
            }

            return response.Content;  
        }
    }
}
