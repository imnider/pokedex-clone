using Microsoft.EntityFrameworkCore;
using PokedexClone.Domain.Database.SqlServer.Context;
using PokedexClone.Domain.Database.SqlServer.Entities;
using PokedexClone.Domain.Interfaces.Repositories;

namespace PokedexClone.Infrastructure.Persistence.SqlServer.Repositories
{
    public class MoveRepository(PokedexCloneContext context) : IMoveRepository
    {
        public async Task<Move> Create(Move move)
        {
            try
            {
                await context.AddAsync(move);
                await context.SaveChangesAsync();

                return move;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Move> Get(Guid id)
        {
            try
            {
                return await context.Moves.FirstOrDefaultAsync(x => x.MoveId == id && x.DeletedAt == null);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IfExist(Guid id)
        {
            try
            {
                return await context.Moves.AnyAsync(x => x.MoveId == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Move> Queryable()
        {
            try
            {
                return context.Moves.Where(x => x.DeletedAt == null).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Move> Update(Move move)
        {
            try
            {
                context.Moves.Update(move);
                await context.SaveChangesAsync();

                return move;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
