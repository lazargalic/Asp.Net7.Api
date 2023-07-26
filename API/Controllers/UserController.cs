using API.Core.ImagesDto;
using Application.UseCases.Commands;
using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using Application.UseCases.Queries;
using Application.UseCases.Queries.Searches;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public UserController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        /// <summary>
        /// Prilikom ucitavanja jedne stranice proverava se da li je neki korisnik ragovao ili ne 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="200">Insert</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        [Route("/api/user/emotionPost/{id}")]
        public IActionResult Get(
            [FromServices] IGetReactionToCurrentPost query,
            [FromRoute] int id)
        { 
            return StatusCode(200, Handler.HandleQuery(query, id) );
        }




        /// <summary>
        ///  Dohvatanje svih objava trenutno ulogovanog korisnika
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        /// <response code="409">AlreadyReactedException</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        [Route("/api/user/myPosts")]
        public IActionResult Get(
            [FromServices] IGetPostsFromOneRegUserQuery query,
            [FromQuery] SearchKeywordDto search)
        {
            return StatusCode(200, Handler.HandleQuery(query, search));
        }
        //        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)






        /// <summary>
        /// Korisnik Reaguje na neki post
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  + token
        ///
        ///     POST  /api/user/emotionPost  {
        ///           "articleId": 2,
        ///           "emotionId": 1
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        /// <response code="409">AlreadyReactedException</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        [Authorize]
        [Route("/api/user/emotionPost")]
        public IActionResult Post(
            [FromBody] AddUserEmotionToArticleDto dto,
            [FromServices] IAddUserEmotionToArticleCommand command)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }





        /// <summary>
        /// Korisnik moze da updatuje samo sebe ili Admin njega. Administrator moze da menja uloge useru dok User sam sebi ne moze.       
        /// User dobija nove useCasove u (AllUserUseCases) u skladu sa novom Ulogom (ako mu se promeni).           
        /// Upit je zasticen tako da da korisnik ne moze da menja uloge.                  
        /// Kada se updatuje mejl isto se proverava da li taj novi naziv postoji vec u bazi- unique contraint.                
        /// Mogao sam ovaj endpoint da podelim na 2- jedan da izvrsavaju Useri za sebe, drugi Administratori ali i ovako radi
        /// perfektno i ako je slozen. Ima dosta provera tako da User I da posalje nekako van fronta upit za 
        /// promenu uloga odbice ga api.         
        /// Ako admin ne menja ulogu poslace 0 za roleId ili empty i zaobici ce se promena uloga.
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  + token
        ///
        ///     PUT  /api/User/     {
        ///             "idUserToUpdate": 2,
        ///              "firstName": "Zivojin",
        ///              "lastName": "Zivojinovic",
        ///              "email": "zivojin141@gmail.com",
        ///              "password": "sifrasifra1",
        ///              "roleId": 0,
        ///              "isActive": true,
        ///              "phoneNumber": "12412412",
        ///              "identityNumber": "1241241242"
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        /// <response code="409">EmailExistsInDatabaseException</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut]
        [Authorize]
        public IActionResult Put(
            [FromBody] UpdateOneUserDto dto,
            [FromServices] IUpdateOneUserCommand command)
        {
            Handler.HandleCommand(command, dto);
            return NoContent();
        }








        /// <summary>
        /// Aktivacija naloga, preko emaila     
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        /// <response code="409">EmailExistsInDatabaseException</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        [AllowAnonymous]
        [Route("/api/user/validateEmail/{guid}")]
        public IActionResult Put(
        [FromRoute] string guid,
        [FromServices] IValidateAccountCommand command)
        {
            Handler.HandleCommand(command, guid);
            return NoContent();
        }





        /// <summary>
        /// Korisnik Uklanja reakciju na neki post
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  + token
        ///
        ///     DELETE  /api/user/emotionPost  {
        ///           "articleId": 2,
        ///           "emotionId": 1
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        /// <response code="409">DeleteButNotExistsErrorException</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete]
        [Authorize]
        [Route("/api/user/emotionPost")]
        public IActionResult Delete(
            [FromBody] DeleteUserEmotionToArticleDto dto,
            [FromServices] IDeleteEmotionArticleUser command
            )
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
