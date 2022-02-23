namespace MoviesApi.Mappers
{
    public static class GenereMappers
    {
        public static GenreDto ToGenereDto(this Genre genere)
        {
            return new GenreDto
            {
                Id = genere.Id,
                Name = genere.Name,
            };
        }

    }
}
