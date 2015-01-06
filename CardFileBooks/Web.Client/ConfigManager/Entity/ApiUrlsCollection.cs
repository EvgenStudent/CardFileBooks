using System;
using System.Collections.Generic;
using System.Linq;
using Web.Client.WebConfigSections;

namespace Web.Client.ConfigManager.Entity
{
	public class ApiUrlsCollection : AbstractConfigCollection
	{
		private readonly IEnumerable<ApiUrlsElement> _apiPathsElements;

		public ApiUrlsCollection()
		{
			_apiPathsElements = ConfigSection.ApiUrls.Cast<ApiUrlsElement>();
		}

		public string SignIn
		{
			get
			{
				ApiUrlsElement apiPathsElement = _apiPathsElements.FirstOrDefault(x => x.Key == ApiUrlsElement.SignInKey);
				if (apiPathsElement != null)
				{
					var uri = new Uri(new Uri(ConfigSection.ApiUrls.Host), apiPathsElement.Value);
					return uri.ToString();
				}
				return null;
			}
		}
}
}