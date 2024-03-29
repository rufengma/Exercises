﻿using System;
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
        public async Task<List<Movie>> GetHighest30GrossingMovies()
        {
            // go to the movies table. This is sql, what you have done. order by the revenue
            var topMovies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return topMovies;
        }
        public async Task<List<Movie>> GetTop20RatingMovies()
        {
            var topMovies = await _dbContext.Movies.Include(m => m.Reviews).OrderByDescending(m => m.Rating).Take(20).ToListAsync();
            return topMovies;
        }
        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts)
                .ThenInclude(m => m.Cast).Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == id)
               .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0)
            {
                movie.Rating = movieRating;
            }
            return movie;
        }
        public async Task<List<Movie>> Get20MoviesInGenre(int GenreId)
        {
            var MoviesInGenre = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == GenreId)
                .SelectMany(g => g.Movies).OrderByDescending(m => m.Revenue).ToListAsync();
            return MoviesInGenre;
        }
        public async Task<List<string>> GetMovieReview(int id) {
            var movieReview = await _dbContext.Reviews.Where(m => m.MovieId == id).Select(m=>m.ReviewText).ToListAsync();
            return movieReview;
        }
    }
}
