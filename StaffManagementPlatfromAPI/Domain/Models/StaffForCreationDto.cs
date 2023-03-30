namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class StaffForCreationDto
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string Name { get; set; } = string.Empty;
        //public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

    }
}
