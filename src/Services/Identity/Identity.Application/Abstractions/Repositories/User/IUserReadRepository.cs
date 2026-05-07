using Identity.Domain.Entities;
using SharedKernel.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Abstractions.Repositories
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        Task<User> GetUserByLoginConfAsync(string usernameOrEmail, string password, CancellationToken cancellationToken = default);
    }
}
