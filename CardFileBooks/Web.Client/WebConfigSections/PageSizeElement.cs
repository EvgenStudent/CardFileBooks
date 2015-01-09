using System.Configuration;

namespace Web.Client.WebConfigSections
{
	public class PageSizeElement : ConfigurationElement
	{
		private const string ValueKey = "value";

		[ConfigurationProperty(ValueKey, IsKey = true, IsRequired = true, DefaultValue = 20)]
		public int Value
		{
			get { return (int) this[ValueKey]; }
			set { this[ValueKey] = value; }
		}
	}
}