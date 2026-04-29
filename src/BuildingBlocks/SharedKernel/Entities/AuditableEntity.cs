using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Entities
{
    public class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
