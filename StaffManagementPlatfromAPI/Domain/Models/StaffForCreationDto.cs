using System.ComponentModel.DataAnnotations;

namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class StaffForCreationDto
    {
        [Required]
        public int Age { get; set; }

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
        [StringLength(25)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        //[Required]
        //public int DepartmentId { get; set; }


    }
}
