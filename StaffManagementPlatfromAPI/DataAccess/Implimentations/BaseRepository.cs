﻿using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
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
      
        public void Create(TEntity entity)
        {
            //_dbContex.Set<TEntity>().Add(entity);
          _dbSet.Add(entity);
            _dbContext.SaveChanges();
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
            var entityById = _dbSet.Find(id);
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
