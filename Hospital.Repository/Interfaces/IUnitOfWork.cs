namespace Hospital.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepository<TEntity> Repository<TEntity>();
		Task<int> CompleteAsync();
	}
}
