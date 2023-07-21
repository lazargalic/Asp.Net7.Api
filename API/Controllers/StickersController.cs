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
    public class StickersController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public StickersController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        // GET: api/<StickersController>
        /// <summary>
        ///  Dohvatanje svih AKTIVNIH stikera - za korisnike prilikom komentarisanja 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <remarks>
        ///  
        ///
        ///     GET /api/stickers
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
            [FromServices] EmptySearchDto search,
            IGetStickersQuery query)
        {
            return Ok(Handler.HandleQuery(query,search));
        }
        /*

        // GET api/<StickersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<StickersController>

        /// <summary>
        /// Dodavanje stikera -  admin inicijalno tj onaj ko ima useCaseId za ovo 
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  + token
        ///
        ///     POST  /api/admin/stickers
        ///     {
        ///      
        ///           "nameSticker": "Stiker kafica Viber",
        ///           "pathSticker": "path141231321312" 
        ///      }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Insert</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        [Authorize]
        [Route("/api/admin/stickers")]
        public IActionResult Post(
            [FromBody] CreateStickersDto dto,
            [FromServices] IAddStickerCommand command)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }




        /// <summary>
        ///  Editovanje Stikera, naziv i nova slika,  admin inicijalno tj onaj ko ima useCaseId za ovo   
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
        ///           "id": 2,
        ///           "newNameSticker": "Neki Novi Naziv",
        ///           "newPathSticker": "dasdjsadij124214124"
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">No Conent,Uspesan Update</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">EntityNotFoundException</response>
        /// <response code="409">AlreadyExistsException - ako neko setuje novo ime koje vec postoji u drugom redu- unique constraint</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut("/api/admin/stickers")]
        [Authorize]
        public IActionResult Put(
           [FromServices] IEditStickerCommand command,
           [FromBody] EditStickerDto data)
        {
            Handler.HandleCommand(command, data);
            return StatusCode(204);
        }



        /// <summary>
        ///  Brisanje stikera odnosno iz baze - soft delete ,  admin inicijalno tj onaj ko ima useCaseId za ovo   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///   + token
        ///
        ///     DELETE  /api/admin/stickers
        ///     {
        ///           "id": 1,
        ///     }
        ///      
        ///
        /// </remarks>
        /// <response code="204">No Content, Uspesan Delete</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">EntityNotFoundException</response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        // DELETE api/<StickersController>/5
        [HttpDelete("/api/admin/stickers/{id}")]  //  ! ili samo [httpdelete] pa route putanja sa {id} 
        [Authorize]
        public IActionResult Delete([FromRoute] int id, [FromServices] IDeleteStickerCommand command)
        {
            Handler.HandleCommand(command, id);
            return StatusCode(204);
        }


    }
}
