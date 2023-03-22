namespace CompanyStaffManagement.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByNameAsync(string name);
        Task<IQueryable<TEntity>> GetAllAsync();
        void Delete(object entity);
        //void Delete(int id);

        /*
        IQueryable<TEntity> GetAll(bool trackChange);
        IQueryable<TEntity> GetAll(bool trackChange);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition, bool trackChanges);
         
         */
    }
}
