using SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Entities
{
    public class Refresh_Token : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }
        
        public User User { get; set; }
    }
}
