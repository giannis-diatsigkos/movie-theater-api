using AutoMapper;
using MoviesTheaterApplication.Dtos;
using MoviesTheaterApplication.Persistence.Entities;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserDto, UserEntity>().ReverseMap();
        CreateMap<UserDetailsDto, UserEntity>().ReverseMap();// Map UserDto to User
        CreateMap<UserDetailsDto, UserDto>().ReverseMap();// Map UserDto to User
        CreateMap<CreateMovieDto, MovieEntity>().ReverseMap();
        CreateMap<MovieDto, MovieEntity>().ReverseMap();
        CreateMap<MovieDto, CreateMovieDto>().ReverseMap();
        CreateMap<LikedMovieDto, LikedMovieEntity>().ReverseMap();
        // Add more mappings as needed
    }
}
