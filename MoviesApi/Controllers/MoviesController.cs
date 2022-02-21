using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedSize = 1048576;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _moviesService.GetAllMoviesAsync();

            return Ok(movies);
        }

        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetAllByGenreIdAsync(int genreId)
        {
            var movies = await _moviesService.GetAllMoviesByGenreIdAsync(genreId);

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null)
                return BadRequest($"Movie with id {id} not found");

            return Ok(movie);

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm]MovieDto dto)
        {
            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest("File does not suppprted");

            if (dto.Poster.Length > _maxAllowedSize)
                return BadRequest("File is larger than max allowed size (1MB)");

            var isValid = await _moviesService.IsValidGenreId(dto.GenreId);

            if (!isValid)
                return BadRequest("Invalid Genre Id");

            var movie = await _moviesService.AddMovieAsync(dto);
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie = _moviesService.DeleteMovieAsync(id);
            if(movie == null)
                return BadRequest($"No movie found with id {id}");
            return Ok("Movie deleted");
        }
    }
}
