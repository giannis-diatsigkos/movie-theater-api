using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesTheaterApplication.Dtos;
using MoviesTheaterApplication.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesTheaterApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthenticationController(IConfiguration configuration, IUserService userService, IMapper mapper)
        {
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<string?>> Signup([FromBody] UserDto userDto)
        {
            // Check if username already exists
            if (await _userService.GetUserByUsername(userDto.Username) != null)
                return Conflict("Username already exists");

            // Create user
            var createdUserId = await _userService.CreateUser(userDto);
            if (createdUserId > 0)
            {
                var token = _userService.GenerateJwtToken(userDto);
                return Ok(new { Token = token });
            }
            return null;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string?>> Login([FromBody] UserDto userDto)
        {
            // Authenticate the user
            var user = await _userService.AuthenticateUser(userDto);
            if (user == null)
                return Unauthorized("Invalid username or password");
            // Generate JWT token
            var token = _userService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
    }
}
