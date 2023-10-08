using System.Text.Json.Serialization;

namespace MoviesTheaterApplication.Persistence.Entities
{
    public class LikedMovieEntity
    {
        public string UserName { get; set; }
         
        public string Title { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }

        public int MovieId { get; set; }
        [JsonIgnore]
        public MovieEntity Movie { get; set; }
    }
}
