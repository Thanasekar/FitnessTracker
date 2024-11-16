using Microsoft.EntityFrameworkCore;
using UserService.DataBase;
using UserService.Services;

namespace UserService.ApplicationServicesRegistry
{
    public static class ApplicationServicesRegistry
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(UserDetailProfile));
            services.AddScoped<DbContext, UserDetailDbContext>();
            services.AddScoped<IUserDetailService, UserDetailService>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        }
    }
}
