namespace StaffManagementPlatfromAPI.Services
{
    public class ConfigurationCorsServices
    {


        public ConfigurationCorsServices(IServiceCollection services)
        {
                services.AddCors(optons => 
                optons.AddPolicy("corsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                ));
        }
    }
}

