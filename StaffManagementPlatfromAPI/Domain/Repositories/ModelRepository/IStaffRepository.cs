using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Task<IEnumerable<Staff>> GetStaffByDepartment(int DepartmentId);
        Task<IEnumerable<Staff>> GetAllFullNameAsync(string searchNames);
        Task<bool> StaffExistsAsync(int StaffId);

        Task<Staff> GetStaffByFullNameAsync(string fullName);
    }
}
