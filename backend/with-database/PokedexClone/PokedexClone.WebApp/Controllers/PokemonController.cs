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
            var rsp = await pokemonService.Create(model);
            return Ok(rsp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterPokemonRequest model)
        {
            var rsp = await pokemonService.GetAll(model);
            return Ok(rsp);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rsp = await pokemonService.GetById(id);
            return Ok(rsp);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var rsp = await pokemonService.Delete(id);
            return Ok(rsp);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdatePokemonRequest model)
        {
            var rsp = await pokemonService.Update(id, model);
            return Ok(rsp);
        }
    }
}
