using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Entities.DTOs;

namespace Core.Utils.Managers
{
	public class BookManager
	{
		internal BookManager()
		{
		}

		public async Task<IEnumerable<BookDTO>> Get(string url)
		{
			using (var client = new HttpClient())
			{
				HttpResponseMessage result = await client.GetAsync(url);
				IEnumerable<BookDTO> resultContent = await result.Content.ReadAsAsync<IEnumerable<BookDTO>>();

				return resultContent;
			}
		}
	}
}