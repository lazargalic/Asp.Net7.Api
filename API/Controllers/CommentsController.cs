using API.Core.ImagesDto;
using Application.UseCases.Commands;
using Application.UseCases.Dto;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private UseCaseHandler Handler { get; }
        public CommentsController(UseCaseHandler handler)
        {
            Handler = handler;
        }



        // POST api/<CommentsController>
        /// <summary>
        /// Kreiranje komentara i podkomentara Registrovani Korisnici .
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Unos (+token):
        ///
        ///     POST /api/user/commentArticle
        ///     {
        ///         "content": "MojKomentar",
        ///         "parrentCommentId": 0,  
        ///         "articleId": 2,
        ///         "categoryCommentId": 1,
        ///         "categoryDimensionId": 1, 
        ///         "stickerId": 0       
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Uspesno Dodato </response>
        /// <response code="401">Forbidden</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="409">EmptyCommentException i BadParrentExecption-Ako neko pokusa da doda komentar na komentar od roditeljskog komentara- omoguceno samo do 2 ugezdavanja </response>
        /// <response code="404">Not Found - Ako ne postoji ni artikal ni roditeljski komentar </response>
        /// <response code="500">Unexpected server error.</response>
        /// 

        [HttpPost]
        [Authorize]
        [Route("/api/user/commentArticle")]
        public IActionResult Post([FromBody] AddCommentUserDto dto,
           [FromServices] IAddCommentRegisteredUserCommand command)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CommentsController>/5
        /*  [HttpPut("{id}")]
          public void Put(int id, [FromBody] string value)
          {
          }*/



        /// <summary>
        /// Brisanje Komentara: Admin- svaki , RegUser- samo svoje .
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  (+token):   
        ///  
        /// 
        ///     DELETE /api/user/comment
        ///     {
        ///         id : 1
        ///     }     
        ///  
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Uspesno dodavanje </response>
        /// <response code="409">EntiyHasRestrictRelationships </response>
        /// <response code="404">NotFound - Ako ne postoji  Komentar </response>
        /// <response code="404">Isto tako ako neko pokusava da obrise komentar koji nije njegov  </response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        // DELETE api/<CommentsController>/5
        [HttpDelete]
        [Route("/api/user/comment/{id}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] IDeleteCommentCommand command)
        {
            Handler.HandleCommand(command, id);
            return StatusCode(204);
        }


    }
}
