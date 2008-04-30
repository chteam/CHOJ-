using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Diagnostics;
public partial class _Default : ChswordOJ.ChPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		MembershipUser u;
		u = Membership.GetUser("Admin");
		//Response.Write(u.c);
    }

}
