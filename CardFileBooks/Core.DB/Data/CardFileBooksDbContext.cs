using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Core.DB.Data
{
	public class CardFileBooksDbContext : IDbContext
	{
		private readonly CardFileBooks_ModelContainer _context = new CardFileBooks_ModelContainer();

		public IDbSet<T> Set<T>() where T : class
		{
			return _context.Set<T>();
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}

		public DbEntityEntry Entry(object o)
		{
			return _context.Entry(o);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}