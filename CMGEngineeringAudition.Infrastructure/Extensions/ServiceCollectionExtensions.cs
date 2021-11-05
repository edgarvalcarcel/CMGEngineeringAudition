using CMGEngineeringAudition.Application.Interfaces.CacheRepositories;
using CMGEngineeringAudition.Application.Interfaces.Contexts;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using CMGEngineeringAudition.Infrastructure.CacheRepositories;
using CMGEngineeringAudition.Infrastructure.DbContexts;
using CMGEngineeringAudition.Infrastructure.Repositories;
using CMGEngineeringAudition.Infrastructure.SystemParameter;
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
            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
            services.AddTransient<IConfigurationCacheRepository, ConfigurationCacheRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IConfigutationParameterCacheRepository, SystemParameterCacheRepository>();
            services.AddTransient<IConfigurationSystemPrameterRepository, ConfigurationSystemParameterRepository>();

            #endregion
        }
    }
}
