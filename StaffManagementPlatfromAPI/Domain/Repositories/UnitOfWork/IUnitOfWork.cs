using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStaffRepository StaffRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        void Save();
    }
}
