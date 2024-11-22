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
            try
            {
                if (_userAccountRepository.AccountExists(userDetailDto.Email, userDetailDto.Phone))
                {
                    throw new ConflictException("User Email or Phone already exists");
                }

                var user = _mapper.Map<UserDetail>(userDetailDto);

                _userAccountRepository.AddUserDetail(user);
                _userAccountRepository.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "User Email or Phone already exists");
               
            }
            return null;
        }

        public UserDetailResponseDto GetUserDetailById(Guid userId)
        {
            try
            {
                var userDetail = _userAccountRepository.GetUserDetails(userId);
                return _mapper.Map<UserDetailResponseDto>(userDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "No user account has been found");
                
            }
            return null;
        }

        public List<UserDetailResponseDto> GetAllUserDetails()
        {
            return _mapper.Map<List<UserDetailResponseDto>>(_userAccountRepository.GetUserDetails());
        }
    }
}
