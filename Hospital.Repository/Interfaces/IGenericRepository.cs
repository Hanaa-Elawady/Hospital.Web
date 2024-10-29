namespace Hospital.Repository.Interfaces
{
	public interface IGenericRepository<TEntity>
	{
		Task<TEntity> GetByIdAsync(object id);
		Task<IReadOnlyList<TEntity>> GetAllAsync();
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}
}
