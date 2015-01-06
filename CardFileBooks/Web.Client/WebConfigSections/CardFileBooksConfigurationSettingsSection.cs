using System.Configuration;

namespace Web.Client.WebConfigSections
{
	public class CardFileBooksConfigurationSettingsSection : ConfigurationSection
	{
		private const string AppNameKey = "applicationName";
		private const string ApiUrlsKey = "apiUrls";

		public const string SectionName = "cardFileBooksConfigSettings";

		[ConfigurationProperty(AppNameKey, IsRequired = true)]
		public ApplicationNameElement ApplicationName
		{
			get { return (ApplicationNameElement)this[AppNameKey]; }
			set { this[AppNameKey] = value; }
		}

		[ConfigurationProperty(ApiUrlsKey, IsDefaultCollection = false)]
		public ApiUrlsElementCollection ApiUrls
		{
			get { return (ApiUrlsElementCollection)this[ApiUrlsKey]; }
			set { this[ApiUrlsKey] = value; }
		}
	}
}