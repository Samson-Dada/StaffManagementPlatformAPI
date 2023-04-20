using StaffManagementPlatfromAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// 
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// The FullName of the Staff
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
        public DateTime Age { get; set; }
        /// <summary>
        /// The DateOfBirth of the Staff
        /// 
        /// </summary>

        /// <summary>
        /// The Address of the Staff
        /// 
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Role of the Staff
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The Salary of the Satt
        /// </summary>
        public decimal Salary { get; set; }


        /// <summary>
        /// Date of Employement
        /// </summary>
        public DateTime HireDate { get; set; }
        public string DepartmentName { get; set; }



        //[ForeignKey("DepartmentId")]
        //public Department Department { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DepartmentId { get; set; }
    }
}


/*
 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManagementPlatfromAPI.Domain.Entities
{
    public class Staff
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
        public string DepartmentName { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

    }
}


 
 
 */
