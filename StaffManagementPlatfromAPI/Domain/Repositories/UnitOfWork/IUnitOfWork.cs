using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;

namespace StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IStaffRepository StaffRepository{ get; }
        IDepartmentRepository DepartmentRepository { get; }
      Task<int> SaveAsync();
    }
}
