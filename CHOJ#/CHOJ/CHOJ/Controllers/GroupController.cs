using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHOJ.Controllers {
	public class GroupController : BaseController {
		public ActionResult List() {
            
			var ret = GroupHelper.GroupList(Db);
			Db.Dispose();
			return View(ret);
		}
	}
}
