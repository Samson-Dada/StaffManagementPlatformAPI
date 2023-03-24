using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        //Task<IEnumerable<Department>> GetAllDepartment();
        string GetDepartmentDescription(int id);
        IEnumerable<Department> GetDepartmentWithStaff();

        Department UpdateDescription(int id, string description);
    }
}
