using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MoviesApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genresService.GetAllAsnc();

            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateGenreDto dto)
        {
            var genre = await _genresService.AddGenreAsync(dto);
            return Ok(genre);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync(Genre genre)
        {
            var newGenre = await _genresService.UpdateGenreAsync(genre);
            if (newGenre == null)
            {
                return BadRequest("Genre is not found");
            }
            return Ok(newGenre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre = await _genresService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return BadRequest($"Genre with id {id} is not found");
            }
            else
            {
                await _genresService.DeleteGenreAsync(id);
                return Ok($"{genre.Name} deleted");
            }

        }

    }
}
