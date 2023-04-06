using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace StaffManagementPlatfromAPI.Services

{
    public class ConfigurationCorsServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddCors(options =>
             options.AddDefaultPolicy(policy => {
                 policy.AllowAnyHeader()
                 .AllowAnyOrigin();
             })
          );
        }
    }
}
