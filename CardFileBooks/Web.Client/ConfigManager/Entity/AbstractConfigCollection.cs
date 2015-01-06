using System.Configuration;
using Web.Client.WebConfigSections;

namespace Web.Client.ConfigManager.Entity
{
	public abstract class AbstractConfigCollection
	{
		protected CardFileBooksConfigurationSettingsSection ConfigSection;

		protected AbstractConfigCollection()
		{
			ConfigSection = (CardFileBooksConfigurationSettingsSection)ConfigurationManager.GetSection(CardFileBooksConfigurationSettingsSection.SectionName);
		}
	}
}