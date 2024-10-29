﻿using Hospital.Data.Contexts;
using Hospital.Repository.Interfaces;
using System.Collections;

namespace Hospital.Repository.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly HospitalDbContext _context;
		private Hashtable _repositories;
		public UnitOfWork(HospitalDbContext context)
		{
			_context = context;
		}

		public async Task<int> CompleteAsync()
		=>	await _context.SaveChangesAsync();

		public IGenericRepository<TEntity> Repository<TEntity>()
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var entityKey = typeof(TEntity).Name;

			if (!_repositories.ContainsKey(entityKey))
			{
				var repositoryType = typeof(GenericRepository<>);
				var erpositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
				_repositories.Add(entityKey, erpositoryInstance);
			}

			return (IGenericRepository<TEntity>)_repositories[entityKey];
		}
	}
}
