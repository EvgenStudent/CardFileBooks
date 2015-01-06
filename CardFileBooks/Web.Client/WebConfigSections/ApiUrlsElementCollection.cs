using System.Configuration;

namespace Web.Client.WebConfigSections
{
	public class ApiUrlsElementCollection : ConfigurationElementCollection
	{
		private const string HostKey = "host";

		[ConfigurationProperty(HostKey, IsRequired = true)]
		public string Host
		{
			get { return (string)this[HostKey]; }
			set { this[HostKey] = value; }
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new ApiUrlsElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ApiUrlsElement)element).Key;
		}
	}
}