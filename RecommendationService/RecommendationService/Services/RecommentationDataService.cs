using AutoMapper;
using RecommendationService.Entities;
using RecommendationService.Models;
using RecommendationService.Services;
using RecommentationService.DataBase;

namespace RecommentationService.Services
{
    public interface IRecommentationDataService
    {
        RecommentationDetail CreateRecommendation(RecommentationDetail recommendation);
        RecommendationResponseDto GetRecommendationById(Guid userId);
        RecommentationDetail GenerateRecommendation(Guid userId);
    }
    public class RecommentationDataService : IRecommentationDataService
    {
        private readonly IMapper _mapper;
        private readonly IRecommentationRepository _recommentationRepository;
        private readonly HealthMetricsServiceClient _healthMetricsServiceClient;

        public RecommentationDataService(IMapper mapper, 
            IRecommentationRepository recommentationRepository,
            HealthMetricsServiceClient healthMetricsServiceClient)
        {
            this._mapper = mapper;
            _recommentationRepository = recommentationRepository;
            _healthMetricsServiceClient = healthMetricsServiceClient;
        }
        public RecommentationDetail CreateRecommendation(RecommentationDetail recommendation)
        {
            var recommendationData = _mapper.Map<RecommentationDetail>(recommendation);

            _recommentationRepository.AddRecommendation(recommendationData);
            _recommentationRepository.SaveChanges();

            return recommendation;
        }


        public RecommendationResponseDto GetRecommendationById(Guid userId)
        {
            var userDetail = _recommentationRepository.GetRecommendation(userId);

            if (userDetail == null)
            {

                throw new NotFoundException("No user account has been found");
            }

            return _mapper.Map<RecommendationResponseDto>(userDetail);
        }
        public RecommentationDetail GenerateRecommendation(Guid userId)
        {
            var recommendation = new RecommentationDetail();
            
            var healthMetrics = _healthMetricsServiceClient.GetHealthMetricsAsync(userId);

            if (healthMetrics?.Result != null)
            {
                if (healthMetrics.Result.Steps > 10000 && healthMetrics.Result.CaloriesBurned > 500)
                {
                    recommendation.Recommendation = "Great job staying active today! Keep up the good work.";
                }
                else if (healthMetrics.Result.HeartRate > 100)
                {
                    recommendation.Recommendation = "Your heart rate is elevated. Consider relaxing and staying hydrated.";
                }
                else
                {
                    recommendation.Recommendation = "Keep moving! Aim for at least 10,000 steps daily.";
                }
            }

            recommendation.Id = userId;
            recommendation.Steps = healthMetrics.Result.Steps;
            recommendation.ExerciseMinutes = healthMetrics.Result.ExerciseMinutes;
            recommendation.HeartRate = healthMetrics.Result.HeartRate;
            recommendation.CaloriesBurned = healthMetrics.Result.CaloriesBurned;
            recommendation.Date = DateTime.Now;
            return recommendation;
        }
    }
}
