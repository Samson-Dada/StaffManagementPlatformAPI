using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationContext _dbContext;
        public DepartmentRepository(ApplicationContext dbContex) : base(dbContex)
        {
           _dbContext = dbContex;
        }



        //public async Task<IEnumerable<Department>> GetAllDepartment()
        //{
        //    var allDepartment = await _dbContext.Departments.OrderBy(d => d.Name).ToListAsync();
        //    return allDepartment;
        //}

        public string GetDepartmentDescription(int id)
        {
            var departmentDesc = _dbContext.Departments.FirstOrDefault(x => x.Equals(id));
            return departmentDesc?.Description;
        }
        public IEnumerable<Department> GetDepartmentWithStaff()
        {
            var departmentWitStaff =  _dbContext.Departments.Include(s => s.Staffs).ToList();
            return departmentWitStaff;  
        }

        public Department UpdateDescription(int id, string description)
        {
            throw new NotImplementedException();
        }
    }
}
