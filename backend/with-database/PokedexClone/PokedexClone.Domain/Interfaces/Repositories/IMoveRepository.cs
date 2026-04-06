using PokedexClone.Domain.Database.SqlServer.Entities;

namespace PokedexClone.Domain.Interfaces.Repositories
{
    public interface IMoveRepository
    {
        public Task<Move> Create(Move move);

    }
}
