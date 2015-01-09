using System.Collections.Generic;
using Core.Entities.DTOs;

namespace Core.Entities
{
	public class BookJsonModel
	{
		public int Total { get; set; }
		public IEnumerable<BookDTO> Values { get; set; }
	}
}