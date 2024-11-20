using HealthMetricsService.Models;

namespace HealthMetricsService.DataBase
{
    public interface IHealthMetricsRepository
    {
         void AddHealthMetrics(HealthMetrics userDetail);
         bool AccountExists(Guid id);
         void SaveChanges();
         HealthMetrics GetHealthMetricsDetail(Guid userId);
         List<HealthMetrics> GetHealthMetricsDetails();
    }
    public class HealthMetricsRepository : IHealthMetricsRepository
    {
        private readonly HealthMetricsDbContext _context;
        public HealthMetricsRepository(HealthMetricsDbContext context)
        {
            _context = context;
        }

        public void AddHealthMetrics(HealthMetrics healthMetrics)
        {
            _context.HealthMetricsDetail.Add(healthMetrics);
        }
        public bool AccountExists(Guid id)
        {

            return _context.HealthMetricsDetail.Any(a => a.Id == id);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public HealthMetrics GetHealthMetricsDetail(Guid userId)
        {
           return _context?.HealthMetricsDetail.FirstOrDefault(x => x.Id == userId) ?? throw new InvalidOperationException();
        }

        public List<HealthMetrics> GetHealthMetricsDetails()
        {
            return _context?.HealthMetricsDetail.ToList() ?? throw new InvalidOperationException();
        }
    }
}
