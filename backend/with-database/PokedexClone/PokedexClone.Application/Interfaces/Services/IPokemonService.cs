using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Pokemon;
using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        public Task<GenericResponse<PokemonDto>> Create(CreatePokemonRequest model);
        public Task<GenericResponse<List<PokemonDto>>> GetAll(FilterPokemonRequest model);
        public Task<GenericResponse<PokemonDto>> GetById(int id);
        public Task<GenericResponse<PokemonDto>> Delete(int id);
        public Task<GenericResponse<PokemonDto>> Update(int id, UpdatePokemonRequest model);
    }
}
