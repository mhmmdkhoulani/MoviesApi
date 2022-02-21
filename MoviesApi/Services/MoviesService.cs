using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;

namespace MoviesApi.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext _db;


        public MoviesService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Movie> AddMovieAsync(MovieDto dto)
        {
            var dataStream = new MemoryStream();
            await dto.Poster.CopyToAsync(dataStream);
            var movie = new Movie
            {
                Title = dto.Title,
                Year = dto.Year,
                Poster = dataStream.ToArray(),
                Rate = dto.Rate,
                StoreLine = dto.StoreLine,
                GenreId = dto.GenreId,
            };

            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            if (movie == null)
                return;

            _db.Movies.Remove(movie);
        }

        public async Task<IEnumerable<MovieDetailsDto>> GetAllMoviesAsync()
        {
            var movies = await _db.Movies
                .OrderByDescending(m => m.Rate)
                .Include(m => m.Genre)
                .Select(m => new MovieDetailsDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    GenreId = m.GenreId,
                    GenreName = m.Genre.Name,
                    Poster = m.Poster,
                    Rate = m.Rate,
                    StoreLine=m.StoreLine,
                    Year = m.Year
                })
                .ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<MovieDetailsDto>> GetAllMoviesByGenreIdAsync(int id)
        {
            var movies = await _db.Movies
                .OrderByDescending(m => m.Rate)
                .Include(m => m.Genre)
                .Select(m => new MovieDetailsDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    GenreId = m.GenreId,
                    GenreName = m.Genre.Name,
                    Poster = m.Poster,
                    Rate = m.Rate,
                    StoreLine = m.StoreLine,
                    Year = m.Year
                })
                .Where(m => m.GenreId == id)
                .ToListAsync();

            return movies;
        }

        public async Task<MovieDetailsDto> GetMovieByIdAsync(int id)
        {
            var movie = await _db.Movies.Include(m => m.Genre).SingleOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return null;

            var movieDetailsDto = new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                GenreId = movie.GenreId,
                GenreName = movie.Genre.Name,
                Poster = movie.Poster,
                Rate = movie.Rate,
                StoreLine = movie.StoreLine,
                Year = movie.Year
            };

            return movieDetailsDto;
        }

        public async Task<bool> IsValidGenreId(int id)
        {
            var result = await _db.Genres.AnyAsync(g => g.Id == id);
            return result;
        }
    }
}
