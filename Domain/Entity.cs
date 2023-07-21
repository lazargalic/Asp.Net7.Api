using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        //public string? LastUpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        //public string? LastDeletedBy { get; set; }

    }
}
