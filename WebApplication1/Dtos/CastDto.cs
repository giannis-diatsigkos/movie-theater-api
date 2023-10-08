﻿using MoviesTheaterApplication.Persistence.Entities;

namespace MoviesTheaterApplication.Dtos
{
    public class CastDto
    {
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
        public string Role { get; set; }
    }
}
