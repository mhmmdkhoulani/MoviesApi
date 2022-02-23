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
                Genre = movie.Genre.ToGenereDto(),
                Id = movie.Id,
                Rate = movie.Rate,
                Title = movie.Title,
                Year = movie.Year,
                StoreLine = movie.StoreLine,
                Poster = movie.Poster,
                
            };
        }

        public static Movie ToMovie(this MovieDto movieDto)
        {
            return new Movie
            {
                Id = movieDto.Id,
                Rate = movieDto.Rate,
                Title = movieDto.Title,
                Year = movieDto.Year,
                StoreLine = movieDto.StoreLine,
                GenreId = movieDto.GenreId,
            };
        }



    }
}
