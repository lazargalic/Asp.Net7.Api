using Application.Logging;
using Application.UseCases;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class EfAuditLogLogger : IAuditLogLogger
    {

        private Asp2023DbContext _context;

        public EfAuditLogLogger(Asp2023DbContext context)
        {
            _context = context;
        }

        public void Log(AuditLogDto log)
        {
            _context.AuditLogs.Add( new  Domain.AuditLog
            {
                UseCaseName=log.UseCaseName,
                IsAuthorized=log.IsAuthorized,
                UserId=log.UserId,
                UserIdentity=log.UserIdentity,
                Data=log.Data,
                CreatedTime=log.CreatedTime
            });

            _context.SaveChanges();
        }
    }
}
