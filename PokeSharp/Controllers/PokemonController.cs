using Microsoft.AspNetCore.Mvc;
using PokeSharp.Models.Pokemon;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using PokeSharp.Services;

namespace PokeSharp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokeListServices _pokeListServices;

        public PokemonController(IPokeListServices iPokeListServices)
        {
            _pokeListServices = iPokeListServices;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            //PokeListViewModel pokeList = new PokeListViewModel();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon?limit=1118&offset=0");
            //    RestRequest request = new RestRequest();
            //    RestResponse response = await client.ExecuteAsync(request);
            //    if (response.ContentLength <= -1 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //    {
            //        ModelState.AddModelError("", "Erro!");
            //    }
            //    else
            //    {
            //        pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(response.Content);
            //    }

            //    pokeList.Pokemons = pokeList.Pokemons.Where(s => s.Name.Contains(searchString));
            //}
            //else
            //{
            //    RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon?offset=0&limit=24");
            //    RestRequest request = new RestRequest();
            //    RestResponse response = await client.ExecuteAsync(request);

            //    ViewBag.teste = response.Content;
            //    JObject o = JObject.Parse(response.Content);
            //    string productName = (string)o.SelectToken("results[0].name");
            //    ViewBag.teste2 = productName;

            //    if (response.ContentLength <= -1 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //    {
            //        ModelState.AddModelError("", "Erro!");
            //    }
            //    else
            //    {
            //        pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(response.Content);
            //    }
            //}

            //string[] imgs = new string[pokeList.Pokemons.Count()];
            //int count = 1;
            //foreach (var item in pokeList.Pokemons)
            //{
            //    string temp = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + count + ".png";

            //    imgs[count - 1] = temp;
            //    count++;
            //}
            //ViewBag.imgUrl = imgs;
            var pokeList = await _pokeListServices.List();

            return View(pokeList);
            //return View(pokeList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var pokemon = new PokemonViewModel();

            return View(pokemon);
        }
    }
}
