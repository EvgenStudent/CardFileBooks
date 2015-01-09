using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.DB;
using Core.DB.Repository;
using Core.Entities;
using Core.Entities.DTOs;
using Web.Server.Extensions;
using Web.Server.Helpers;
using Web.Server.Models;

namespace Web.Server.Controllers
{
	[RoutePrefix("api/Books")]
	public class BooksController : ApiController
	{
		private readonly IUnitOfWork _unitOfWork;

		public BooksController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[Route("")]
		[HttpGet]
		public IHttpActionResult GetBooks()
		{
			var parameters = new UrlParametersHelper(Request.RequestUri.Query);
			var books = _unitOfWork.Repository<Book>().Get().AsEnumerable();

			int total;
			books = books.Filters(parameters.FilterParams, out total).Sort(parameters.SortParams).Skip(parameters.Skip).Take(parameters.Take);

			var jsonModel = new BookJsonModel { Total = total, Values = books.AsQueryable().Project().To<BookDTO>() };
			return Ok(jsonModel);
		}

		[Route("{id}")]
		[ResponseType(typeof (BookDTO))]
		[HttpGet]
		public IHttpActionResult GetBook(int id)
		{
			var book = _unitOfWork.Repository<Book>().GetById(id);
			if (book == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<BookDTO>(book));
		}

		[Route("update")]
		[ResponseType(typeof (BookDTO))]
		[HttpPost]
		public IHttpActionResult UpdateBook(BookDTO bookDto)
		{
			if (bookDto == null)
				return BadRequest(ModelState);

			var book = _unitOfWork.Repository<Book>().GetById(bookDto.BookId);
			if (book == null)
				return NotFound();

			var newBook = Mapper.Map<Book>(bookDto);
			newBook.BookId = book.BookId;

			book.Authors.Clear();
			book.Genres.Clear();
			_unitOfWork.Repository<Book>().Delete(book);
			_unitOfWork.Save();
			_unitOfWork.Repository<Book>().Insert(newBook);
			_unitOfWork.Save();

			return StatusCode(HttpStatusCode.NoContent);
		}

		[Route("create")]
		[ResponseType(typeof (BookDTO))]
		[HttpPost]
		public IHttpActionResult CreateBook(BookDTO bookDto)
		{
			if (bookDto == null)
				return BadRequest(ModelState);

			var book = Mapper.Map<Book>(bookDto);

			_unitOfWork.Repository<Book>().Insert(book);
			_unitOfWork.Save();

			return StatusCode(HttpStatusCode.NoContent);
		}

		[Route("delete")]
		[ResponseType(typeof (BookDTO))]
		[HttpPost]
		public IHttpActionResult DeleteBook(BookDTO bookDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var book = _unitOfWork.Repository<Book>().GetById(bookDto.BookId);
			if (book == null)
				return NotFound();

			book.Authors.Clear();
			book.Genres.Clear();
			_unitOfWork.Repository<Book>().Delete(book);
			_unitOfWork.Save();

			return Ok(bookDto);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_unitOfWork.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool BookExists(int id)
		{
			return _unitOfWork.Repository<Book>().Get().Count(e => e.BookId == id) > 0;
		}

		private void Update(Book book, BookDTO dto)
		{
			book.Description = dto.Description;
			book.ISBN = dto.ISBN;
			book.NumberOfPages = dto.NumberOfPages;
			book.Publisher = dto.Publisher;
			book.ReleaseYear = dto.ReleaseYear;
			book.Title = dto.Title;
		}
	}
}