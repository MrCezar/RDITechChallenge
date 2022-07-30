using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RDITechChallenge.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
