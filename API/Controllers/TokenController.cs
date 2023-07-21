using API.Core;
using API.Core.TokenStorage;
using Application.UseCases.Dto;
using FluentValidation;
using Implementation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        /// <summary>
        ///  Logovanje - generisanje tokena 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  
        ///
        ///     POST /api/Token
        ///     {
        ///          "email": "galic.lazar@gmail.com",
        ///          "password": "sifrasifra1"
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="200">Dohvaceno</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        ///
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request,
                                 [FromServices] JwtManager manager,
                                 [FromServices] LoginValidator validator)
        {
 
                validator.ValidateAndThrow(request);

                var token = manager.MakeToken(request.Email, request.Password);

                return Ok( new { token }  );
 
 
        }



        /// <summary>
        ///  Unistavanje validnog tokena, InvalidateToken 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  
        ///
        ///     
        ///
        /// </remarks>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        ///
        [HttpDelete]
        [Authorize]
        public IActionResult InvalidateToken([FromServices] ITokenStorage storage)
        {
            var header = HttpContext.Request.Headers["Authorization"];

            var token = header.ToString().Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;

            storage.InvalidateToken(jti);

            return NoContent();
        }


    }


}
