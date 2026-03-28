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

        public GenericResponse<PokemonDto> UpdateById(int id, UpdatePokemonRequest model)
        {
            var pokemon = cache.Get(id.ToString());
            if (pokemon is null)
            {
                return ResponsesHelper.Create(pokemon, "No se ha encontrado al Pokemon.");
            }
            if (model.PokemonID != null) pokemon.PokemonID = model.PokemonID ?? 0;
            if (model.EvolutionChainID != null) pokemon.EvolutionChainID = model.EvolutionChainID ?? Guid.NewGuid();
            if (model.DisplayName != null) pokemon.DisplayName = model.DisplayName;
            if (model.Description != null) pokemon.Description = model.Description;
            if (model.Generation != null) pokemon.Generation = model.Generation ?? 0;
            if (model.HP != null) pokemon.HP = model.HP ?? 0;
            if (model.Attack != null) pokemon.Attack = model.Attack ?? 0;
            if (model.Defense != null) pokemon.Defense = model.Defense ?? 0;
            if (model.SpecialAttack != null) pokemon.SpecialAttack = model.SpecialAttack ?? 0;
            if (model.SpecialDefense != null) pokemon.SpecialDefense = model.SpecialDefense ?? 0;
            if (model.Speed != null) pokemon.Speed = model.Speed ?? 0;
            cache.Delete(id.ToString());
            cache.Add(pokemon.PokemonID.ToString(), pokemon);
            return ResponsesHelper.Create(pokemon, $"Pokemon modificado con éxito: {pokemon.DisplayName}");
        }
    }
}