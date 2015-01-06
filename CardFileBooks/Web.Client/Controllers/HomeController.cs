using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Utils.Managers;

namespace Web.Client.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			IServerManager manager = new ServerManager();
			var test = await manager.BookManager.Get("http://localhost:9010/odata/Books");

			
			
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}