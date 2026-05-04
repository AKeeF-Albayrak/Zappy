using Identity.Application.Abstractions.Repositories;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Repositories
{
    public class RefreshTokenWriteRepository : WriteRepository<RefreshToken>, IRefreshTokenWriteRepository
    {
        private readonly IdentityDbContext _context;
        public RefreshTokenWriteRepository(IdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<RefreshToken> Table => _context.Set<RefreshToken>();
    }
}
