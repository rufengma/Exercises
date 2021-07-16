using System;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        // now IGenreRepository has no method yet.
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
