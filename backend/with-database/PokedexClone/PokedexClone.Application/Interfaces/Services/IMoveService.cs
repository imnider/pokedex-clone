using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Move;
using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Interfaces.Services
{
    public interface IMoveService
    {
        public Task<GenericResponse<MoveDto>> Create(CreateMoveRequest model);
        public Task<GenericResponse<List<MoveDto>>> GetAll(FilterMoveRequest model);
        public Task<GenericResponse<MoveDto>> GetById(Guid id);
        public Task<GenericResponse<bool>> Delete(Guid id);
        public Task<GenericResponse<MoveDto>> Update(Guid id, UpdateMoveRequest model);
    }
}
