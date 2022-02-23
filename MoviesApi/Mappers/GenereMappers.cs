namespace MoviesApi.Mappers
{
    public static class GenereMappers
    {
        public static GenereDto ToGenereDto(this Genre genere)
        {
            return new GenereDto
            {
                Id = genere.Id,
                Name = genere.Name,
            };
        }

    }
}
