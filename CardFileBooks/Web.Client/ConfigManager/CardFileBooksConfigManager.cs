using System.Configuration;
using Web.Client.WebConfigSections;

namespace Web.Client.ConfigManager
{
	public class CardFileBooksConfigManager : ICardFileBooksConfigManager
	{
		private static CardFileBooksConfigManager _instance;

		private CardFileBooksConfigManager()
		{
			var сonfigSection =
				(CardFileBooksConfigurationSettingsSection)
					ConfigurationManager.GetSection(CardFileBooksConfigurationSettingsSection.SectionName);

			ApplicationName = сonfigSection.ApplicationName.Value;
			PageSize = сonfigSection.PageSize.Value;
		}

		public static CardFileBooksConfigManager Instance
		{
			get { return _instance ?? (_instance = new CardFileBooksConfigManager()); }
		}

		public string ApplicationName { get; private set; }
		public int PageSize { get; private set; }
	}
}