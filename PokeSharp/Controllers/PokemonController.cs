using Microsoft.AspNetCore.Mvc;
using PokeSharp.Models.Pokemon;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace PokeSharp.Controllers
{
    public class PokemonController : Controller
    {
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            int limit = 24;

            ViewData["CurrentFilter"] = searchString;
            string UrlBase = "https://pokeapi.co/api/v2/";

            PokeListViewModel pokeList = new PokeListViewModel();

            if (page == null)
            {
                page = 0;
            }
            else
            {
                page -= 1;
            }

            if(page * limit > 898)
            {

            }

            if (!String.IsNullOrEmpty(searchString))
            {
                pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(await GetRresponse(UrlBase +"pokemon?limit=1118&offset=0"));

                pokeList.Pokemons = pokeList.Pokemons.Where(s => s.Name.Contains(searchString));


            }
            else
            {
                pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(await GetRresponse(UrlBase + "pokemon?offset=" + page * limit +"&limit="+ limit));
            }

            string[] imgs = new string[pokeList.Pokemons.Count()];
            int count = ((int)page * limit);
            foreach (var item in pokeList.Pokemons)
            {
                item.Img = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + ++count + ".png");
                item.Id = count;
            }
            ViewBag.Page = page + 1;
            return View(pokeList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var pokemon = new PokemonViewModel();

            return View(pokemon);
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
