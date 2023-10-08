using MoviesTheaterApplication.Dtos.Enum;

namespace MoviesTheaterApplication.Persistence.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public bool Adult { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Category Category { get; set; }
        public double Popularity { get; set; }
        public int VoteCount { get; set; }
        public double VoteAverage { get; set; }

        public ICollection<LikedMovieEntity> LikedByUsers { get; set; }

        public ICollection<CastMemberEntity> CastMembers { get; set; }

    }
}
