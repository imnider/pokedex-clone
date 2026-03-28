using PokedexClone.Application.Helpers;
using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Pokemon;
using PokedexClone.Application.Models.Responses;
using PokedexClone.Shared;

namespace PokedexClone.Application.Services
{
    public class PokemonService(Cache<PokemonDto> cache) : IPokemonService
    {
        public GenericResponse<PokemonDto> Create(CreatePokemonRequest model)
        {
            var pokemon = new PokemonDto
            {
                EvolutionChainID = model.EvolutionChainID,
                DisplayName = model.DisplayName,
                Description = model.Description,
                Generation = model.Generation,
                HP = model.HP,
                Attack = model.Attack,
                Defense = model.Defense,
                SpecialAttack = model.SpecialAttack,
                SpecialDefense = model.SpecialDefense,
                Speed = model.Speed
            };

            // Colocar el ID automáticamente
            var pokemons = cache.Get();
            if (pokemons == null || !pokemons.Any())
            {
                pokemon.PokemonID = 1;
            }
            else
            {
                int maxId = pokemons.Max(p => p.PokemonID);
                pokemon.PokemonID = maxId += 1;
            }

            cache.Add(pokemon.PokemonID.ToString(), pokemon);
            return ResponsesHelper.Create(pokemon, "Pokemon registrado exitosamente.");
        }

        public GenericResponse<PokemonDto> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<List<PokemonDto>> GetAll(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<PokemonDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
