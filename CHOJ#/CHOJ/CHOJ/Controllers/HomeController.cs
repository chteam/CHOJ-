using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace CHOJ.Controllers {

	public class HomeController : BaseController {
		public ActionResult Index() {
			ViewData["Title"] = "Home Page";
			ViewData["Message"] = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About() {
			ViewData["Title"] = "About Page";

			return View();
		}
	}
}
