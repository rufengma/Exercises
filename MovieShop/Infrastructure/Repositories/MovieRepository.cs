using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        // I only want to implement the method in IMovieRepository.
        //make here cleaner

        // now it only implementing one method. EfRepository implemented other 7 methods
        //But actually it has 8 methods.
        public async Task<List<Movie>> GetHighest30GrossingMovies()
        {
            // go to the movies table. This is sql, what you have done. order by the revenue
            var topMovies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return topMovies;
        }

    }
}
