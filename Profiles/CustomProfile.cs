using AutoMapper;
using SimpleCrudDotNetSix.Dtos;
using SimpleCrudDotNetSix.Models;

namespace SimpleCrudDotNetSix.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDetailsDto>().ReverseMap();
            CreateMap<UserAddDto, User>();
                        
        }
    }
}
