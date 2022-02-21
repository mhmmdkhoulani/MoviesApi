using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;

namespace MoviesApi.Services
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext _db;

        public GenresService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Genre> AddGenreAsync(CreateGenreDto dto)
        {
            var genre = new Genre
            {
                Name = dto.Name,
            };

            await _db.Genres.AddAsync(genre);
            await _db.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = await _db.Genres.FindAsync(id);
            if (genre != null)
                return genre;
            
            return null;
        }

        public async Task<IEnumerable<Genre>> GetAllAsnc()
        {
            var genres = await _db.Genres.ToListAsync();

            return genres;
        }

        public async Task<Genre> UpdateGenreAsync(Genre genre)
        {
            var newGenre = await GetGenreByIdAsync(genre.Id);
            if (newGenre != null)
            {
                newGenre.Name = genre.Name ;
                await _db.SaveChangesAsync();
                return newGenre;
            }
            else
            {
                return null;
            }

        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _db.Genres.FindAsync(id);
            if (genre != null)
            {
                _db.Genres.Remove(genre);
                await _db.SaveChangesAsync();
                
            }

        }
    }
}
