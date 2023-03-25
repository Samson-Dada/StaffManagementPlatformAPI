using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        //Task<IEnumerable<Department>> GetAllDepartment();
        string DepartmentDescription(int id);
        IEnumerable<Department> DepartmentWithStaff();

        void UpdateDepartmentDescription(int id, string description);
    }
}
