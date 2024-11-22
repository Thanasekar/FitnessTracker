using AutoMapper;
using UserActivityService.Controllers.DataBase;
using UserActivityService.Entities;
using UserActivityService.Models;

namespace UserActivityService.Services
{
    public interface IUserActivityDetailService
    {
        UserActivityDetail CreateUserDetail(UserActivityCreateDto userDetail);
        UserActivityResponseDto GetUserDetailById(Guid userId);
        List<UserActivityResponseDto> GetAllUserDetails();
    }
    public class UserActivityDetailService : IUserActivityDetailService
    {
        private readonly IMapper _mapper;
        private readonly IUserActivityRepository _userActivityRepository;
        private readonly IUserDetailsServiceClient _userDetailsServiceClient;

        public UserActivityDetailService(IMapper mapper, IUserActivityRepository userActivityRepository,
            IUserDetailsServiceClient userDetailsServiceClient)
        {
            this._mapper = mapper;
            _userActivityRepository = userActivityRepository;
            _userDetailsServiceClient = userDetailsServiceClient;
        }

        public UserActivityDetail CreateUserDetail(UserActivityCreateDto userDetailDto)
        {
            var userDetail = _userDetailsServiceClient.GetUserDetailAsync(userDetailDto.UserId);

            if (userDetail.Result == null)
            {
                throw new ConflictException("User account not exists");
            }

            var userActivityDetail = new UserActivityDetail
            {
                FirstName = userDetail.Result.FirstName,
                LastName = userDetail.Result.LastName,
                Phone = userDetail.Result.Phone,
                Steps = userDetailDto.Steps,
                Id = userDetailDto.UserId,
                ExerciseMinutes = userDetailDto.ExerciseMinutes,
                Date = DateTime.Now
            };
            var user = _mapper.Map<UserActivityDetail>(userActivityDetail);

            _userActivityRepository.AddUserDetail(user);
            _userActivityRepository.SaveChanges();

            return user;
        }

        public UserActivityResponseDto GetUserDetailById(Guid userId)
        {
            try
            {
                var userDetail = _userActivityRepository.GetUserDetails(userId);

                return _mapper.Map<UserActivityResponseDto>(userDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "No user account found");
                return null;
            }
            
        }

        public List<UserActivityResponseDto> GetAllUserDetails()
        {
            return _mapper.Map<List<UserActivityResponseDto>>(_userActivityRepository.GetUserDetails());
        }
    }
}
