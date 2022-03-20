using Microsoft.AspNetCore.Mvc;
using PokeSharp.Models.Pokemon;
using PokeSharp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PokeSharp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index(string searchString, int page)
        {
            PokeListViewModel pokeList = new PokeListViewModel();
            pokeList.Amount = 36;

            if (page != 0) page -= 1;

            if (!String.IsNullOrEmpty(searchString))
            {
                pokeList = await _pokemonService.ListAll();

                pokeList.Pokemons = pokeList.Pokemons.Where(s => s.Name.Contains(searchString));

                foreach (var item in pokeList.Pokemons)
                {
                    var result = await _pokemonService.GetName(item.Name);

                    item.Id = result.Id;
                    item.Img = result.Sprites.Other.OfficialArtwork.FrontDefault;
                }

                ViewBag.Hidden = "d-none";

                return View(pokeList);
            }
            else
            {
                pokeList = await _pokemonService.List(page * pokeList.Amount);

                int count = (int)page * pokeList.Pokemons.Count();
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
            pokeList.CurrentPage = (int)(page + 1);

            return View(pokeList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _pokemonService.GetId(id);
            
            return View(result);
        }
    }
}
