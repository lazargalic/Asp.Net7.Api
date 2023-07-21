﻿using Application.Logging;
using Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.AdminQueries
{
    public interface IGetAuditLogs  : IQuery<AuditLogsSearch, IEnumerable<AuditLogDto>>
    {
    }
}
