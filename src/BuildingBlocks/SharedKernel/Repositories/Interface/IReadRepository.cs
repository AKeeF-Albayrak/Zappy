using SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SharedKernel.Repositories.Interface
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
    }
}
