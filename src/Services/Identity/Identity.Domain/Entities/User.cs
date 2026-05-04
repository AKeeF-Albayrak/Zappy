using SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public List<RefreshToken> Tokens { get; set; }
        public List<UserDevices> Devices { get; set; }
    }
}
