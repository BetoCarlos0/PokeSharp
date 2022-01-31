using Microsoft.AspNetCore.Mvc;
using PokeSharp.Models.Pokemon;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace PokeSharp.Controllers
{
    public class PokemonController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            PokeList pokeList = new PokeList();

            RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon?limit=24&offset=0");
            RestRequest request = new RestRequest();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.ContentLength <= -1 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "Erro!");
            }else{
                pokeList = JsonConvert.DeserializeObject<PokeList>(response.Content);

                string[] imgs = new string[pokeList.Pokemons.Count()];
                int count = 1;
                foreach (var item in pokeList.Pokemons)
                {
                    string temp = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + count + ".png";

                    imgs[count-1] = temp;
                    count++;
                }
                ViewBag.imgUrl = imgs;

                if (!String.IsNullOrEmpty(searchString))
                {
                    pokeList.Pokemons = pokeList.Pokemons.Where(s => s.Name.Contains(searchString));
                }
            }
            return View(pokeList);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var pokemon = new Pokemon();

            return View(pokemon);
        }
    }
}
