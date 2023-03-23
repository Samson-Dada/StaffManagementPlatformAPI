using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository<Staff> BaseRepository => throw new NotImplementedException();

        public IBaseRepository<Department> DepartmentRepository => throw new NotImplementedException();

        public IStaffRepository StaffRepository => throw new NotImplementedException();

        IDepartmentRepository IUnitOfWork.DepartmentRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
