using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesTheaterApplication.Dtos;
using MoviesTheaterApplication.Persistence;
using MoviesTheaterApplication.Persistence.Entities;
using MoviesTheaterApplication.Services.Interfaces;

namespace MoviesTheaterApplication.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public MovieService(ApplicationContext context, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }
        public async Task<int> CreateMovie(CreateMovieDto createMovie)
        {
            var movie = _mapper.Map<MovieEntity>(createMovie);
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie.Id;
        }

        public async Task DeleteMovie(int id)
        {
            var movieToDelete = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {

            var movies = await _context.Movies.Include(x => x.LikedByUsers).ToListAsync();

            return _mapper.Map<List<MovieDto>>(movies);
        }

        public async Task<LikedMovieDto> ToggleLikedMovie(string userName, string movieTitle, int movieId)
        {
            var userId = await _context.User.FirstOrDefaultAsync(x => x.Username == userName);
            var likedMovie = await _context.LikedMovie
                   .FirstOrDefaultAsync(lm => lm.UserName == userName && lm.MovieId == movieId && lm.Title == movieTitle);

            if (likedMovie == null)
            {
                likedMovie = new LikedMovieEntity
                {
                    UserName = userName,
                    MovieId = movieId,
                    UserId = userId.Id,
                    Title = movieTitle,
                };

                _context.LikedMovie.Add(likedMovie);
            }
            else
            {
                _context.LikedMovie.Remove(likedMovie);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<LikedMovieDto>(likedMovie);
        }

        public async Task UpdateMovie(int id, UpdateMovieDto movie)
        {
            var movieToUpdate = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movieToUpdate != null)
            {
                var movieUpdated = _mapper.Map(movie, movieToUpdate);
                _context.Movies.Update(movieUpdated);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CreateMovieDto> MovieExists(int movieId)
        {
            var movieExists = await _context.Movies.FirstOrDefaultAsync(x => x.TmdbId == movieId);
            var movieDto = _mapper.Map<CreateMovieDto>(movieExists);
            return movieDto;
        }
    }
}
