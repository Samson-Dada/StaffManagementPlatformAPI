using System.ComponentModel.DataAnnotations;

namespace StaffManagementPlatfromAPI.Domain.Entities
{
    public class Department
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<Staff> Staffs { get; set; }
            = new List<Staff>();
    }
}