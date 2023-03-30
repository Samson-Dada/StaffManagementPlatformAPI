using System.Linq.Expressions;

namespace StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool IsExist(int id);


    }
}
