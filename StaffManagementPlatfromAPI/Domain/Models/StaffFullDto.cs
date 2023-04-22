using StaffManagementPlatfromAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StaffManagementPlatfromAPI.Domain.Models
{
        /// <summary>
        /// A DTO for staff 
        /// </summary>
    public class StaffFullDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = new DateTime().ToLocalTime();

        //[Required]
        [MaxLength(30)]
        public string Role { get; set; } = string.Empty;
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName { get; set; }

    }
}

