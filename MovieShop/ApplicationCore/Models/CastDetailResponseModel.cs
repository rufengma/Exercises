using System;
using System.Collections.Generic;
namespace ApplicationCore.Models
{
    public class CastDetailsResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
        public List<MovieResponseModel> Movies { get; set; }

    }
    public class MovieResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Character { get; set; }
    }
}
