using System.Configuration;

namespace Web.Client.WebConfigSections
{
	public class CardFileBooksConfigurationSettingsSection : ConfigurationSection
	{
		private const string AppNameKey = "applicationName";
		private const string PageSizeKey = "pageSize";
		public const string SectionName = "cardFileBooksConfigSettings";

		[ConfigurationProperty(AppNameKey, IsRequired = true)]
		public ApplicationNameElement ApplicationName
		{
			get { return (ApplicationNameElement) this[AppNameKey]; }
			set { this[AppNameKey] = value; }
		}

		[ConfigurationProperty(PageSizeKey, IsRequired = true)]
		public PageSizeElement PageSize
		{
			get { return (PageSizeElement) this[PageSizeKey]; }
			set { this[PageSizeKey] = value; }
		}
	}
}