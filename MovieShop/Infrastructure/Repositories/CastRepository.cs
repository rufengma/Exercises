using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts.Include(m => m.MovieCasts).ThenInclude(m=>m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            return cast;
        }
    }
}
