using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logging
{
    public interface IAuditLogLogger
    {
        void Log(AuditLogDto log);
        
    }

    public class AuditLogDto
    {
        public string UseCaseName { get; set; }
        public string UserIdentity { get; set; }
        public int? UserId { get; set; }
        public string Data { get; set; }
        public bool IsAuthorized { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
