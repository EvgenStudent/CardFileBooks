namespace Web.Server.Models
{
	public class SortParameters
	{
		public string SortField { get; set; }
		public string SortDir { get; set; }

		public bool SortIsUsed
		{
			get { return !string.IsNullOrWhiteSpace(SortField) & !string.IsNullOrWhiteSpace(SortDir); }
		}
	}
}