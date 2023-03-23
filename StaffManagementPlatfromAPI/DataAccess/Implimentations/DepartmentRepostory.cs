using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class DepartmentRepostory : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationContext _dbContext;
        public DepartmentRepostory(ApplicationContext dbContex) : base(dbContex)
        {
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            var allDepartment = await _dbContext.Departments.OrderBy(d => d.Name).ToListAsync();
            return allDepartment;
        }

        public string GetDepartmentDescription(int id)
        {
            throw new NotImplementedException();
        }
    }
}
