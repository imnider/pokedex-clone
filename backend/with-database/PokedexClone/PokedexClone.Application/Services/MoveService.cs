using PokedexClone.Application.Helpers;
using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Move;
using PokedexClone.Application.Models.Responses;
using PokedexClone.Domain.Database.SqlServer.Entities;
using PokedexClone.Domain.Exceptions;
using PokedexClone.Domain.Interfaces.Repositories;
using PokedexClone.Shared.Constants;
using PokedexClone.Shared.Helpers;

namespace PokedexClone.Application.Services
{
    public class MoveService(IMoveRepository repository) : IMoveService
    {
        public async Task<GenericResponse<MoveDto>> Create(CreateMoveRequest model)
        {
            var create = await repository.Create(new Move
            {
                MoveId = Guid.NewGuid(),
                TypeId = model.TypeID,
                MoveCategoryId = model.MoveCategoryID,
                DisplayName = model.DisplayName,
                Power = model.Power,
                Accuracy = model.Accuracy,
                MinPp = model.MinPP,
                MaxPp = model.MaxPP,
                Effect = model.Effect,
            });

            return ResponsesHelper.Create(Map(create));
        }

        public async Task<GenericResponse<bool>> Delete(Guid id)
        {
            var move = await GetMove(id);
            move.DeletedAt = DateTimeHelper.UtcNow();

            await repository.Update(move);
            return ResponsesHelper.Create(true);
        }

        public async Task<GenericResponse<List<MoveDto>>> GetAll(FilterMoveRequest model)
        {
            var queryable = repository.Queryable();

            // Filtros
            if (model.Power is not null)
            {
                queryable = queryable.Where(x => x.Power == model.Power);
            }

            // Paginación
            var moves = queryable.Skip(model.Offset).Take(model.Limit).ToList();

            //Mapeo
            List<MoveDto> mapped = [];
            foreach (var move in moves)
            {
                mapped.Add(Map(move));
            }

            return ResponsesHelper.Create(mapped);
        }

        public async Task<GenericResponse<MoveDto>> GetById(Guid id)
        {
            var move = await GetMove(id);
            return ResponsesHelper.Create(Map(move));
        }

        public async Task<GenericResponse<MoveDto>> Update(Guid id, UpdateMoveRequest model)
        {
            var move = await GetMove(id);

            move.TypeId = model.TypeID ?? move.TypeId;
            move.MoveCategoryId = model.MoveCategoryID ?? move.MoveCategoryId;
            move.DisplayName = model.DisplayName ?? move.DisplayName;
            move.Power = model.Power ?? move.Power;
            move.Accuracy = model.Accuracy ?? move.Accuracy;
            move.MinPp = model.MinPP ?? move.MinPp;
            move.MaxPp = model.MaxPP ?? move.MaxPp;
            move.Effect = model.Effect ?? move.Effect;

            move.UpdatedAt = DateTimeHelper.UtcNow();

            var update = await repository.Update(move);
            return ResponsesHelper.Create(Map(move));
        }

        // Verificar que el movimiento exista
        private async Task<Move> GetMove(Guid id)
        {
            return await repository.Get(id)
                ?? throw new NotFoundException(ResponseConstants.MOVE_NOT_EXISTS);
        }

        // Mapeo a Dto
        private static MoveDto Map(Move move)
        {
            return new MoveDto
            {
                MoveID = move.MoveId,
                TypeID = move.TypeId,
                MoveCategoryID = move.MoveCategoryId,
                DisplayName = move.DisplayName,
                Power = move.Power,
                Accuracy = move.Accuracy,
                MinPP = move.MinPp,
                MaxPP = move.MaxPp,
                Effect = move.Effect,
                CreatedAt = move.CreatedAt,
                UpdatedAt = move.UpdatedAt,
                DeletedAt = move.DeletedAt
            };
        }
    }
}
