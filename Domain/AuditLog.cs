using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AuditLog
    {
        public long Id { get;set; }
        public string UseCaseName { get;set; }
        public string UserIdentity { get;set; }
        public int? UserId { get;set; }
        public string Data { get;set; }
        public bool IsAuthorized { get;set; }
        public DateTime CreatedTime { get;set; }
    }
}
