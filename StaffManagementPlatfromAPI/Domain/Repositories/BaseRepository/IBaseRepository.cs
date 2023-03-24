using System.Linq.Expressions;

namespace StaffManagementPlatfromAPI.Domain.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
