using Microsoft.AspNetCore.Mvc;
using PokeSharp.Models.Pokemon;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokeSharp.Controllers
{
    public class PokemonController : Controller
    {
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PokeList pokeList = new PokeList();

            RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon?limit=10&offset=0");

            RestRequest request = new RestRequest();

            RestResponse response = await client.ExecuteAsync(request);
            //string output = JsonConvert.SerializeObject(response.Content);


            if(response.ContentLength <= -1 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "Erro!");
            }else{
                pokeList = JsonConvert.DeserializeObject<PokeList>(response.Content);
            }

            return View(pokeList.Pokemons);
        }
    }
}
