using SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Repositories.Interface
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
