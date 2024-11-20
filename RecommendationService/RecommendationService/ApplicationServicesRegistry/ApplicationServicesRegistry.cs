using Microsoft.EntityFrameworkCore;
using RecommendationService.DataBase;
using RecommendationService.Services;
using RecommentationService.DataBase;
using RecommentationService.Services;

namespace RecommendationService.ApplicationServicesRegistry
{
    public static class ApplicationServicesRegistry
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(RecommendationProfile));
            services.AddScoped<DbContext, RecommentationDbContext>();
            services.AddScoped<IRecommentationDataService, RecommentationDataService>();
            services.AddScoped<IRecommentationRepository, RecommentationRepository>();
            services.AddSingleton<HealthMetricsServiceClient>();
        }
    }
}
