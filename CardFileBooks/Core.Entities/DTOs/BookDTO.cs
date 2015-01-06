namespace Core.Entities.DTOs
{
	public class BookDTO
	{
		public int BookId { get; set; }
		public System.DateTime FinalReleaseDate { get; set; }
		public string Publisher { get; set; }
		public string Description { get; set; }
		public int NumberOfPages { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
	}
}