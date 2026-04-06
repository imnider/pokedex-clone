using Microsoft.AspNetCore.Mvc;
using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.Requests.Move;

namespace PokedexClone.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController(IMoveService moveService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMoveRequest model)
        {
            var rsp = await moveService.Create(model);
            return Ok(rsp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterMoveRequest model)
        {
            var rsp = await moveService.GetAll(model);
            return Ok(rsp);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = await moveService.GetById(id);
            return Ok(rsp);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rsp = await moveService.Delete(id);
            return Ok(rsp);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateMoveRequest model)
        {
            var rsp = await moveService.Update(id, model);
            return Ok(rsp);
        }

    }
}
