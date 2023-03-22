using CompanyStaffManagement.Data.Repositories;
using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository<Staff> BaseRepository => throw new NotImplementedException();

        public IBaseRepository<Department> DepartmentRepository => throw new NotImplementedException();

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
