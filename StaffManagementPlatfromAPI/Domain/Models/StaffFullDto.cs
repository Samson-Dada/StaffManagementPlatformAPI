using StaffManagementPlatfromAPI.Domain.Entities;

namespace StaffManagementPlatfromAPI.Domain.Models
{
        /// <summary>
        /// A DTO for staff 
        /// </summary>
    public class StaffFullDto
    {
        /// <summary>
        /// The id of the city
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The id of the Staff
        /// 
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// The FirstName of the Staff
        /// 
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// The LastName of the Staff
        /// 
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// The LastName id of the Staff
        /// 
        /// </summary>
        public string Phone { get; set; } = string.Empty;
        /// <summary>
        /// The Phone of the Staff
        /// 
        /// </summary>
        public DateTime DateOfBirth { get; set; } = new DateTime().ToLocalTime();
        /// <summary>
        /// The DateOfBirth of the Staff
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The Address of the Staff
        /// 
        /// </summary>
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
