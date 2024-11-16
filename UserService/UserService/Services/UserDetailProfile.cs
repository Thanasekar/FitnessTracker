using AutoMapper;
using UserService.Entities;
using UserService.Models;

namespace UserService.Services
{
    public class UserDetailProfile : Profile
    {
        public UserDetailProfile()
        {
            CreateMap<UserDetailCreateDto,UserDetail>();
            CreateMap<UserDetail, UserDetailResponseDto>();
        }
        
    }
}
