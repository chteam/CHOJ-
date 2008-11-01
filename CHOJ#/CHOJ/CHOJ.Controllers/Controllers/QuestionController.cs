using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHOJ.Controllers {
	public class QuestionController : BaseController {
		public ActionResult Index(long id) {
			ViewData["comefrom"] = Request.UrlReferrer;
			var d = QuestionHelper.Question(DB, id);
			if (d == null) throw new OJException("不能为空");
			DB.Dispose();
			return View(d);
		}
		public ActionResult List(long id, int? p) {
			InitIntPage(ref p);
			ViewData["source"] = QuestionHelper.QuestionList(DB, id, p.Value);
			ViewData["group"] = GroupHelper.GetGroup(DB, id);
			DB.Dispose();
			return View();
		}
	}
}
