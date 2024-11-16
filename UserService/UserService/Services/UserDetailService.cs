using AutoMapper;
using UserService.DataBase;
using UserService.Entities;
using UserService.Models;

namespace UserService.Services
{
    public interface IUserDetailService
    {
        UserDetail CreateUserDetail(UserDetailCreateDto userDetail);
        UserDetailResponseDto GetUserDetailById(Guid userId);
        List<UserDetailResponseDto> GetAllUserDetails();
    }
    public class UserDetailService : IUserDetailService
    {
        private readonly IMapper _mapper;
        private readonly IUserAccountRepository _userAccountRepository;

        public UserDetailService(IMapper mapper, IUserAccountRepository userAccountRepository)
        {
            this._mapper = mapper;
            _userAccountRepository = userAccountRepository;
        }

        public UserDetail CreateUserDetail(UserDetailCreateDto userDetailDto)
        {
            if (_userAccountRepository.AccountExists(userDetailDto.Email))
            {
                throw new ConflictException("User account already exists");
            }

            var user = _mapper.Map<UserDetail>(userDetailDto);

            _userAccountRepository.AddUserDetail(user);
            _userAccountRepository.SaveChanges();

            return user;
        }

        public UserDetailResponseDto GetUserDetailById(Guid userId)
        {
            var userDetail = _userAccountRepository.GetUserDetails(userId);

            if (userDetail == null)
            {

                throw new NotFoundException("No user account has been found");
            }

            return _mapper.Map<UserDetailResponseDto>(userDetail);
        }

        public List<UserDetailResponseDto> GetAllUserDetails()
        {
            return _mapper.Map<List<UserDetailResponseDto>>(_userAccountRepository.GetUserDetails());
        }
    }
}
