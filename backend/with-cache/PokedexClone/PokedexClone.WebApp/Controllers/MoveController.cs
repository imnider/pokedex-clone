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
            var rsp = moveService.Create(model);
            return Ok(rsp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMoveRequest model)
        {
            var rsp = moveService.GetAll(model);
            return Ok(rsp);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = moveService.GetById(id);
            return Ok(rsp);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var rsp = moveService.DeleteById(id);
            return Ok(rsp);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> DeleteById(Guid id, UpdateMoveRequest model)
        {
            var rsp = moveService.UpdateById(id, model);
            return Ok(rsp);
        }

    }
}
