using HealthMetricsService.DataBase;
using HealthMetricsService.Services;
using Microsoft.EntityFrameworkCore;

namespace HealthMetricsService.ApplicationServicesRegistry
{
    public static class ApplicationServicesRegistry
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddAutoMapper(typeof(HealthMetricsProfile));
            services.AddScoped<DbContext, HealthMetricsDbContext>();
            services.AddScoped<IHealthMetricsDetailService, HealthMetricsDetailService>();
            services.AddScoped<IHealthMetricsRepository, HealthMetricsRepository>();
            services.AddSingleton<UserActivityServiceClient>();
        }
    }
}
