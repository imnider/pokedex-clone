using PokedexClone.Domain.Database.SqlServer.Entities;

namespace PokedexClone.Domain.Interfaces.Repositories
{
    public interface IMoveRepository
    {
        public Task<Move> Create(Move move);
        public Task<Move> Get(Guid id);
        public IQueryable<Move> Queryable();
        public Task<bool> IfExist(Guid id);
        public Task<Move> Update(Move move);
    }
}
