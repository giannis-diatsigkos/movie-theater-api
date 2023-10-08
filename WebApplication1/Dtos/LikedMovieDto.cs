using MoviesTheaterApplication.Persistence.Entities;
using System.Text.Json.Serialization;

namespace MoviesTheaterApplication.Dtos
{
    public class LikedMovieDto
    {

        public string UserName { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }


        public int MovieId { get; set; }

    }
}
