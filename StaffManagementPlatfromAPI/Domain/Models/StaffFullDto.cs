using StaffManagementPlatfromAPI.Domain.Entities;

namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class StaffFullDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = new DateTime().ToLocalTime();
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; } = null;
        public int DepartmentId { get; set; }
    }
}
