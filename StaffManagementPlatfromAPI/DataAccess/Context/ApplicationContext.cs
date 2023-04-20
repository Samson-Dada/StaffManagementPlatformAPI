using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Utilities;

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
            var department = new List<Department>()
            {
           new Department {
                Id = 1,
                Name ="IT & Software",
                Description = "ricoli in informati la prieghi opomo",
            },
            new Department {
                Id = 2,
                Name = "Sales & Marketing",
                Description = "ricoli in informat",
            },
              new Department {
                Id = 3,
                Name = "Account and Auditing",
                Description = "Salary, finanace",
            }, 
              new Department
              {
                  Id = 4,
                  Name = "Human Resources and Recruitment",
                  Description = "Human Resources and Training"
                  
              }
            };
            var staff = new List<Staff>()
            {
                 new Staff
                {
                    Id = 1,
                    FirstName = "Kemi",
                    LastName = "Salem",
                    Email = "joh@mail.com",
                    Phone = "234 555 555",
                    DepartmentName = "IT & Software",
                    DepartmentId = 1,
                    Salary = 80001.3M,
                      Role ="Software Tester"


                },
                new Staff
                {
                    Id = 2,
                    FirstName = "Brown",
                    LastName = "Seun",
                    Email = "brose@mail.com",
                    Phone = "234 555 555",
                    DepartmentId = 1,
                    DepartmentName = "IT & Software",
                    DateOfBirth = new DateTime(22 / 4 / 2021),
                    Salary = 60000.3M,
                      Role ="UI & UX Designer"

                },
                  new Staff
                  {
                      Id = 3,
                      FirstName = "John",
                      LastName = "Deo",
                      Email = "joh@mail.com",
                      Phone = "234 555 555",
                      DepartmentId = 2,
                      Role ="Software Engineer"
                  },
                    new Staff
                  {
                      Id = 4,
                      FirstName = "Obi",
                      LastName = "Emefiele",
                      Email = "obieme@mail.com",
                      Phone = "234 555 555",
                      DepartmentName= "Sales & Marketing",
                      DepartmentId = 2,
                      Role ="Product and Digital Marketing"
                  }

            };
            modelBuilder.Entity<Staff>().HasData(staff);
            modelBuilder.Entity<Department>().HasData(department);
        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
        
}
