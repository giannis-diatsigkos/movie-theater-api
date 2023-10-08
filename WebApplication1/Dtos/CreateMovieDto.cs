﻿using MoviesTheaterApplication.Dtos.Enum;

namespace MoviesTheaterApplication.Dtos
{
    public class CreateMovieDto
    {
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
        public ICollection<CastDto> CastMembers { get; set; }
    }
}
