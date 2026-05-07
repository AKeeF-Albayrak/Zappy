using Identity.Application.Abstractions.Repositories;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Repositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        private readonly IdentityDbContext _context;
        public UserReadRepository(IdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<User> Table => _context.Set<User>();

        public async Task<User> GetUserByLoginConfAsync(string usernameOrEmail, string password, CancellationToken cancellationToken = default)
        {
            return await Table.FirstOrDefaultAsync(u => (u.Username == usernameOrEmail || u.Email == usernameOrEmail) && u.HashedPassword == password, cancellationToken);
        }   
    }
}
