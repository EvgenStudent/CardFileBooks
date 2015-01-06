using Web.Client.ConfigManager.Entity;

namespace Web.Client.ConfigManager
{
	public interface ICardFileBooksConfigManager
	{
		string ApplicationName { get; }
		ApiUrlsCollection ApiUrls { get; }
	}
}