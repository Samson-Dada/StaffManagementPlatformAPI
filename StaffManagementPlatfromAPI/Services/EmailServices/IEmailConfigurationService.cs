using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Services.EmailServices
{
    public interface IEmailConfigurationService
    {
        Email GetConfiguration();
    }
}
