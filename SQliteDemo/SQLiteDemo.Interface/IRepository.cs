using System;
using System.Collections.Generic;

namespace SQLiteDemo.Interface
{
	public interface IRepository<TEntity> : IDisposable
	   where TEntity : class
	{
		void Insert(TEntity entity);
		void InsertAll(IList<TEntity> entities);

		void Update(TEntity entity);
		void UpdateAll(IList<TEntity> entities);

		void Delete(TEntity entity);
		void DeleteAll();

		IList<TEntity> GetAll();
	}
}
