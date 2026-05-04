using Identity.Application.Abstractions.Repositories;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Repositories
{
    public class UserDeviceWriteRepository : WriteRepository<UserDevice>, IUserDeviceWriteRepository
    {
        private readonly IdentityDbContext _context;
        public UserDeviceWriteRepository(IdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<UserDevice> Table => _context.Set<UserDevice>();
    }
}
