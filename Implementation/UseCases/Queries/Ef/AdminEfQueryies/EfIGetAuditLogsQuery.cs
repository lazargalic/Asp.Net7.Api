using Application.Logging;
using Application.UseCases.Queries.AdminQueries;
using Application.UseCases.Queries.Searches;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef.AdminEfQueryies
{
    public class EfIGetAuditLogsQuery : EfUseCase, IGetAuditLogs
    {
        public EfIGetAuditLogsQuery(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Dohvati Logove";

        public string Description => "";

        public IEnumerable<AuditLogDto> Execute(AuditLogsSearch search)
        {

            var query = Context.AuditLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.Contains(search.UseCaseName));
            }

            if (!string.IsNullOrEmpty(search.UserIdentity))
            {
                query = query.Where(x => x.UserIdentity.Contains(search.UserIdentity));
            }

            if (search.IsAuthorized != null)
            {
                query = query.Where(x => x.IsAuthorized == search.IsAuthorized);
            }

            if (search.Begin != null)
            {
                query = query.Where(x => x.CreatedTime > search.Begin);
            }

            if (search.End != null)
            {
                query = query.Where(x => x.CreatedTime < search.End);
            }


            var results = query.Select(x => new AuditLogDto
            {
                Data = x.Data,
                UseCaseName = x.UseCaseName,
                CreatedTime = x.CreatedTime,
                IsAuthorized = x.IsAuthorized,
                UserId = x.UserId,
                UserIdentity = x.UserIdentity,
            }).ToList();

            return results;

        }
    }
}
