using Identity.Domain.Entities;
using SharedKernel.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Abstractions.Repositories
{
    public interface IRefreshTokenReadRepository : IReadRepository<RefreshToken>
    {
    }
}
