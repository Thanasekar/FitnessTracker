using Microsoft.EntityFrameworkCore;
using UserActivityService.DataBase;
using UserActivityService.Services;

namespace UserActivityService.ApplicationServicesRegistry
{
    public static class ApplicationServicesRegistry
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddAutoMapper(typeof(UserDetailProfile));
            services.AddScoped<DbContext, UserActivityDetailDbContext>();
            services.AddScoped<IUserActivityDetailService, UserActivityDetailService>();
            services.AddScoped<IUserActivityRepository, UserActivityRepository>();
            services.AddSingleton<IUserDetailsServiceClient, UserDetailsServiceClient>();
        }
    }
}
