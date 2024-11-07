using Hospital.Repository.Specifications;

namespace Hospital.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<TEntity> GetByIdWithSpecificationsAsync(ISpecifications<TEntity> specs);
        Task<TEntity> GetByNameWithSpecificationsAsync(ISpecifications<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecificationsAsync(ISpecifications<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingWithSpecificationsAsync(ISpecifications<TEntity> specs);
        Task<int> CountSpecificationsAsync(ISpecifications<TEntity> specs);
        public Task<TEntity> GetByIdAsync(int? id);


    }
}
