using PokeSharp.Models.Pokemon;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeSharp.Services
{
    public interface IPokemonService
    {
        [Get("/pokemon?offset=0&limit=36")]
        Task<List<PokeListViewModel>> List();
    }
}
