using Application.UseCases.Commands;
using Application.UseCases.Dto;
using DataAccess;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private UseCaseHandler Handler {get;}
        public RegistrationController(UseCaseHandler handler)
        {
            Handler = handler;
        }
 

        // POST api/<RegistrationController>

        /// <summary>
        ///  Registracija korisnika
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Example 
        ///    
        ///     POST /api/Registration
        ///     {
        ///             "firstName": "Milojko",
        ///             "lastName": "Milojkovic",
        ///             "email": "miloje123412@gmail.com",
        ///             "password": "sifrasifra1",
        ///             "identityNumber": "12412412421",
        ///             "phoneNumber": "1242141241"
        ///     }
        ///
        /// </remarks>
        /// 
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable E </response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(
            [FromBody] RegisterUserDto dto,
            [FromServices] IRegisterUserCommand command) 
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

/*        // PUT api/<RegistrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
*/

    }
}
