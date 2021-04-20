using BigRoom.Repository.IRepository;
using BigRoom.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
namespace BigRoom.Repository
{
    internal static class InjectRepository
    {
        internal static IServiceCollection AddAllRepository(this IServiceCollection services)
        {
            var allProviderTypes = Assembly.GetAssembly(typeof(IRepositoryAsync<>))
             .GetTypes().Where(t => t.Namespace !=null).ToList();
            foreach (var intfc in allProviderTypes.Where(t => t.IsInterface))
            {
                var impl = allProviderTypes.FirstOrDefault(c => c.IsClass && intfc.Name.Substring(1) == c.Name);
                if (impl != null) services.AddScoped(intfc, impl);
            }
            return services;
        }
    }
}
