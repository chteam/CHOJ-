using System;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

public partial class CompilerError : ChswordOJ.ChPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		ChswordOJ.Option op = new ChswordOJ.Option();
		Repeater.DataSource = op.GetAnswerError(Request.QueryString["id"].ToString());
		Repeater.DataBind();

    }
}
