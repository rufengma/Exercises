using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetHighest30GrossingMovies();// return time of this one should be a list of movies(Entities)

    }
}
