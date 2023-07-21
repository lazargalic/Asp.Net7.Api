using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using Application.UseCases.Queries;
using Application.UseCases.Queries.Searches;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmotionsController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public EmotionsController(UseCaseHandler handler)
        {
            Handler = handler;
        }

        /// <summary>
        ///  Dohvatanje svih AKTIVNIH reakcija / emocija - za korisnike prilikom lajkovanja 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <remarks>
        ///  
        ///
        ///     GET /api/emotions
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
            [FromServices] IGetAllEmotionQuery query,
            [FromServices] EmptySearchDto search)
        {
            return Ok(Handler.HandleQuery(query, search));
        }

        // GET api/<EmotionsController>/5
        /*        [HttpGet("{id}")]
                public string Get(int id)
                {
                    return "value";
                }*/

        // POST api/<EmotionsController>


        /// <summary>
        /// Dodavanje reakcije / emocije -  admin inicijalno tj onaj ko ima useCaseId za ovo 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  + token
        ///
        ///     POST  /api/admin/emotions
        ///     {
        ///           "nameEmotion": "Lmaooooooooo",
        ///           "imagePath": "path11231321312",
        ///           "price": 1240
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpPost("/api/admin/emotions")]
        [Authorize]
        public IActionResult Post(
            [FromBody] CreateEmotionDto data,
            [FromServices] IAddEmotionCommand command)
        {
            Handler.HandleCommand(command, data);
            return StatusCode(201);
        }


        /// <summary>
        ///  Editovanje Reakcije, naziv i nova slika,  admin inicijalno tj onaj ko ima useCaseId za ovo   
        /// </summary>
        /// <param name="data"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///   + token
        ///
        ///     PATCH  /api/admin/emotions
        ///     {
        ///      
        ///           "id": 1,
        ///           "newNameEmotion": "string",
        ///            "newImagePath": "string"
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">No Conent, Uspesan Update</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">EntityNotFoundException</response>
        /// <response code="409">AlreadyExistsException - ako neko setuje novo ime koje vec postoji u drugom redu- unique constraint</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPatch("/api/admin/emotions")]
        [Authorize]
        public IActionResult Patch( 
            [FromServices] IEditEmotionCommand command,
            [FromBody] EditEmotionDto data)
        {
            Handler.HandleCommand(command, data);
            return StatusCode(204);
        }



        /// <summary>
        ///  Brisanje reakcije odnosno emocije iz baze - soft delete ,  admin inicijalno tj onaj ko ima useCaseId za ovo   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///   + token
        ///
        ///     DELETE  /api/admin/emotions
        ///     {
        ///           "id": 1
        ///      
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">No Content, Uspesan Delete</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">EntityNotFoundException</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("/api/admin/emotions/{id}")]
        [Authorize]
        public IActionResult Delete(int id, IDeleteEmotionCommand command)
        {
            Handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
