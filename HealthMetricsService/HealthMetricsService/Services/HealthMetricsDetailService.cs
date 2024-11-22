using AutoMapper;
using HealthMetricsService.DataBase;
using HealthMetricsService.Entities;
using HealthMetricsService.Models;
using UserActivityService.Entities;
using UserActivityService.Services;

namespace HealthMetricsService.Services
{
    public interface IHealthMetricsDetailService    {
        HealthMetrics CreateHealthMetricsDetail(HealthMetricsCreateDto userDetail);
        HealthMetricsResponseDto GetHealthMetricsDetailById(Guid userId);
        List<HealthMetricsResponseDto> GetAllUSerHealthMetrics();
    }
    public class HealthMetricsDetailService : IHealthMetricsDetailService
    {
        private readonly IMapper _mapper;
        private readonly IHealthMetricsRepository _healthMetricsRepository;
        private readonly UserActivityServiceClient _userActivityServiceClient;

        public HealthMetricsDetailService(IMapper mapper, IHealthMetricsRepository healthMetricsRepository,
            UserActivityServiceClient userActivityServiceClient)
        {
            this._mapper = mapper;
            _healthMetricsRepository = healthMetricsRepository;
            _userActivityServiceClient = userActivityServiceClient;
        }

        public HealthMetrics CreateHealthMetricsDetail(HealthMetricsCreateDto userDetailDto)
        {
            var userActivityDetail = _userActivityServiceClient.GetUserActivityDetailAsync(userDetailDto.UserId);

            if (userActivityDetail.Result == null)
            {
                throw new ConflictException("User account not exists");
            }

            var healthMetrics = new HealthMetrics
            {
                Id = userDetailDto.UserId,
                FirstName = userActivityDetail.Result.FirstName,
                LastName = userActivityDetail.Result.LastName,
                Phone = userActivityDetail.Result.Phone,
                Steps = userActivityDetail.Result.Steps,
                
                ExerciseMinutes = userActivityDetail.Result.ExerciseMinutes,
                HeartRate = userDetailDto.HeartRate,
                CaloriesBurned = userDetailDto.CaloriesBurned,
                Date = DateTime.Now
            };
            var healthMetricsDetail = _mapper.Map<HealthMetrics>(healthMetrics);

            _healthMetricsRepository.AddHealthMetrics(healthMetricsDetail);
            _healthMetricsRepository.SaveChanges();

            return healthMetricsDetail;
        }

        public HealthMetricsResponseDto GetHealthMetricsDetailById(Guid userId)
        {
            var userDetail = _healthMetricsRepository.GetHealthMetricsDetail(userId);

            if (userDetail == null)
            {

                throw new NotFoundException("No user account has been found");
            }

            return _mapper.Map<HealthMetricsResponseDto>(userDetail);
        }

        public List<HealthMetricsResponseDto> GetAllUSerHealthMetrics()
        {
            return _mapper.Map<List<HealthMetricsResponseDto>>(_healthMetricsRepository.GetHealthMetricsDetails());
        }
    }
}
