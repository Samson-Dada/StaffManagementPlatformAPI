using System.ComponentModel.DataAnnotations;

namespace StaffManagementPlatfromAPI.Domain.Models
{
    /// <summary>
    ///  The staff data to return back to the user
    /// </summary>
    public class StaffGetDto
    {

        public int Id { get; set; }
        [Required]
        //public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(25)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(150)]
        public string DepartmentDescription{ get; set; }

    }
}
