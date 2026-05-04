using Identity.Application.Abstractions.Repositories;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Repositories
{
    public class RefreshTokenReadRepository : ReadRepository<RefreshToken>, IRefreshTokenReadRepository
    {
        private readonly IdentityDbContext _context;
        public RefreshTokenReadRepository(IdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<RefreshToken> Table => _context.Set<RefreshToken>();
    }
}
