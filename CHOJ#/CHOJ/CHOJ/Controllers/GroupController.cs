using System.Web.Mvc;

namespace CHOJ.Controllers {
	public class GroupController : BaseController {
		public ActionResult List() {
		    Title = "分类列表";
			var ret = GroupHelper.GroupList(Db);
			Db.Dispose();
			return View(ret);
		}
	}
}
