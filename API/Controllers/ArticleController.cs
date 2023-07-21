using Application.UseCases.Commands;
using Application.UseCases.Dto;
using Application.UseCases.Queries;
using Application.UseCases.Queries.Searches;
using Implementation.UseCases;
using Implementation.UseCases.Commands.Ef;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static API.Core.ImagesDto.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".png", ".jpeg" };


        private UseCaseHandler Handler { get; }
        public ArticleController(UseCaseHandler handler)
        {
            Handler = handler;
        }


        // GET: api/<ArticleController>

 
        /// <summary>
        /// Pregled Objava uz filtriranje i paginaciju .
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
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
       // [AllowAnonymous]
        public IActionResult Get(
            [FromServices] IGetArticlesQuery query,
            [FromQuery] SearchArticlesDto search)
        {

            return Ok(Handler.HandleQuery(query,search));
        }

         
        /// <summary>
        /// Pregled Jedne Objave - automaper (slozen upit automapera) .
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///  
        ///
        ///     GET /api/article
        ///     {
        ///         id : 1
        ///     }
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="200">Uspesno Citanje </response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(
                [FromRoute] int id,
                [FromServices] IGetOneArticleQuery query)
        {
            return Ok(Handler.HandleQuery(query, id));
        }



        /// <summary>
        /// Dodavanje Objave- neregistrovani korisnik + 1 glavna ili vise dodatnih slika.  Zbog slozenosti Testirati U swaggeru  
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// POST
        /// CategoryDimensionId i CategoryDesignId - staviti 1          
        /// AdditionalDescription,Quote i Main Conent nisu obavezna polja             
        /// Datumi: Begin i End -  bilo koji         
        /// String Za MainPicture Polje i za Dodatne Slike ne unositi to se svakako pregazi kada se insertuje slika        
        /// Dodatne Slike su nova tabela, neobavezno         
        /// Treba Uneti neke kredencijale ako je neregistrovani korisnik , To su Ime Prezime, Mejl i broj telefona 
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Uspesno dodavanje </response>
        /// <response code="422">Unprocessable Entity </response>
        /// <response code="500">Unexpected server error.</response>
        /// 

        // POST api/<ArticleController>
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/articleNonRegistered")]
        public IActionResult Post(
                [FromForm] CreateArticleNonRegisteredUserDtoWithImages dto,
                [FromServices] IAddPostNonRegisteredUser command)
        {
            if (dto.MainPicture != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.MainPicture.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Nije dozvoljen tip slike. Dozvoljeni: 'jpg', 'png', 'jpeg' ");
                }

                var fileName = guid + extension;
                var filePath = Path.Combine("wwwroot", "Images", fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                dto.MainPicture.CopyTo(stream);

                string databasePath = filePath.Replace("wwwroot\\", string.Empty);
                dto.ArticleToAdd.MainPicturePath = databasePath;
            }

            if (dto.MoreImages != null && dto.MoreImages.Count() != 0)
            {
                var newPictures = new List<AddMoreImagesToArticles>();

                foreach (var image in dto.MoreImages)
                {
                    var guid = Guid.NewGuid().ToString();

                    var extension = Path.GetExtension(image.FileName);

                    if (!AllowedExtensions.Contains(extension))
                    {
                        throw new InvalidOperationException("Nije dozvoljen tip slike. Dozvoljeni: 'jpg', 'png', 'jpeg'");
                    }

                    var fileName = guid + extension;
                    var filePath = Path.Combine("wwwroot", "Images", "OptionsImages", fileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    image.CopyTo(stream);

                    var toAdd = new AddMoreImagesToArticles();
                    string databasePath = filePath.Replace("wwwroot\\", string.Empty);
                    toAdd.ImagePath = databasePath;
                    newPictures.Add(toAdd);
                }

                dto.ArticleToAdd.MoreImages = newPictures;
            }


            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }





        /// <summary>
        /// Dodavanje Objave- registrovani korisnik + 1 glavna ili vise dodatnih slika . Zbog slozenosti Testirati U swaggeru (ima gore authorization kljuc kao na Vue-u)
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// POST
        /// CategoryDimensionId i CategoryDesignId - staviti 1           
        /// AdditionalDescription,Quote i Main Conent nisu obavezna polja                 
        /// Datumi: Begin i End -  bilo koji                  
        /// String Za MainPicture Polje i za Dodatne Slike ne unositi to se svakako pregazi kada se insertuje slika           
        /// Dodatne Slike su nova tabela, neobavezno                   
        ///  (+token):
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="201">Uspesno dodavanje </response>
        /// <response code="422">Unprocessable Entity </response>
        /// <response code="404">NotFound -(svakako dohvatam objekat usera iz Tokena(IApplicationUser) al sam i to proverio , mzd je suvisno) </response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        [HttpPost]
        [Authorize]
        [Route("/api/user/articleRegisteredUsers")]
        public IActionResult Post(
        [FromForm] CreateArticleRegisteredUserDtoWithImages dto,
        [FromServices] IAddPostRegisteredUser command)
        {
            if(dto.MainPicture != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.MainPicture.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Nije dozvoljen tip slike. Dozvoljeni: 'jpg', 'png', 'jpeg' ");
                }

                var fileName = guid + extension;
                //var filePath = Path.Combine("wwwroot", "Images", fileName);
                var filePath = Path.Combine("wwwroot","Images", fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                dto.MainPicture.CopyTo(stream);

                string databasePath = filePath.Replace("wwwroot\\", string.Empty);

                dto.ArticleToAdd.MainPicturePath= databasePath;

            }

            if (dto.MoreImages != null && dto.MoreImages.Count() !=0)
            {
                var newPictures = new List<AddMoreImagesToArticles>();
                 
                foreach (var image in dto.MoreImages)
                {
                    var guid = Guid.NewGuid().ToString();

                    var extension = Path.GetExtension(image.FileName);

                    if (!AllowedExtensions.Contains(extension))
                    {
                        throw new InvalidOperationException("Nije dozvoljen tip slike. Dozvoljeni: 'jpg', 'png', 'jpeg'");
                    }

                    var fileName = guid + extension;
                    var filePath = Path.Combine("wwwroot", "Images", "OptionsImages", fileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    image.CopyTo(stream);

                    var toAdd= new AddMoreImagesToArticles();
                    string databasePath = filePath.Replace("wwwroot\\", string.Empty);
                    toAdd.ImagePath = databasePath;
                    newPictures.Add(toAdd);
                }

                dto.ArticleToAdd.MoreImages = newPictures;
            }


            Handler.HandleCommand(command, dto);
            return StatusCode(201);
        }





        /// <summary>
        /// Brisanje Objave: Admin- svaku , RegUser- samo svoje .
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  (+token):   
        ///  
        /// 
        ///     DELETE /api/user/article
        ///     {
        ///         id : 1
        ///     }     
        ///  
        ///      
        ///     
        ///
        /// </remarks>
        /// <response code="204">Uspesno brisanje </response>
        /// <response code="422">Unprocessable Entity </response>
        /// <response code="404">NotFound -(svakako dohvatam objekat usera iz Tokena(IApplicationUser) al sam i to proverio , mzd je suvisno) </response>
        /// <response code="500">Unexpected server error.</response>
        /// 
        // DELETE api/<ArticleController>/5
        [HttpDelete]
        [Authorize]
        [Route("/api/article")]
        public IActionResult Delete([FromBody] DeleteArticleDto dto, 
                        [FromServices] IDeleteArticleCommand command)
        {
            Handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        private string CutString(string toCut, string whatToCut)
        {
            return "";
        }
    }
}
