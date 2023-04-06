namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class StaffPartialDetailsDto
    {

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DepartmentName { get; set; }
    }
}
