


namespace MoviesApi.Services
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetAllAsnc();
        Task<Genre> AddGenreAsync(CreateGenreDto genreDto);
        Task<Genre> UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
        Task<Genre> GetGenreByIdAsync(int id);   
    }
}
