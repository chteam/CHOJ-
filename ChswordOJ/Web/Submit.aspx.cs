using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Threading;
using ChswordOJ;

public partial class Submit :ChPage
{
	protected void Page_Init(object sender, EventArgs e) {
		this.SetHtmlLink("css/submit.css");
	}
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!User.Identity.IsAuthenticated) Response.Redirect("/Login.aspx?ReturnUrl=%2fSubmit.aspx%3fid%3d" + Request.QueryString["id"]);
		Num.Text = Request.QueryString["id"];
		username.Text = User.Identity.Name;
		Button1.Text = GetConfig("Submit");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ThreadStart thr_start_func = new ThreadStart(AThread);
        Thread fThread = new Thread(thr_start_func);
        fThread.Name = "AThread";
        fThread.Start();/*AThread();*/
		Response.Redirect("Status.aspx");
    }
    void AThread() {
        DoFile df = new DoFile();
		df.GetResult(TCode.Text, username.Text,"77298666", Num.Text,DropDownList1.SelectedValue );
    }

}
