using Microsoft.EntityFrameworkCore;
using PokedexClone.Domain.Database.SqlServer.Context;
using PokedexClone.Domain.Database.SqlServer.Entities;
using PokedexClone.Domain.Interfaces.Repositories;

namespace PokedexClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class PokemonRepository(PokedexCloneContext context) : IPokemonRepository
    {
        public async Task<Pokemon> Create(Pokemon pokemon)
        {
            try
            {
                await context.Pokemons.AddAsync(pokemon);
                await context.SaveChangesAsync();

                return pokemon;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Pokemon> Get(int id)
        {
            try
            {
                return await context.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id && x.DeletedAt == null);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IfExist(int id)
        {
            try
            {
                return await context.Pokemons.AnyAsync(x => x.PokemonId == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> IfExist(string DisplayName)
        {
            // No implementado todavía
            throw new NotImplementedException();
        }

        public IQueryable<Pokemon> Queryable()
        {
            try
            {
                return context.Pokemons.Where(x => x.DeletedAt == null).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Pokemon> Update(Pokemon pokemon)
        {
            try
            {
                context.Pokemons.Update(pokemon);
                await context.SaveChangesAsync();

                return pokemon;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
