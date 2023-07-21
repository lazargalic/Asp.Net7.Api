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
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesUsersController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public CompaniesUsersController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        /// <summary>
        ///  Dohvatanje Usera i njihovih Kompanija  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dohvatanje (+token):
        ///
        ///     GET /api/admin/companiesUser
        ///     {
        ///       "Keyword": Lazar,
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="200">Uspesno Citanje </response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        [HttpGet]
        [AllowAnonymous]
        [Route("/api/admin/companiesUser")]

        public IActionResult Get(
            [FromServices] IGetUsersCompanies query,
            [FromQuery] KeywordSearchDto request)
        {
            return Ok(Handler.HandleQuery(query, request));
        }

        // GET: api/<CompaniesUsersController>
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         // GET api/<CompaniesUsersController>/5
         [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }*/


        /// <summary>
        ///  Unos Usera i kompanije 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// (+token):
        ///
        ///     POST /api/admin/companiesUser
        ///     {
        ///        "userId" : 2,
        ///        "companyId" : 1
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Uspesan Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">AlreadyExistsException</response>
        /// <response code="500">Unexpected server error.</response>
        /// 

        [HttpPost]
        [Authorize]
        [Route("/api/admin/companiesUser")]
        public IActionResult Post(
        [FromServices] IAddUserCompanyCommand command,
        [FromBody] UserCompanyDto request)
        {
            Handler.HandleCommand(command, request);
            return StatusCode(201);
        }

        /*   // PUT api/<CompaniesUsersController>/5
           [HttpPut("{id}")]
           public void Put(int id, [FromBody] string value)
           {
           }*/

        // DELETE api/<CompaniesUsersController>/5

        /// <summary>
        ///  Brisanje UserCompany-a  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// (+token):
        ///
        ///     DELETE /api/admin/companiesUser
        ///     {
        ///        "userId" : 1,
        ///        "companyId" : 1
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">Uspesno Brisanje </response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">DeleteButNotExistsErrorException</response>
        /// <response code="500">Unexpected server error.</response>
        /// 


        [HttpDelete]
        [Authorize]
        [Route("/api/admin/companiesUser")]
        public IActionResult Delete(
        [FromServices] IDeleteUserCompanyCommand command,
        [FromBody] UserCompanyDto request)
        {
            Handler.HandleCommand(command, request);
            return StatusCode(204);
        }
    }


}
