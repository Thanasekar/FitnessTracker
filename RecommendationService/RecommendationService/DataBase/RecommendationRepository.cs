using RecommendationService.DataBase;
using RecommendationService.Models;


namespace RecommentationService.DataBase
{
    public interface IRecommentationRepository
    {
        void AddRecommendation(RecommentationDetail recommendation);
        RecommentationDetail GetRecommendation(Guid userId);
        public void SaveChanges();
    }
    public class RecommentationRepository : IRecommentationRepository
    {
        private readonly RecommentationDbContext _context;
        public RecommentationRepository(RecommentationDbContext context)
        {
            this._context = context;
        }

        public void AddRecommendation(RecommentationDetail recommendation)
        {
            _context.Recommendation.Add(recommendation);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public RecommentationDetail GetRecommendation(Guid userId)
        {
            return _context?.Recommendation?.FirstOrDefault(x => x.Id == userId) ?? throw new InvalidOperationException();
        }
    }
}
