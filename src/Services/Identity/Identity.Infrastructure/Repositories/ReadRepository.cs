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

        private IQueryable<T> Query(bool tracking = false)
            => tracking ? Table.AsQueryable() : Table.AsNoTracking();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Query().AnyAsync(predicate, cancellationToken);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var q = Query();

            if (predicate is not null)
                q = q.Where(predicate);

            return await q.CountAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Query().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Query().FirstOrDefaultAsync( x => x.Id == id, cancellationToken);
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Query().FirstOrDefaultAsync(predicate,cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Query().Where(predicate).ToListAsync(cancellationToken);
        }
    }
}
