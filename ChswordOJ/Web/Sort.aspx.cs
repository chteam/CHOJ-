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

public partial class Sort : ChswordOJ.ChPage {
	protected void Page_Load(object sender, EventArgs e) {
        //SqlDataSource sq = new SqlDataSource(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "GetUser");
        //sq.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
        //GridView1.DataSource = sq;
        GridView1.Columns[0].HeaderText = GetConfig("RankList");
        GridView1.Columns[1].HeaderText = GetConfig("UserName");
        GridView1.Columns[2].HeaderText = GetConfig("Accepted");
        GridView1.Columns[3].HeaderText = GetConfig("Submit");
        GridView1.Columns[4].HeaderText = GetConfig("Ratio");
        GridView1.PageSize = 20;
        GridView1.Columns[0].HeaderStyle.CssClass = "list10";
        GridView1.Columns[2].HeaderStyle.CssClass = "list8";
        GridView1.Columns[3].HeaderStyle.CssClass = "list8";
        GridView1.Columns[4].HeaderStyle.CssClass = "list8";
        //GridView1.DataBind();
            //        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    //ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    //    SelectCommand="GetUser" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    //<asp:ScriptManager runat="server"/>

    }
}
