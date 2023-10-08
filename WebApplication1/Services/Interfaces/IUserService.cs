using MoviesTheaterApplication.Dtos;

namespace MoviesTheaterApplication.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUser(UserDto user);
        Task<UserDto> AuthenticateUser(UserDto user);
        Task<UserDto> GetUserByUsername(string username);
        string GenerateJwtToken(UserDto user);
    }

}
