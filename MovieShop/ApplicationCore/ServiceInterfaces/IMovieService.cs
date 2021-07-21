using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        //which one defines your service methods.

        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<MovieCardResponseModel>> GetMoviesInGenre(int GenreId);
        Task<List<string>> GetMovieReview(int id);
    }
}
