using PokedexClone.Application.Helpers;
using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Models.Requests.Pokemon;
using PokedexClone.Application.Models.Responses;
using PokedexClone.Domain.Database.SqlServer.Entities;
using PokedexClone.Domain.Exceptions;
using PokedexClone.Domain.Interfaces.Repositories;
using PokedexClone.Shared.Constants;

namespace PokedexClone.Application.Services
{
    public class PokemonService(IPokemonRepository repository) : IPokemonService
    {
        public async Task<GenericResponse<PokemonDto>> Create(CreatePokemonRequest model)
        {
            var create = await repository.Create(new Pokemon
            {
                EvolutionChainId = model.EvolutionChainID,
                DisplayName = model.DisplayName,
                Description = model.Description,
                Generation = model.Generation,
                Hp = model.HP,
                Attack = model.Attack,
                Defense = model.Defense,
                SpecialAttack = model.SpecialAttack,
                SpecialDefense = model.SpecialDefense,
                Speed = model.Speed
            });
            // Mapear para el id
            return ResponsesHelper.Create(Map(create), "Pokemon creado correctamente.");
        }

        public async Task<GenericResponse<PokemonDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponse<List<PokemonDto>>> GetAll(FilterPokemonRequest model)
        {
            var queryable = repository.Queryable();

            // Filtros
            if (!string.IsNullOrWhiteSpace(model.DisplayName))
            {
                queryable = queryable.Where(x => x.DisplayName.Contains(model.DisplayName ?? ""));
            }

            // Paginación
            var pokemons = queryable.Skip(model.Offset).Take(model.Limit).ToList();

            // Mapeo
            List<PokemonDto> mapped = [];
            foreach (var pokemon in pokemons)
            {
                mapped.Add(Map(pokemon));
            }

            return ResponsesHelper.Create(mapped);
        }

        public async Task<GenericResponse<PokemonDto>> GetById(int id)
        {
            var pokemon = await GetPokemon(id);
            return ResponsesHelper.Create(Map(pokemon));
        }

        public async Task<GenericResponse<PokemonDto>> Update(int id, UpdatePokemonRequest model)
        {
            throw new NotImplementedException();
        }

        // Verificar que el pokemon exista
        private async Task<Pokemon> GetPokemon(int id)
        {
            return await repository.Get(id)
                ?? throw new NotFoundException(ResponseConstants.POKEMON_NOT_EXISTS);
        }

        // Mapeo a Dto
        private static PokemonDto Map(Pokemon pokemon)
        {
            return new PokemonDto
            {
                PokemonID = pokemon.PokemonId,
                EvolutionChainID = pokemon.EvolutionChainId,
                DisplayName = pokemon.DisplayName,
                Description = pokemon.Description,
                Generation = pokemon.Generation,
                HP = pokemon.Hp,
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                SpecialAttack = pokemon.SpecialAttack,
                SpecialDefense = pokemon.SpecialDefense,
                Speed = pokemon.Speed,
                CreatedAt = pokemon.CreatedAt,
                UpdatedAt = pokemon.UpdatedAt,
                DeletedAt = pokemon.DeletedAt,
            };
        }
    }
}