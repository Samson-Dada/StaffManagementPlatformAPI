using Microsoft.EntityFrameworkCore;

namespace CompanyStaffManagement.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContex _applicationContex;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContex applicationContex)
        {
            _applicationContex = applicationContex;
            _dbSet = applicationContex.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }


        /*
public Task<IEnumerable<TEntity>> GetAllAsync()
{
throw new NotImplementedException();
}
*/
    }
}
