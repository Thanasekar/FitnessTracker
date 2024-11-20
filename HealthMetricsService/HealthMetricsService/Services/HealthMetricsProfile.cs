using AutoMapper;
using HealthMetricsService.Entities;
using HealthMetricsService.Models;
using UserActivityService.Entities;

namespace HealthMetricsService.Services
{
    public class HealthMetricsProfile : Profile
    {
        public HealthMetricsProfile()
        {
            CreateMap<HealthMetricsCreateDto, HealthMetrics>();
            CreateMap<HealthMetrics, HealthMetricsResponseDto>();
        }
        
    }
}
