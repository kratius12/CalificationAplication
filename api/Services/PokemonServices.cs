using api.Models;

namespace api.Services
{
    public class PokemonServices
    {
        private readonly HttpClient _httpClient;
        public PokemonServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            var response = await _httpClient.GetFromJsonAsync<PokemonApiResponse>("https://rickandmortyapi.com/api/character/");
            return response.Results;
        }
        public class PokemonApiResponse
        {
            public IEnumerable<Pokemon> Results { get; set;}
        }
    }
}
