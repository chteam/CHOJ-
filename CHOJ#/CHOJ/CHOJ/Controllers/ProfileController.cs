using System.Web.Mvc;

namespace CHOJ.Controllers {
	public class ProfileController : BaseController {
		[Authorize]
		public ActionResult Index() {
			return View();
		}
	}
}
