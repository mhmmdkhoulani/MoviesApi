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

        public GenreDto Genre { get; set; }
    }

    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
