using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;
using System.Linq.Expressions;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly ApplicationContext _dbContex;

        public BaseRepository(ApplicationContext dbContex)
        {
            _dbContex = dbContex;
            _dbSet = dbContex.Set<TEntity>();
        }
      
        public void Create(TEntity entity)
        {
            //_dbContex.Set<TEntity>().Add(entity);
          _dbSet.Add(entity);
            _dbContex.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var allEntity = await _dbSet.ToListAsync();
            return allEntity;
        }

        public async Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var getByCondition = await _dbSet.Where(predicate).ToListAsync();
            return getByCondition;
        }

        public TEntity GetById(int id)
        {
               var entityById =  _dbSet.Find(id);
          return  entityById;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContex.Entry(entity).State = EntityState.Modified;
            _dbContex.SaveChanges();
        }
    }
}
