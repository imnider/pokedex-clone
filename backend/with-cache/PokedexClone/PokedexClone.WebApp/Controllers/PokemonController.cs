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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPokemonRequest model)
        {
            var rsp = pokemonService.GetAll(model.Limit ?? 0, model.Offset ?? 0);
            return Ok(rsp);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rsp = pokemonService.GetById(id);
            return Ok(rsp);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var rsp = pokemonService.DeleteById(id);
            return Ok(rsp);
        }
    }
}
