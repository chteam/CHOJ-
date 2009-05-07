using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CHOJ;
using Microsoft.ServiceHosting.ServiceRuntime;

namespace CloudService1_WebRole
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var j = new OJer("a", "a", Server.MapPath("/"));
            j.Start(1);
        }
    }
}
