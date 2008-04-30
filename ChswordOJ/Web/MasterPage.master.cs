using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSSFriendly;

public partial class MasterPage : ChswordOJ.ChMasterPage
{
    protected void Page_Load(object sender, EventArgs e){
		LoginStatus.LoginText = GetConfig("Login");
		LoginStatus.LogoutText = GetConfig("Logout");
    }
}
