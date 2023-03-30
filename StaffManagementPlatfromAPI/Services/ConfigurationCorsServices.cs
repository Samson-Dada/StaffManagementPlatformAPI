using Microsoft.Extensions.DependencyInjection;
namespace StaffManagementPlatfromAPI.Services

{
    public class ConfigurationCorsServices
    {
        public static void Configure(IServiceCollection services)
        {

            services.AddCors(optons =>
            optons.AddPolicy("corsPolicy", builder =>
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            ));
        }
    }
}
/*
 builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => { 
        policy.AllowAnyHeader()
        .AllowAnyOrigin(); });
});
 */