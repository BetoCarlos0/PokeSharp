using PokeSharp.Models.Pokemon;
using Refit;
using System.Threading.Tasks;

namespace PokeSharp.Services
{
    public interface IPokeListServices
    {
        [Get("pokemon?offset={id}&limit=24")]
        Task<PokeListViewModel> List([AliasAs("id")] int groupId);
    }
}
