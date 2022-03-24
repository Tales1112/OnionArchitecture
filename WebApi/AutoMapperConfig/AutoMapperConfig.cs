using Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApi.AutoMapperConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentException(nameof(services));
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}
