using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Move;
using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Services
{
    public class MoveService() : IMoveService
    {
        public GenericResponse<MoveDto> Create(CreateMoveRequest model)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<MoveDto> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<List<MoveDto>> GetAll(GetAllMoveRequest model)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<MoveDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<MoveDto> UpdateById(Guid id, UpdateMoveRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
