using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ChswordOJ.Models
{
	public class OJDataExecutor
	{
		public OJDataDataContext OJDataFactory() {
			return
				new OJDataDataContext(
					ConfigurationManager
					.ConnectionStrings["ConnectionString"]
					.ConnectionString
					);
		}
	}
}
