using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Searches
{
    public class AuditLogsSearch
    {
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
        public string? UseCaseName { get; set; }
        public string? UserIdentity { get; set; }
        public bool? IsAuthorized { get; set; }
    }
}
