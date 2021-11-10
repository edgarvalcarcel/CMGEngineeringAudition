using Microsoft.AspNetCore.Builder;

namespace CMGEngineeringAudition.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "V1");
                options.DisplayRequestDuration();
            });
        }
    }
}