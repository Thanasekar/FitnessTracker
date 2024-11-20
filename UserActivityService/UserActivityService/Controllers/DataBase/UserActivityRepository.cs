using UserActivityService.Models;

namespace UserActivityService.Controllers.DataBase
{
    public interface IUserActivityRepository
    {
        public void AddUserDetail(UserActivityDetail userDetail);
        public bool AccountExists(long phone);
        public void SaveChanges();
        public UserActivityDetail GetUserDetails(Guid userId);
        public List<UserActivityDetail> GetUserDetails();
    }
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly UserActivityDetailDbContext _context;
        public UserActivityRepository(UserActivityDetailDbContext context)
        {
            _context = context;
        }

        public void AddUserDetail(UserActivityDetail userActivityDetail)
        {
            _context.UserActivityDetail.Add(userActivityDetail);
        }
        public bool AccountExists(long phone)
        {

            return _context.UserActivityDetail.Any(a => a.Phone == phone);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public UserActivityDetail GetUserDetails(Guid userId)
        {
            return _context?.UserActivityDetail?.FirstOrDefault(x => x.Id == userId) ?? throw new InvalidOperationException();
        }
        public List<UserActivityDetail> GetUserDetails()
        {
            return _context?.UserActivityDetail.ToList() ?? throw new InvalidOperationException();
        }
    }
}
