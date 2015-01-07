using System.Configuration;

namespace Web.Client.WebConfigSections
{
	public class ApiUrlsElement : ConfigurationElement
	{
		private const string ApiUrlsKey = "key";
		private const string ApiUrlsValue = "value";

		public const string GetBooksKey = "GetBooks";

		[ConfigurationProperty(ApiUrlsKey, IsKey = true, IsRequired = true)]
		public string Key
		{
			get { return (string)this[ApiUrlsKey]; }
			set { this[ApiUrlsKey] = value; }
		}

		[ConfigurationProperty(ApiUrlsValue, IsKey = true, IsRequired = true)]
		public string Value
		{
			get { return (string)this[ApiUrlsValue]; }
			set { this[ApiUrlsValue] = value; }
		}
	}
}