using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Mappers;

namespace MoviesApi.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MoviesService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Movie> AddMovieAsync(MovieDto dto)
        {
            var dataStream = new MemoryStream();
            await dto.Poster.CopyToAsync(dataStream);

            var movie = _mapper.Map<Movie>(dto);
            movie.Poster = dataStream.ToArray();

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
                .ToListAsync();
            
            return movies.Select(m => m.ToMovieDetailsDto());
        }

        public async Task<IEnumerable<MovieDetailsDto>> GetAllMoviesByGenreIdAsync(int id)
        {
            var movies = await _db.Movies
                .OrderByDescending(m => m.Rate)
                .Include(m => m.Genre)
                .Where(m => m.GenreId == id)
                .ToListAsync();
            var date = _mapper.Map<IEnumerable<MovieDetailsDto>>(movies);
            return date;
        }

        public async Task<MovieDetailsDto> GetMovieByIdAsync(int id)
        {
            var movie = await _db.Movies.Include(m => m.Genre).SingleOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return null;



            var data = _mapper.Map<MovieDetailsDto>(movie);

            return data;
        }

        public async Task<bool> IsValidGenreId(int id)
        {
            var result = await _db.Genres.AnyAsync(g => g.Id == id);
            return result;
        }

        public async Task<Movie> UpdateMovieAsync(MovieDto dto)
        {
            var movie = await _db.Movies.FindAsync(dto.Id);

            if (movie == null)
                return null;

            if (dto.Poster != null)
            {
                var dataStream = new MemoryStream();
                await dto.Poster.CopyToAsync(dataStream);
                movie.Poster = dataStream.ToArray();
            }

            movie.Title = dto.Title;
            movie.Year = dto.Year;
            movie.Rate = dto.Rate;
            movie.StoreLine = dto.StoreLine;
            movie.GenreId = dto.GenreId;

            await _db.SaveChangesAsync();
            return movie;

        }
    }
}
