using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
