using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Pokemon;
using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        public GenericResponse<PokemonDto> Create(CreatePokemonRequest model);
        public GenericResponse<List<PokemonDto>> GetAll(GetAllPokemonRequest model);
        public GenericResponse<PokemonDto> GetById(int id);
        public GenericResponse<PokemonDto> DeleteById(int id);
        public GenericResponse<PokemonDto> UpdateById(int id, UpdatePokemonRequest model);
    }
}
