using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Core.DB;
using Core.DB.Data;
using Core.DB.Repository;
using Core.Entities.DTOs;

namespace Web.Server.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}