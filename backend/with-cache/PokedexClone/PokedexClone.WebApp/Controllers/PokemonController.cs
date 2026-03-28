using Microsoft.AspNetCore.Mvc;
using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.Requests.Pokemon;

namespace PokedexClone.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController(IPokemonService pokemonService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePokemonRequest model)
        {
            var rsp = pokemonService.Create(model);
            return Ok(rsp);
        }
    }
}
