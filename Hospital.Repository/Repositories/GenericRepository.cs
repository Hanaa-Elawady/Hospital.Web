using Hospital.Data.Contexts;
using Hospital.Repository.Interfaces;
using Hospital.Repository.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly HospitalDbContext _context;

		public GenericRepository(HospitalDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(TEntity entity)
			=> await _context.Set<TEntity>().AddAsync(entity);

		public void Update(TEntity entity)
		    => _context.Set<TEntity>().Update(entity);

		public void Delete(TEntity entity)
			=>  _context.Set<TEntity>().Remove(entity);

		public async Task<int> CountSpecificationsAsync(ISpecifications<TEntity> specs)
				=> await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).CountAsync();

		public async Task<TEntity> GetByIdWithSpecificationsAsync(ISpecifications<TEntity> specs)
		=> await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).FirstOrDefaultAsync();

		public async Task<TEntity> GetByNameWithSpecificationsAsync(ISpecifications<TEntity> specs)
		=> await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).FirstOrDefaultAsync();

		public async Task<IReadOnlyList<TEntity>> GetAllWithSpecificationsAsync(ISpecifications<TEntity> specs)
		=> await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).ToListAsync();

		public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingWithSpecificationsAsync(ISpecifications<TEntity> specs)
		=> await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).AsNoTracking().ToListAsync();

	}
}
