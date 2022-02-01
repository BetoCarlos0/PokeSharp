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
        public async Task<IActionResult> Index(string searchString, string offset, int? page)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["Offset"] = offset;

            if(page == null)
            {
                ViewBag.Page = 0;
            }else
            {
                ViewBag.Page = page;
            }
            

            //ViewBag.PageNum = pageNum ? pageNum : "";

            PokeListViewModel pokeList = new PokeListViewModel();

            if (!String.IsNullOrEmpty(searchString))
            {
                RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon?limit=1118&offset=0");
                RestRequest request = new RestRequest();
                RestResponse response = await client.ExecuteAsync(request);
                if (response.ContentLength <= -1 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ModelState.AddModelError("", "Erro!");
                }
                else
                {
                    pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(response.Content);
                }

                pokeList.Pokemons = pokeList.Pokemons.Where(s => s.Name.Contains(searchString));
            }
            else
            {
                RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon?offset=0&limit=24");
                RestRequest request = new RestRequest();
                RestResponse response = await client.ExecuteAsync(request);

                ViewBag.teste = response.Content;
                JObject o = JObject.Parse(response.Content);
                string productName = (string)o.SelectToken("results[0].name");
                ViewBag.teste2 = productName;

                if (response.ContentLength <= -1 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ModelState.AddModelError("", "Erro!");
                }
                else
                {
                    pokeList = JsonConvert.DeserializeObject<PokeListViewModel>(response.Content);
                }
            }

            //ViewBag.Id = GetId();

            string[] imgs = new string[pokeList.Pokemons.Count()];
            int count = 1;
            foreach (var item in pokeList.Pokemons)
            {
                string temp = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + count + ".png";

                imgs[count - 1] = temp;
                count++;
            }
            ViewBag.imgUrl = imgs;

            return View(pokeList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var pokemon = new PokemonViewModel();

            return View(pokemon);
        }

        /*public void GetId()
        {
            return ViewBag.id;  
        }*/
    }
}
