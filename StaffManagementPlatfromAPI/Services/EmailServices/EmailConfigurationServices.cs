using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Services.EmailServices
{
    public class EmailConfigurationServices : IEmailConfigurationService
    {
        private readonly IConfiguration _config;
        public EmailConfigurationServices(IConfiguration config)
        {
            _config = config;
        }

        public Email GetConfiguration()
        {
            var configuration = new Email
            {
                SmtpServer = _config["DummyEmailConfiguration:SmtpServer"],
                Port = int.Parse(_config["DummyEmailConfiguration:Port"]),
                Username = _config["DummyEmailConfiguration:Username"],
                Password = _config["DummyEmailConfiguration:Password"],
                FromAddress = _config["DummyEmailConfiguration:FromAddress"]
            };
            return configuration;
        }
    }
}
