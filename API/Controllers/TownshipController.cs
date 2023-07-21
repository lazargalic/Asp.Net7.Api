using Application.UseCases.Queries;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownshipController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public TownshipController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        // GET: api/<TownshipController>
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }
 */

        /// <summary>
        ///  Dohvatanje svih opstina jedne drzave, - kada korisnik hoce da doda u postu, prvo country, pa za taj country opstine  
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        ///  Get
        ///
        ///     GET /api/Township
        ///     {
        ///       "id": 1
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="200">Dohvaceno</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(
            [FromServices] IGetAllTownshipsInOneCountry query,
            [FromRoute] int id)
        {
            return Ok(Handler.HandleQuery(query, id));
        }

        // POST api/<TownshipController>
       /* [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TownshipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TownshipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
