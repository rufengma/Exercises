using System;

namespace ApplicationCore.Models
{
    public class MovieCardResponseModel
    {
        //This is a response;
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public decimal Budget { get; set; }
    }
}
