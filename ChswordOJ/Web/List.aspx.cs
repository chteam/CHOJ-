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

public partial class PageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ObjectDataSource oq = new ObjectDataSource();
        oq.OldValuesParameterFormatString = "original_{0}";
        oq.SelectMethod = "GetData";
        oq.TypeName = "GetGroupTableAdapters.GroupSelectTableAdapter";
        RG.DataSource = oq;
        RG.DataBind();
    }
}
