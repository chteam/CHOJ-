using System;
using System.Web.UI.WebControls;
using ChswordOJ;
using System.Data;

public partial class PageQuestion : ChswordOJ.ChPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!string.IsNullOrEmpty(Request.QueryString["Getallthingchenghuanpostiswhat"]))
		{
			Option com = new Option();
			User u = new User("", "", "");
			DataSet ds = com.GetQuestion(Request.QueryString["Getallthingchenghuanpostiswhat"]);
			Response.Write("标题：");
			Response.Write(ds.Tables[0].Rows[0]["title"].ToString());
			Response.Write("\n问题组：");
			Response.Write(ds.Tables[0].Rows[0]["groupid"].ToString());
			Response.Write("\n问题：\n");
			Response.Write(ds.Tables[0].Rows[0]["body"].ToString());
			Response.Write("\n测试文件：\n");
			Response.Write(ds.Tables[0].Rows[0]["test"].ToString());
			Response.Write("\n时间限制：");
			Response.Write(ds.Tables[0].Rows[0]["timelimit"].ToString());
			Response.Write("\n内存限制：");
			Response.Write(ds.Tables[0].Rows[0]["memorylimit"].ToString());
			Response.End();
		}
		else
		{
			QueryStringParameter qp = new QueryStringParameter();
			qp.DefaultValue = "0";
			qp.Name = "id";
			qp.QueryStringField = "id";
			qp.Type = TypeCode.Int64;
			ObjectDataSource oq = new ObjectDataSource();
			oq.OldValuesParameterFormatString = "original_{0}";
			oq.SelectMethod = "GetData";
			oq.TypeName = "QuestionTableAdapters.QuestionSelectTableAdapter";
			oq.SelectParameters.Add(qp);
			RQuestion.DataSource = oq;
			RQuestion.DataBind();
		}
    }
}
