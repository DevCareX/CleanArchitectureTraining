using Microsoft.EntityFrameworkCore;
using Ticket.Application.Contracts.Persistence;

namespace Ticket.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly TicketDbContext _ticketDbContext;

        public BaseRepository(TicketDbContext dbContext)
        {
            _ticketDbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _ticketDbContext.Set<T>().AddAsync(entity);
            await _ticketDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeketeAsync(T entity)
        {
            _ticketDbContext.Set<T>().Remove(entity);
            await _ticketDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _ticketDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _ticketDbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _ticketDbContext.Entry(entity).State = EntityState.Modified;
            await _ticketDbContext.SaveChangesAsync();
        }
    }
}
