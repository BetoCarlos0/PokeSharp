using System.Threading.Tasks;

namespace PokeSharp.Services
{
    public interface IPokemonService
    {
        public string GetImages(string response);
        int GetIdPoke(string response);
        public Task<string> GetRresponse(string url);
    }
}
