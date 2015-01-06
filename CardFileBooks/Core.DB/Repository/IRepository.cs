using System.Linq;

namespace Core.DB.Repository
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Get();
		TEntity GetById(object id);
		void Insert(TEntity entity);
		void Update(TEntity entity);
		void Delete(object id);
		void Delete(TEntity entity);
		RepositoryQuery<TEntity> Query();
	}
}