using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStaffRepository Staff{ get; }
        IDepartmentRepository Department { get; }
        int Save();
    }
}
