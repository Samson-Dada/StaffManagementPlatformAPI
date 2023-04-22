using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        //Task<IEnumerable<Department>> GetAllDepartment();
        string DepartmentDescription(int id);
        void DepartmentWithStaff();

        Task<Department> CreateStaffWithDepartmentId(int id);

        void UpdateDepartmentDescription(int id, string description);

    }
}
