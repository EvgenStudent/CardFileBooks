using System.Data.Entity.Infrastructure;

namespace Core.DB.Repository
{
	public interface IUnitOfWork
	{
		void Dispose();
		void Save();
		void Dispose(bool disposing);
		DbEntityEntry Entry(object o);
		IRepository<T> Repository<T>() where T : class;
	}
}