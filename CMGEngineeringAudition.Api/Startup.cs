using Audit.Core;
using Audit.WebApi;
using CMGEngineeringAudition.Api.Extensions;
using CMGEngineeringAudition.Api.Middlewares;
using CMGEngineeringAudition.Application.Extensions;
using CMGEngineeringAudition.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CMGEngineeringAudition.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddContextInfrastructure(_configuration);
            services.AddPersistenceContexts(_configuration);
            services.AddRepositories();
            services.AddSharedInfrastructure(_configuration);
            services.AddEssentials();
            services.AddControllers();
            services.AddMvc(o =>
            {});
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureSwagger();
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Configuration.Setup()
               .UseSqlServer(config => config
               .ConnectionString(_configuration.GetValue<string>("ConnectionStrings:ApplicationConnection"))
               .Schema("dbo")
               .TableName("AuditLog")
               .IdColumnName("Id")
               .JsonColumnName("JsonData")
               .LastUpdatedColumnName("LastUpdatedDate")
               .CustomColumn("EventType", ev => ev.EventType)
               .CustomColumn("NetworktUser", ev => ev.Environment.UserName)
               .CustomColumn("AuthUserId", ev => ev.Environment.UserName ) 
               .CustomColumn("IpAddress", ev => ev.GetWebApiAuditAction().IpAddress));
        }
    }
}
