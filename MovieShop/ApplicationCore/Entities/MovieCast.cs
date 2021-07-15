using System;
namespace ApplicationCore.Entities
{
    public class MovieCast
    {

        //junction table!!
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public string Character { get; set; }
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }

    }
}
