using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Mappers
{
    public static class MovieMappers
    {
        public static MovieDetailsDto ToMovieDetailsDto(this Movie movie)
        {
            return new MovieDetailsDto
            {
                Genere = movie.Genre.ToGenereDto(),
                Id = movie.Id,
                Rate = movie.Rate,
                Title = movie.Title,
                Year = movie.Year,
                StoreLine = movie.StoreLine,
            };
        }

        public static MovieSummaryDto ToMovieSummaryDto(this Movie movie)
        {
            return new MovieSummaryDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
            };
        }

    }
}
