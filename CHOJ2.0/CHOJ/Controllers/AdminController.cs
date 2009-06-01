using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CHOJ.Controllers {
	[Authorize(Roles="Admin")]
	public class AdminController :BaseController {
		public ActionResult Index() {
			return View();
		}
		public ActionResult ClearCache() {
			CHCache.RemoveAll();
			return View();
		}
	}
}
