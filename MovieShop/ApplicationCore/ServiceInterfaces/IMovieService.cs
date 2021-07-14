using System;
using System.Collections.Generic;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        //which one defines your service methods.

        List<MovieCardResponseModel> GetTopRevenueMovies();
    }
}
