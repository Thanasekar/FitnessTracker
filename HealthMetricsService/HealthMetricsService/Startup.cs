using System.Text.Json.Serialization;
using HealthMetricsService.ApplicationServicesRegistry;
using HealthMetricsService.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;


namespace HealthMetricsService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.RegisterServices(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<HealthMetricsDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers(
                    options =>
                    {
                        options.Conventions.Add(new SwaggerControllerDocumentationConvention());
                    })
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }
        public void Configure(IApplicationBuilder app)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserActivityService v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
    public class SwaggerControllerDocumentationConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller == null)
                return;

            foreach (var attribute in controller.Attributes)
            {
                if (attribute.GetType() == typeof(RouteAttribute))
                {
                    var routeAttribute = (RouteAttribute)attribute;

                    if (!string.IsNullOrEmpty(routeAttribute.Name))
                    {
                        controller.ControllerName = routeAttribute.Name;
                    }
                }
            }
        }
    }
}
