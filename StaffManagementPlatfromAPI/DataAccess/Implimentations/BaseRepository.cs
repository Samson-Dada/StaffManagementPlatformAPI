using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository;
using System.Linq.Expressions;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly ApplicationContext _dbContext;

        public BaseRepository(ApplicationContext dbContex)
        {
            _dbContext = dbContex;
            _dbSet = dbContex.Set<TEntity>();
        }
      
        public async Task Create(TEntity entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            //_dbContex.Set<TEntity>().Add(entity);
              await _dbSet.AddAsync(entity);
          await _dbContext.SaveChangesAsync();


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
        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entityById = await _dbSet.FindAsync(id);
            return entityById;
        }
        public bool IsExist(int id)
        {
            return _dbContext.Departments.Any(d => d.Id == id);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
      
    }
}
