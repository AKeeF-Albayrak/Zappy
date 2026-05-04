using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Repositories.Interface
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
