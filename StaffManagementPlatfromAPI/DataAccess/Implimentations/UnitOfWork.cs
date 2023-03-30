using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;
        public UnitOfWork(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            DepartmentRepository = new DepartmentRepository(_dbContext);
            StaffRepository = new StaffRepository(_dbContext);
        }

        public IStaffRepository StaffRepository { get; private set; }

        public IDepartmentRepository DepartmentRepository { get; private set; }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public int Save()
        {
           return _dbContext.SaveChanges();
        }
    }
}
