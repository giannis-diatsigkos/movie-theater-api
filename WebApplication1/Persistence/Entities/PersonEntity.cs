namespace MoviesTheaterApplication.Persistence.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public ICollection<CastMemberEntity> CastMembers { get; set; }

    }
}
