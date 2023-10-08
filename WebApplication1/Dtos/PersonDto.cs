
using MoviesTheaterApplication.Persistence.Entities;

namespace MoviesTheaterApplication.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public ICollection<MovieDto> Movies{ get; set; }
       public ICollection<MovieEntity> LikedMovies { get; set; }

    }
}
