namespace MoviesApi.Dtos
{
    public class CreateGenreDto
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
    }
}
