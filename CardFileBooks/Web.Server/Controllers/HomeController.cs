﻿using System.Web.Mvc;

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