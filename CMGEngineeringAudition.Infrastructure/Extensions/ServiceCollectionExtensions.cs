using CMGEngineeringAudition.Application.Interfaces.Contexts;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using CMGEngineeringAudition.Infrastructure.DbContexts;
using CMGEngineeringAudition.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMGEngineeringAudition.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuditionRepository, AuditionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
