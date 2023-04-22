using System.ComponentModel.DataAnnotations;

namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class DepartmentCreateDto
    {
       
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
