using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using Application.UseCases.Queries.AdminQueries;
using Application.UseCases.Queries.Searches;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public AdminUsersController(UseCaseHandler handler)
        {
            Handler = handler;
        }



        // GET: api/<AdminUsersController>
        /// <summary>
        /// Administrator pregledava detalje o registrovanim korisnicma + filtriranje.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        /// Filtriranje (+token):
        ///
        ///     GET /api/admin/registeredUsers
        ///     {
        ///       "Keyword": Lazar,
        ///       "IsActive": true,
        ///       "UseCaseId: 2
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Uspesno Citanje </response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        [Authorize]
        [Route("/api/admin/registeredUsers")]
        public IActionResult Get(
            [FromServices] IAdminGetAllRegisteredUsers query, 
            [FromQuery] SearchRegisteredUsersDto request)
        {
            return Ok(Handler.HandleQuery(query, request));
        }



        /// <summary>
        /// Dodaje se novi UseCase za odredjenog Usera .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dto body-a (+token):
        ///
        ///     POST /api/admin/useCaseUser
        ///     {
        ///        "userId": 1,
        ///        "useCaseId": 999
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Already Exists</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        [Authorize]
        [Route("/api/admin/useCaseUser")]
        public IActionResult Post(
            [FromServices] IAddUseCaseToUserCommand command,
            [FromBody] CreateUserUseCasesDto request)
        {
            Handler.HandleCommand(command, request);
            return StatusCode(201);
        }



        /// <summary>
        /// Brisanje jednog UseCase-a za odredjenog Usera .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dto body-a (+token):
        ///
        ///     DELETE /api/admin/useCaseUser
        ///     {
        ///        "userId": 1,
        ///        "useCaseId": 999
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Successfull deleted- No Content.</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">TryToDeleteButNotExixsts</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete]
        [Authorize]
        [Route("/api/admin/useCaseUser")]
        public IActionResult Delete(
            [FromServices] IDeleteUseCaseUserCommand command,
            [FromBody] DeleteUserUseCasesDto request)
        {
            Handler.HandleCommand(command, request);
            return NoContent();
        }


        /*// GET api/<AdminUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
