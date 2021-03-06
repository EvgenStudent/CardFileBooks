﻿using System;
using System.Collections;
using System.Data.Entity.Infrastructure;
using Core.DB.Data;

namespace Core.DB.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private bool _disposed;
		private Hashtable _repositories;
		private readonly IDbContext _context;

		public UnitOfWork(IDbContext context)
		{
			_context = context;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
				if (disposing)
					_context.Dispose();

			_disposed = true;
		}

		public DbEntityEntry Entry(object o)
		{
			return _context.Entry(o);
		}

		public IRepository<T> Repository<T>() where T : class
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var type = typeof (T).Name;

			if (!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof (Repository<>);

				var repositoryInstance =
					Activator.CreateInstance(repositoryType
						.MakeGenericType(typeof (T)), _context);

				_repositories.Add(type, repositoryInstance);
			}

			return (IRepository<T>) _repositories[type];
		}
	}
}