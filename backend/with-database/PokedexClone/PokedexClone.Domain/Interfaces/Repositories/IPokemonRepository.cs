using PokedexClone.Domain.Database.SqlServer.Entities;

namespace PokedexClone.Domain.Interfaces.Repositories
{
    public interface IPokemonRepository
    {
        public Task<Pokemon> Create(Pokemon pokemon);
        public Task<Pokemon> Get(int id);
        public IQueryable<Pokemon> Queryable();
        public Task<bool> IfExist(int id);
        public Task<bool> IfExist(string DisplayName);
        public Task<Pokemon> Update(Pokemon pokemon);
    }
}
