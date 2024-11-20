using AutoMapper;
using UserActivityService.Entities;
using UserActivityService.Models;
using UserActivityService.Services;

namespace UserActivityService.Services
{
    public class UserDetailProfile : Profile
    {
        public UserDetailProfile()
        {
            CreateMap<UserActivityCreateDto, UserActivityDetail>();
            CreateMap<UserActivityDetail, UserActivityResponseDto>();
        }
        
    }
}
