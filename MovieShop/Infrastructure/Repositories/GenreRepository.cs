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
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        // now IGenreRepository has no method yet.
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Movie>> Get20MoviesInGenre(int GenreId)
        {
            var MoviesInGenre = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == GenreId)
                .SelectMany(g => g.Movies).OrderByDescending(m => m.Revenue).ToListAsync();
            return MoviesInGenre;
        }
    }
}
