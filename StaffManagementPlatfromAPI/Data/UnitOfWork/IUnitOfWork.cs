using CompanyStaffManagement.Data.Repositories;
using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBaseRepository<Staff> BaseRepository { get; }
        IBaseRepository<Department> DepartmentRepository { get; }

        void Save();
    }
}
