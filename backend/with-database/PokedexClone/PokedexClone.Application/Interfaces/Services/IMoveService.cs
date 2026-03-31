using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Move;
using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Interfaces.Services
{
    public interface IMoveService
    {
        public GenericResponse<MoveDto> Create(CreateMoveRequest model);
        public GenericResponse<List<MoveDto>> GetAll(GetAllMoveRequest model);
        public GenericResponse<MoveDto> GetById(Guid id);
        public GenericResponse<MoveDto> DeleteById(Guid id);
        public GenericResponse<MoveDto> UpdateById(Guid id, UpdateMoveRequest model);
    }
}
