using System.ComponentModel.DataAnnotations;

namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class DepartmentGetDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
