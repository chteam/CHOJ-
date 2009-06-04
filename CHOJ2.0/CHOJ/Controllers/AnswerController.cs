using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data;
namespace CHOJ.Controllers {
	public class AnswerController : BaseController {
		[LoginedFilter]
		public ActionResult Submit(string id) {
			List<Compiler> li = ConfigSerializer.Load<List<Compiler>>("Compiler");
			ViewData["Compiler"] = new SelectList(li, "Guid", "Name");
			if (!id.IsNullOrEmpty())
				ViewData["QuestionId"] = id;
			ViewData["UserId"] = HalfoxUser.Id;
			return View();
		}
        [LoginedFilter]
		public ActionResult SubmitProcess(string userName, string code, Guid compiler
            , string questionId) {
			OJer x = new OJer(userName, code, compiler, questionId, Server.MapPath("/"));
			ThreadPool.QueueUserWorkItem(new WaitCallback(x.Start));
			Db.Dispose();
		//	throw new OJException(.ToString());
			return RedirectToAction("Status");
		}
		public ActionResult Status(int ? p) {
			this.InitIntPage(ref p);
			var Ld = AnswerHelper.Status(Db, p.Value);
			ViewData["source"] = Ld;
			Db.Dispose();
			return View();
		}
		public ActionResult MyStatus(long? qid) {
			IEnumerable<DataRow> Ld;
			if (qid.HasValue) {
			
			}
			else {
				Ld = AnswerHelper.MySatus(Db, User.Identity.Name);
			}
			
			return View();
		}
	}
}
