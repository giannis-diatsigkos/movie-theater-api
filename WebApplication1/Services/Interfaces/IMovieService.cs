using MoviesTheaterApplication.Dtos;

namespace MoviesTheaterApplication.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMovies();

        Task<int> CreateMovie(CreateMovieDto createMovie);

        Task UpdateMovie(int id, UpdateMovieDto movie);

        Task DeleteMovie(int id);

        Task<CreateMovieDto> MovieExists(int  id);

        Task<LikedMovieDto> ToggleLikedMovie(string userName, string movieTitle, int movieId);
    }
}
