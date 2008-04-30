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

public partial class Admin_EditUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string username = Request.QueryString["user"];
		if (!IsPostBack) {
			if (username != null) {
				//填充数据
				MembershipUser mu = Membership.GetUser(username);
				txtUsername.Text = mu.UserName;
				txtEmail.Text = mu.Email;
				txtComment.Text = mu.Comment;
			}
			else {
				lbMessage.Text = "请选择一个需要编辑的用户名.";
			}
		}
	}


	protected void btSubmit_Click(object sender, EventArgs e) {
		string username = Request.QueryString["user"];
		try {
			//更新用户数据
			string email = txtEmail.Text;
			string comment = txtComment.Text;
			MembershipUser mu = Membership.GetUser(username);
			mu.Email = email;
			mu.Comment = comment;
			Membership.UpdateUser(mu);
			lbMessage.Text = "更新成功.";
		}
		catch (System.Configuration.Provider.ProviderException ex) {
			//抛出异常
			lbMessage.Text = ex.Message;
		}
	}
}
