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

        public GenereDto Genere { get; set; }
    }

    public class MovieSummaryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }

    public class GenereDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
