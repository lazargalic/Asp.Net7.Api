using Application;
using Application.Exceptions;
using Application.Logging;
using Application.UseCases;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Implementation.UseCases
{
    public class UseCaseHandler  
    {
        private IApplicationUser _user;
        private IAuditLogLogger _auditLogger;

        public UseCaseHandler(IApplicationUser user, IAuditLogLogger auditLogger)
        {
            _user = user;
            _auditLogger = auditLogger; 
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {

            HandleLoggingAndAuthorization(command, data);
            command.Execute(data);


            bool isAuthorized = _user.Id == 0 ? false : true;
            _auditLogger.Log( new Application.Logging.AuditLogDto
            {
                UseCaseName=command.Name,
                UserIdentity=_user.Identity,
                IsAuthorized= isAuthorized,
                UserId= isAuthorized ? _user.Id : null,
                CreatedTime=DateTime.Now,
                Data= JsonSerializer.Serialize(data)
            });

        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {

            HandleLoggingAndAuthorization(query, data);
            var response = query.Execute(data);


            bool isAuthorized = _user.Id == 0 ? false : true;
            _auditLogger.Log(new Application.Logging.AuditLogDto
            {
                UseCaseName = query.Name,
                UserIdentity = _user.Identity,
                IsAuthorized = isAuthorized,
                UserId = isAuthorized ? _user.Id : null,
                CreatedTime = DateTime.Now,
                Data = JsonSerializer.Serialize(data)
            });

            return response;

        }

        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            if (!isAuthorized)
            {
                throw new ForbiddenExecutionException(useCase.Name, _user.Identity);
            }
        }



    }
}
