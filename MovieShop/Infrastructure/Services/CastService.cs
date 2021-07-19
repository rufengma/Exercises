using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class CastService:ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository=castRepository;
        }

        public async Task<CastDetailsResponseModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            var castDetails = new CastDetailsResponseModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl= cast.TmdbUrl,
                ProfilePath = cast.ProfilePath
            };
            castDetails.Movies = new List<MovieResponseModel>();
            foreach (var movie in cast.MovieCasts)
            {
                castDetails.Movies.Add(new MovieResponseModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    Character=movie.Character,
                    PosterUrl=movie.Movie.PosterUrl
                });
            }
            return castDetails;
        }
    }
}
