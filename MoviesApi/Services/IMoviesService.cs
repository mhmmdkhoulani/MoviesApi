namespace MoviesApi.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDetailsDto>> GetAllMoviesAsync();
        Task<IEnumerable<MovieDetailsDto>> GetAllMoviesByGenreIdAsync(int id);
        Task<MovieDetailsDto> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(MovieDto movie);
        Task<bool> IsValidGenreId(int id);
        Task DeleteMovieAsync(int id);

    }
}
