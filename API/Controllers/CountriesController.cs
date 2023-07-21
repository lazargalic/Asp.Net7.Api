using Application.UseCases.Queries.Searches;
using Application.UseCases.Queries;
using Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public CountriesController(UseCaseHandler handler)
        {
            Handler = handler;
        }

        // GET: api/<CountriesController>

        /// <summary>
        ///  Dohvatanje svih drzava- za korisnike prilikom registracije 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <remarks>
        ///  
        ///
        ///     GET /api/countries
        ///     {
        ///          
        ///         
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="200">Dohvaceno</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        /// 


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(
            [FromServices] IGetAllCountriesWithTownshipsQuery query,
            [FromServices] EmptySearchDto search)
        {
            return Ok(Handler.HandleQuery(query, search));
        }

        // GET api/<CountriesController>/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
