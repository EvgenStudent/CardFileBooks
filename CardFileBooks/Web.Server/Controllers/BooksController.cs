using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Core.DB;
using Core.DB.Repository;
using Core.Entities.DTOs;

namespace Web.Server.Controllers
{
	public class BooksController : ApiController
	{
		private readonly IUnitOfWork _unitOfWork;

		public BooksController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		// GET: api/Books
		public IQueryable<BookDTO> GetBooks()
		{
			return _unitOfWork.Repository<Book>().Get().Project().To<BookDTO>();
		}

/*
		// GET: api/Books/5
		[ResponseType(typeof (BookDTO))]
		public async Task<IHttpActionResult> GetBook(int id)
		{
			var book = await db.Books.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<BookDTO>(book));
		}

		// PUT: api/Books/5
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutBook(int id, BookDTO bookDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var book = Mapper.Map<Book>(bookDto);

			if (id != book.BookId)
			{
				return BadRequest();
			}

			db.Entry(book).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BookExists(id))
				{
					return NotFound();
				}
				throw;
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/Books
		[ResponseType(typeof (Book))]
		public async Task<IHttpActionResult> PostBook(Book bookDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var book = Mapper.Map<Book>(bookDto);

			db.Books.Add(book);
			await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new {id = book.BookId}, book);
		}

		// DELETE: api/Books/5
		[ResponseType(typeof (BookDTO))]
		public async Task<IHttpActionResult> DeleteBook(int id)
		{
			var book = await db.Books.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}

			db.Books.Remove(book);
			await db.SaveChangesAsync();

			return Ok(Mapper.Map<BookDTO>(book));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool BookExists(int id)
		{
			return db.Books.Count(e => e.BookId == id) > 0;
		}
 * */
	}
}