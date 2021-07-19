using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IGenreRepository:IAsyncRepository<Genre>
    {
        Task<List<Movie>> Get20MoviesInGenre(int GenreId);
    }
}
