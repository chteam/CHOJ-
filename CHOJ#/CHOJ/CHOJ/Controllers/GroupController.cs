using System.Web.Mvc;
using CHOJ.Service;

namespace CHOJ.Controllers {
	public class GroupController : BaseController {
		public ActionResult List() {
		    Title = "分类列表";
            var ret = GroupService.GetInstance().GroupList();
			return View(ret);
		}
	}
}
