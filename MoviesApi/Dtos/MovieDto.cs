namespace MoviesApi.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2500)]
        public string StoreLine { get; set; } = string.Empty;

        public int Year { get; set; }
        public double Rate { get; set; }

        public IFormFile? Poster { get; set; }

        public int GenreId { get; set; }
    }
}
