using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesTheaterApplication.Dtos;
using MoviesTheaterApplication.Services.Interfaces;

namespace MoviesTheaterApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("getMovies")]
        [Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieDto>))]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpGet("getMovie/{tmdbId}")]
        [Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDto))]
        public async Task<IActionResult> GetMovieById([FromRoute] int tmdbId)
        {
            var movie = await _movieService.MovieExists(tmdbId);
            if (movie == null)
            {
                return BadRequest("Movie does not exist");
            }
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        [HttpPost("addMovie")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto dto)
        {
            if (await _movieService.MovieExists(dto.TmdbId) != null)
            {
                return Conflict("Movie already exists");
            }
            var movieId = await _movieService.CreateMovie(dto);
            return Ok(movieId);
        }

        [HttpPost("likedMovie/{userName}/{movieTitle}/{movieId}")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LikedMovieDto))]
        public async Task<IActionResult> ToggleLikedMovies([FromRoute] string userName, [FromRoute] string movieTitle, [FromRoute] int movieId)
        {
            var likedMovie = await _movieService.ToggleLikedMovie(userName, movieTitle, movieId);
            return Ok(likedMovie);
        }

        [HttpPut("{movieId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateMovie([FromRoute] int movieId, [FromBody] UpdateMovieDto dto)
        {
            await _movieService.UpdateMovie(movieId, dto);
            return NoContent();
        }


        [HttpDelete("{movieId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteMovie([FromRoute] int movieId)
        {
            await _movieService.DeleteMovie(movieId);
            return NoContent();
        }

    }
}
