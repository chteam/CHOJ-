using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Data;
using CHOJ.Service;

namespace CHOJ.Controllers {
	public class AnswerController : BaseController {
		[LoginedFilter]
		public ActionResult Submit(string id) {
			var li = ConfigSerializer.Load<List<Compiler>>("Compiler");
			ViewData["Compiler"] = new SelectList(li, "Guid", "Name");
			if (!id.IsNullOrEmpty())
				ViewData["QuestionId"] = id;
			return View();
		}
        [LoginedFilter]
        [ValidateInput(false)]
		public ActionResult SubmitProcess(string code, Guid compiler
            , string questionId) {
            var x = new OJer(HalfoxUser.Id, HalfoxUser.Name, 
                code, compiler, questionId, 
                Server.MapPath("/"));
			ThreadPool.QueueUserWorkItem(x.Start);
			return RedirectToAction("Status");
		}
        public ActionResult Status(int? p)
        {
            InitIntPage(ref p);
            var model = AnswerService.GetInstance().Status(p.Value, 20);
            return View(model);
        }

        public ActionResult UserStatus(string uId,string userName, int? p)
        {
            InitIntPage(ref p);
            Title = userName + "'s status";
            var model = AnswerService.GetInstance().UserStatus(uId, p.Value, 20);
            return View("Status", model);
		}
        public ActionResult QuestionStatus(string qId,string title, int? p)
        {
            InitIntPage(ref p);
            Title = title + "'s status";
            var model = AnswerService.GetInstance().QuestionStatus(qId, p.Value, 20);
            return View("Status", model);
        }
	}
}
