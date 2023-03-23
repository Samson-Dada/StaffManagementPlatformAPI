using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;
using System;

namespace StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        IEnumerable<Staff> GetAllStaff(int countStaff);
        Task<Staff> GetByIdAsync(int id);
        Task<bool> StaffExistsAsync(int StaffId);
        Task<bool> SaveChangesAsync();

    }
}
