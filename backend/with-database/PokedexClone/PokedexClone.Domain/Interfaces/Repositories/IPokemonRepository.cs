using PokedexClone.Domain.Database.SqlServer.Entities;

namespace PokedexClone.Domain.Interfaces.Repositories
{
    public interface IPokemonRepository
    {
        public Task<Pokemon> Create(Pokemon pokemon);
        public Task<Pokemon> Get(int id);
        IQueryable<Pokemon> Queryable();
        Task<bool> IfExist(int id);
        Task<bool> IfExist(string DisplayName);
        Task<Pokemon> Update(Pokemon pokemon);
    }
}
