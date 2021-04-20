using AutoMapper;
using BigRoom.Repository;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BigRoom.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            AssemblyScanner.FindValidatorsInAssembly(typeof(GroupValidator).Assembly)
              .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddRepository(configuration);
            services.AddAllService();
            return services;
        }
    }
}
