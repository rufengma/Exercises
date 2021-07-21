using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDetails = new MovieDetailsResponseModel()
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                BackdropUrl = movie.BackdropUrl,
                RunTime = movie.RunTime,
                Price = movie.Price,
                Rating = movie.Rating

            };
            movieDetails.Casts = new List<CastResponseModel>();
            foreach (var cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    Character = cast.Character,
                    ProfilePath = cast.Cast.ProfilePath
                });
            }
            movieDetails.Genres = new List<GenreModel>();
            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add(
                    new GenreModel
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    });
            }

            return movieDetails;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighest30GrossingMovies();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }
        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetTop20RatingMovies();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }
        public async Task<List<MovieCardResponseModel>> GetMoviesInGenre(int GenreId)
        {
            var movies = await _movieRepository.Get20MoviesInGenre(GenreId);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.GetValueOrDefault(),
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }
        public async Task<List<string>> GetMovieReview(int id) {
            var reviewTexts = await _movieRepository.GetMovieReview(id);
            return reviewTexts;
        }
    }

}
// method(int x, IMovieService service)
//method (4, new MovieService)// second place can pass in an instance of MovieService.

