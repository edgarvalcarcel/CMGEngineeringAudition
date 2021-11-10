using Audit.Core;
using Audit.WebApi;
using CMGEngineeringAudition.WebAPI.Middlewares;
using CMGEngineeringAudition.Application.Extensions;
using CMGEngineeringAudition.Infrastructure.Extensions;
using CMGEngineeringAudition.WebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CMGEngineeringAudition.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddContextInfrastructure(Configuration);
            services.AddPersistenceContexts(Configuration);
            services.AddRepositories();
            services.AddSharedInfrastructure(Configuration);
            services.AddEssentials();

            services.AddControllers();

            services.AddMvc(o =>
            { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            Audit.Core.Configuration.Setup()
               .UseSqlServer(config => config
               .ConnectionString(Configuration.GetValue<string>("ConnectionStrings:ApplicationConnection"))
               .Schema("dbo")
               .TableName("AuditLog")
               .IdColumnName("Id")
               .JsonColumnName("JsonData")
               .LastUpdatedColumnName("LastUpdatedDate")
               .CustomColumn("EventType", ev => ev.EventType)
               .CustomColumn("NetworktUser", ev => ev.Environment.UserName)
               .CustomColumn("AuthUserId", ev => ev.Environment.UserName)
               .CustomColumn("IpAddress", ev => ev.GetWebApiAuditAction().IpAddress));
            //app.UseHttpsRedirection();
            //app.UseRouting();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
