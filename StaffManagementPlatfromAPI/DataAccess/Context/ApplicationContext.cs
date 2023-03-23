using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Models;
using System.Net;
using System.Numerics;

namespace StaffManagementPlatfromAPI.DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var department = new List<Department> (){ 
           new Department {
                Id = 1,
                Name ="IT",
                Description = "ricoli in informati la prieghi opomo",
            },
            new Department {
                Id = 2,
                Name = "Sales & Marketing",
                Description = "ricoli in informat",
            },
            };
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Deo",
                    Email = "joh@mail.com",
                    Phone = "234 555 555",
                    DepartmentId = 1,
                    Salary = 80001.3M

                },
                new Staff
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Deo",
                    Email = "joh@mail.com",
                    Phone = "234 555 555",
                    DepartmentId = 2,
                    DateOfBirth = new DateTime(22/4/2021),
                    Salary = 60000.3M
                },
                  new Staff
                  {
                      Id = 3,
                      FirstName = "John",
                      LastName = "Deo",
                      Email = "joh@mail.com",
                      Phone = "234 555 555",
                      DepartmentId = 2,
                  }
                );
            modelBuilder.Entity<Department>().HasData(department);
        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
        
}
