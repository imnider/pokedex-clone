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
            return ResponsesHelper.Create(pokemon, "Pokémon registrado exitosamente.");
        }

        public GenericResponse<PokemonDto> DeleteById(int id)
        {
            var pokemon = cache.Get(id.ToString());
            if (pokemon is null)
            {
                return ResponsesHelper.Create(pokemon, "No se ha encontrado al Pokemon.");
            }
            cache.Delete(id.ToString());
            return ResponsesHelper.Create(pokemon, $"Pokemon eliminado exitosamente: {pokemon.DisplayName}");
        }

        public GenericResponse<List<PokemonDto>> GetAll(GetAllPokemonRequest model)
        {
            var pokemons = cache.Get();
            if (pokemons is null || !pokemons.Any())
            {
                return ResponsesHelper.Create(pokemons, "No se han encontrado Pokémon.");
            }
            else
            {
                int pokemonCount = pokemons.Count;
                return ResponsesHelper.Create(pokemons, $"Se han encontrado {pokemonCount} Pokémon.");
            }
        }

        public GenericResponse<PokemonDto> GetById(int id)
        {
            var pokemon = cache.Get(id.ToString());
            if (pokemon is null)
            {
                return ResponsesHelper.Create(pokemon, "No se ha encontrado al Pokemon.");
            }
            return ResponsesHelper.Create(pokemon, $"Pokemon encontrado con éxito: {pokemon.DisplayName}.");
        }


    }
}
