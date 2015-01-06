using System.Configuration;
using Web.Client.ConfigManager.Entity;
using Web.Client.WebConfigSections;

namespace Web.Client.ConfigManager
{
	public class CardFileBooksConfigManager : ICardFileBooksConfigManager
	{
		public string ApplicationName { get; private set; }
		public ApiUrlsCollection ApiUrls { get; private set; }
		
		public CardFileBooksConfigManager()
		{
			var сonfigSection = (CardFileBooksConfigurationSettingsSection)ConfigurationManager.GetSection(CardFileBooksConfigurationSettingsSection.SectionName);

			ApplicationName = сonfigSection.ApplicationName.Value;
			ApiUrls = new ApiUrlsCollection();
		}
	}
}