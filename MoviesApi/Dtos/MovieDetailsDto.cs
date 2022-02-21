namespace MoviesApi.Dtos
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string StoreLine { get; set; } = string.Empty;

        public int Year { get; set; }
        public double Rate { get; set; }

        public byte[] Poster { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
