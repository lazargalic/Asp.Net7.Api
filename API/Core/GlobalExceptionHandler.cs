using Application.Exceptions;
using Application.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentValidation;

namespace API.Core
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionLogger _logger;  //


        public GlobalExceptionHandler(RequestDelegate next, IExceptionLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)  //async
        {
            try  //
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);

                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;


                if (ex is EntityNotFoundException entityNotFoundException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    response = new
                    {
                        message = entityNotFoundException.Message,
                        entityType = entityNotFoundException.EntityType,
                        id = entityNotFoundException.Id
                    };
                }

                if (ex is UnauthorizedAccessException unauthorizedAccessException)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new
                    {
                        message = "Neispravni kredencijali.",   //
                    };
                }

                if (ex is AccountNotActivated accountNotActivated)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new
                    {
                        message = accountNotActivated.Message   //
                    };
                }
                 


                if (ex is ForbiddenExecutionException entityForbiddenExecutionException)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new
                    {
                        message = entityForbiddenExecutionException.Message,
                        user = entityForbiddenExecutionException.User,
                        useCase = entityForbiddenExecutionException.UseCase
                    };
                }

                if (ex is TokenNotValidException tokenNotValidException)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new
                    {
                        message = tokenNotValidException.Message,
                    };
                }


                if (ex is FluentValidation.ValidationException entityValidationException)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = entityValidationException.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                    /*response = new
                    {
                        message = "Proso"
                    };*/
                }

                if (ex is AlreadyExistsException alreadyExistsException)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new
                    {
                        message = alreadyExistsException.Message
                    };
                }

                if (ex is DeleteButNotExistsErrorException deleteButNotExistsErrorException)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new
                    {
                        message = deleteButNotExistsErrorException.Message
                    };
                }

                if (ex is BadParrentExecption badParrentExecption)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new
                    {
                        message = badParrentExecption.Message
                    };
                }

                if (ex is AlreadyReactedException alreadyReactedException)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new
                    {
                        message = alreadyReactedException.Message
                    };
                }


                if (ex is EmailExistsInDatabaseException emailExistsInDatabaseException)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        message = emailExistsInDatabaseException.Message
                    };
                }

                if (ex is EntiyHasRestrictRelationships entiyHasRestrictRelationships)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new
                    {
                        message = entiyHasRestrictRelationships.Message
                    };
                }

                if (ex is ConflictInExecution conflictInExecution)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new
                    {
                        message = conflictInExecution.Message
                    };
                }
                if (ex is EmptyCommentException emptyCommentException)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        message = emptyCommentException.Message
                    };
                }
                

                //Na kraju 
                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
