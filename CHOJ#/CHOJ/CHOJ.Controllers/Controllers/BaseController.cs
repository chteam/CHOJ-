using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CHOJ.Controllers {
	[HandleError]
	public class BaseController : Controller {
		protected void InitIntPage(ref int? x) {
			if (!x.HasValue) x = 1;
			if (x.Value == 0) x = 1;
		}
		DataBaseExecutor _DB;
		protected DataBaseExecutor DB {
			get {
				if (_DB == null) _DB = new DataBaseExecutor(new OleDbDataOpener(ConfigurationManager.ConnectionStrings["AccessFileName"].ConnectionString));
				return _DB;
			}
		}
	}
}
