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
    public class AuditLogsController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public AuditLogsController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        // GET: api/<AuditLogsController>
        /// <summary>
        /// Pregled Logova uz filtriranje - Admini .
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        /// Filtriranje (+token):
        ///
        ///     GET /api/article
        ///     {
        ///        // kriterijumi za filtiranje se vide u swaggeru
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="200">Uspesno Citanje </response>
        /// <response code="401">Forbidden</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] AuditLogsSearch search, [FromServices] IGetAuditLogs query)
        {
            return Ok(Handler.HandleQuery(query, search));
        }

        // GET api/<AuditLogsController>/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuditLogsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuditLogsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuditLogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
