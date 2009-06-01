using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data;
namespace CHOJ.Controllers {
	public class AnswerController : BaseController {
		[Authorize]
		public ActionResult Submit(long? id) {
			List<Compiler> li = ConfigSerializer.Load<List<Compiler>>("Compiler");
			ViewData["Compiler"] = new SelectList(li, "Guid", "Name");
			if (id.HasValue)
				ViewData["QuestionId"] = id.Value;
			ViewData["Username"] = User.Identity.Name;
			return View();
		}
		[Authorize]
		public ActionResult SubmitProcess(string Username, string Code, Guid Compiler, long QuestionId) {
			OJer x = new OJer(Username, Code, Compiler, QuestionId, Server.MapPath("/"));
			ThreadPool.QueueUserWorkItem(new WaitCallback(x.Start));
			DB.Dispose();
		//	throw new OJException(.ToString());
			return RedirectToAction("Status");
		}
		public ActionResult Status(int ? p) {
			this.InitIntPage(ref p);
			var Ld = AnswerHelper.Status(DB, p.Value);
			ViewData["source"] = Ld;
			DB.Dispose();
			return View();
		}
		public ActionResult MyStatus(long? qid) {
			IEnumerable<DataRow> Ld;
			if (qid.HasValue) {
			
			}
			else {
				Ld = AnswerHelper.MySatus(DB, User.Identity.Name);
			}
			
			return View();
		}
	}
}
