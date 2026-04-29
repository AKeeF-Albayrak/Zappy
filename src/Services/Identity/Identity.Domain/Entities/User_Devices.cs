using Identity.Domain.Enums;
using SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Entities
{
    public class User_Devices : BaseEntity
    {
        public Guid UserId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public Platforms Platform { get; set; }
        public DateTime LastLoginAt { get; set; }

        public User User { get; set; }
    }
}
