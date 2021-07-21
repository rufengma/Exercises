using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository:IAsyncRepository<Movie>
    {
        Task<List<Movie>> GetHighest30GrossingMovies();
        // return time of this one should be a list of movies(Entities)
        Task<List<Movie>> GetTop20RatingMovies();
        Task<List<Movie>> Get20MoviesInGenre(int GenreId);
        Task<List<string>> GetMovieReview(int id);
    }
}
