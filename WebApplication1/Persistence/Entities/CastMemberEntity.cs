namespace MoviesTheaterApplication.Persistence.Entities
{
    public class CastMemberEntity
    {
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
        public string Role { get; set; }
    }
}
