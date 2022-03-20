using PokeSharp.Models.Pokemon;
using Refit;
using System.Threading.Tasks;

namespace PokeSharp.Services
{
    public interface IPokemonService
    {
        [Get("/pokemon?offset={page}&limit=36")]
        Task<PokeListViewModel> List(int page);
        
        [Get("/pokemon?offset=0&limit=118")]
        Task<PokeListViewModel> ListAll();

        [Get("/pokemon/{id}")]
        Task<PokemonViewModel> GetId(int id);

        [Get("/pokemon/{name}")]
        Task<PokemonViewModel> GetName(string name);

    }
}
