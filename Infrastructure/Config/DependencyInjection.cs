using EssentialsSupps_Backend.Application.Interfaces;
using EssentialsSupps_Backend.Application.Services;
using EssentialsSupps_Backend.Domain.Interfaces;
using EssentialsSupps_Backend.Infrastructure.Repository;

namespace EssentialsSupps_Backend.Infrastructure.Config
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
