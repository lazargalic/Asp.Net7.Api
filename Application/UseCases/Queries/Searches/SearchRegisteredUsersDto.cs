using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Searches
{
    public class SearchRegisteredUsersDto
    {
        public string? Keyword { get; set; }
        public bool? IsActive { get; set; }
        public int? UseCaseId { get; set; }
    }
}
