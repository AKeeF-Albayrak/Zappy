using Identity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Entities;
using SharedKernel.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Identity.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly IdentityDbContext _context;

        public ReadRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        // Helpers: keep queries fast by default
        private IQueryable<T> Query(bool tracking = false)
            => tracking ? Table.AsQueryable() : Table.AsNoTracking();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var q = Query();
            if (predicate is not null)
                q = q.Where(predicate);

            return await q.CountAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await Query().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await Query()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query().FirstOrDefaultAsync(predicate);
        }

        public async Task<IReadOnlyList<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query().Where(predicate).ToListAsync();
        }
    }
}
