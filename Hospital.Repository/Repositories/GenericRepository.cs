using Hospital.Data.Contexts;
using Hospital.Repository.Interfaces;
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

		public void Delete(TEntity entity)
			=>  _context.Set<TEntity>().Remove(entity);

		public async Task<IReadOnlyList<TEntity>> GetAllAsync()
			=> await _context.Set<TEntity>().ToListAsync();

		public async Task<TEntity> GetByIdAsync(object id)
			=> await _context.Set<TEntity>().FindAsync(id);


		public void Update(TEntity entity)
		   => _context.Set<TEntity>().Update(entity);
	}
}
