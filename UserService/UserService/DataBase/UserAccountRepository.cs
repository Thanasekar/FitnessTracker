using UserService.Models;

namespace UserService.DataBase
{
    public interface IUserAccountRepository
    {
        public void AddUserDetail(UserDetail userDetail);
        public bool AccountExists(string? email = null);
        public void SaveChanges();
        public UserDetail GetUserDetails(Guid userId);
        public List<UserDetail> GetUserDetails();
    }
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly UserDetailDbContext _context;
        public UserAccountRepository(UserDetailDbContext context)
        {
            this._context = context;
        }

        public void AddUserDetail(UserDetail userDetail)
        {
            _context.UserDetail.Add(userDetail);
        }
        public bool AccountExists(string? email = null)
        {

            return _context.UserDetail.Any(a => (a.Email == email));
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public UserDetail GetUserDetails(Guid userId)
        {
            return _context?.UserDetail?.FirstOrDefault(x => x.Id == userId) ?? throw new InvalidOperationException();
        }
        public List<UserDetail> GetUserDetails()
        {
            return _context?.UserDetail.ToList() ?? throw new InvalidOperationException();
        }
    }
}
