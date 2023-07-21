using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public UseCaseController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        // GET: api/<UseCaseController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UseCaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<UseCaseController>

        /// <summary>
        /// Dodavanje useCase-a nekoj Roli -  admin inicijalno moze ovo, tj onaj ko ima useCaseId.  
        /// Kada se doda novi UseCase ka nekoj ulozi, azurira se tabela AllUserUseCases koja ima UserId i RoleId od
        /// kolona, i svako ko ima ovu rolu od Usera azurirace mu se novi use case koji smo upravo dodali.  
        /// 
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  + token
        ///
        ///     POST  /api/admin/emotions
        ///     {
        ///      
        ///           "roleid": 1,
        ///           "useCaseId": 888
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">AlreadyExistsException</response>
        /// <response code="409">ConflictInExecution</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        [Authorize]
        [Route("/api/admin/useCaseRole")]
        public IActionResult Post(
            [FromServices] IAddUseCaseToRoleCommand command,
            [FromBody] AddUseCasesToRoleDto dto )
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }



        /// <summary>
        /// Brisanje useCase-a nekoj Roli -   Ista stvar kao i iznad, brise se svakom useru iz tabele AllUserUseCases koji ima ovu rolu
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  + token  //888 ne postoji u bazi pre toga ako ste je doali mozete je obrisati
        ///
        ///     POST  /api/admin/emotions
        ///     {
        ///      
        ///           "roleid": 1,
        ///           "useCaseId": 888
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">DeleteButNotExistsErrorException</response>
        /// <response code="409">ConflictInExecution</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete]
        [Authorize]
        [Route("/api/admin/useCaseRole")]
        public IActionResult Delete(
        [FromServices] IDeleteUseCaseToRoleCommand command,
        [FromBody] DeleteUseCasesToRoleDto dto)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(204);
        }



    }
}
