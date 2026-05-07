using Identity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Entities;
using SharedKernel.Repositories.Interface;

namespace Identity.Infrastructure.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly IdentityDbContext _context;

    public WriteRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Table.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Table.AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        Table.UpdateRange(entities);
    }

    public void Remove(T entity)
    {
        Table.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        Table.RemoveRange(entities);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}