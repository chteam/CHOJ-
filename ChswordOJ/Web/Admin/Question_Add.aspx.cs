using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using ChswordOJ;
//using ChswordOj;

public partial class Admin_Question_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack) {
			if (!String.IsNullOrEmpty(Request.QueryString["id"])) {
				Option com = new Option();
				User u = new User("", "", "");
				DataSet ds = com.GetQuestion(Request.QueryString["id"]);
				tTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
				tGroupid.Text = ds.Tables[0].Rows[0]["groupid"].ToString();
				tBody.Text = ds.Tables[0].Rows[0]["body"].ToString();
				tTest.Text = ds.Tables[0].Rows[0]["test"].ToString();
				tTimeLimit.Text = ds.Tables[0].Rows[0]["timelimit"].ToString();
				tMemoryLimit.Text = ds.Tables[0].Rows[0]["memorylimit"].ToString();
			}
		}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
		if (!string.IsNullOrEmpty(Request.QueryString["id"]))
			update();
		else
			insert();
    }
	void insert() {
		doit("QuestionInsert", 0);
	}
	void update() {
		doit("QuestionUpdate", Int64.Parse(Request.QueryString["id"]));
	}
    void doit(string txt,Int64 id) {
        DoDataBase dd=new DoDataBase();
        SqlParameter[] p= new SqlParameter[8];
        p[0] = new SqlParameter("@username", SqlDbType.NVarChar,255);
        p[0].Value = User.Identity.Name;
        p[1] =new SqlParameter("@MemoryLimit", SqlDbType.BigInt);
        p[1].Value = tMemoryLimit.Text;
        p[2] = new SqlParameter("@TimeLimit", SqlDbType.BigInt);
        p[2].Value = tTimeLimit.Text;
        p[3] = new SqlParameter("@title", SqlDbType.NVarChar,250);
        p[3].Value = tTitle.Text;
        p[4] = new SqlParameter("@Body", SqlDbType.NText);
        p[4].Value = tBody.Text;
        p[5] = new SqlParameter("@groupid", SqlDbType.BigInt);
        p[5].Value = tGroupid.SelectedValue;
		p[6] = new SqlParameter("@id", SqlDbType.BigInt);
		p[6].Value = id;
		p[7] = new SqlParameter("@test", SqlDbType.NText);
		p[7].Value = tTest.Text;
		User u=new User("","","");
		String i=dd.DoParameterSql(txt,p);
		Label1.Text = "添加 / 更新 成功";
    }

}
