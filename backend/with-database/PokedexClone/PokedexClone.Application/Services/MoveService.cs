using PokedexClone.Application.Helpers;
using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Move;
using PokedexClone.Application.Models.Responses;
using PokedexClone.Shared;

namespace PokedexClone.Application.Services
{
    public class MoveService(Cache<MoveDto> cache) : IMoveService
    {
        public GenericResponse<MoveDto> Create(CreateMoveRequest model)
        {
            var move = new MoveDto
            {
                MoveID = Guid.NewGuid(),
                TypeID = model.TypeID,
                MoveCategoryID = model.MoveCategoryID,
                DisplayName = model.DisplayName,
                Power = model.Power,
                Accuracy = model.Accuracy,
                MinPP = model.MinPP,
                MaxPP = model.MaxPP,
                Effect = model.Effect
            };
            cache.Add(move.MoveID.ToString(), move);
            return ResponsesHelper.Create(move, "Movimiento creado exitosamente.");
        }

        public GenericResponse<MoveDto> DeleteById(Guid id)
        {
            var move = cache.Get(id.ToString());
            if (move == null) return ResponsesHelper.Create(move, "No se ha encontrado el movimiento.");
            cache.Delete(id.ToString());
            return ResponsesHelper.Create(move, $"Se ha eliminado el movimiento: {move.DisplayName}.");
        }

        public GenericResponse<List<MoveDto>> GetAll(GetAllMoveRequest model)
        {
            var moves = cache.Get();
            if (moves is null || moves.Count == 0)
            {
                return ResponsesHelper.Create(moves, "No se han encontrado movimientos.");
            }
            return ResponsesHelper.Create(moves, $"Se ha encontrado {moves.Count} movimientos.");
        }

        public GenericResponse<MoveDto> GetById(Guid id)
        {
            var move = cache.Get(id.ToString());
            if (move == null) return ResponsesHelper.Create(move, "No se ha encontrado el movimiento.");
            return ResponsesHelper.Create(move, $"Se ha encontrado el movimiento: {move.DisplayName}");
        }

        public GenericResponse<MoveDto> UpdateById(Guid id, UpdateMoveRequest model)
        {
            var move = cache.Get(id.ToString());
            if (move == null) return ResponsesHelper.Create(move, "No se ha encontrado el movimiento.");
            if (model.TypeID is not null) move.TypeID = model.TypeID ?? 0;
            if (model.MoveCategoryID is not null) move.MoveCategoryID = model.MoveCategoryID ?? 0;
            if (model.DisplayName is not null) move.DisplayName = model.DisplayName;
            if (model.Power is not null) move.Power = model.Power ?? 0;
            if (model.Accuracy is not null) move.Accuracy = model.Accuracy ?? 0;
            if (model.MinPP is not null) move.MinPP = model.MinPP ?? 0;
            if (model.MaxPP is not null) move.MaxPP = model.MaxPP ?? 0;
            if (model.Effect is not null) move.Effect = model.Effect;
            cache.Delete(id.ToString());
            cache.Add(move.MoveID.ToString(), move);
            return ResponsesHelper.Create(move, $"Se ha actualizado el movimiento con éxito: {move.DisplayName}.");
        }
    }
}
