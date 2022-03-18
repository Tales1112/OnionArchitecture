using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Persistence.Context;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Application.Mappings;

namespace Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                  .Assembly.FullName)));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToDTOMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
