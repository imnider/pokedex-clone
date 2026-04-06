using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Move;
using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Services
{
    public class MoveService() : IMoveService
    {
        public Task<GenericResponse<MoveDto>> Create(CreateMoveRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<bool>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<List<MoveDto>>> GetAll(FilterMoveRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<MoveDto>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<MoveDto>> Update(Guid id, UpdateMoveRequest model)
        {
            throw new NotImplementedException();
        }

        // Verificar que el movimiento exista

    }
}
