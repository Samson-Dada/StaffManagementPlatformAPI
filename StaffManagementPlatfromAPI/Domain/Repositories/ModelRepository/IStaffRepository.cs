using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Task<bool> StaffExistsAsync(int StaffId);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Staff>> GetStaffByDepartment(int DepartmentId);
       Task<IEnumerable<Staff>> GetFullNameAsync(string searchNames);

    }
}
