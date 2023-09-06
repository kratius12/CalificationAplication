using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonServices _pokemonServices;
        public PokemonController(PokemonServices pokemonServices)
        {
            _pokemonServices = pokemonServices;
        }
        [HttpGet]
        public async Task<IActionResult>Index () 
        {
            var pokemons = await _pokemonServices.GetPokemons ();
            return View(pokemons);
        }

    }
}
