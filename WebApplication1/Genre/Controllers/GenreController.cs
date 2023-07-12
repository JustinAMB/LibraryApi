using Microsoft.AspNetCore.Mvc;

using Library.Genre.Dto.Request;
using Library.Genre.Dto.Response;
using Library.Genre.Services.Interfaces;
using Library.Shared.Dto.Response;

namespace Library.Genre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService _genreService) { 

            this._genreService = _genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GenresResultDto result = this._genreService.getGenres(0);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult save([FromBody] GenreRequestDto body) {
            var validator = new GenreRequestValidationDto();
            var validateResult = validator.Validate(body);
            if (!validateResult.IsValid) {
                return BadRequest(validateResult.Errors);
            }

            GenericResultDto result = this._genreService.addUpdateGenre(body);
            return Ok(result);

        }

    }
}
