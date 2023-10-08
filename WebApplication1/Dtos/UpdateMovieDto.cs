namespace MoviesTheaterApplication.Dtos
{
    public class UpdateMovieDto
    {
        public string PosterPath { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double Popularity { get; set; }
        public int VoteCount { get; set; }

        public double VoteAverage { get; set; }
    }
}
