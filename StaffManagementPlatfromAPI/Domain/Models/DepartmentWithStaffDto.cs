using StaffManagementPlatfromAPI.Domain.Entities;

namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class DepartmentWithStaffDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Staff> Staff { get; set; }
    }
}
