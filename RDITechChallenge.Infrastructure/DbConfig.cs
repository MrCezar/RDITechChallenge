using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RDITechChallenge.Infrastructure.Data;

namespace RDITechChallenge.Infrastructure
{
    public static class DbConfig
    {
        public static IServiceCollection AddDbConfig(this IServiceCollection services)
        {
            return services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("RDITechChallengeDb"));
        }
    }
}
