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

public partial class Admin_User_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack) {
			gvRoles.DataSource = Roles.GetAllRoles();
			gvRoles.DataBind();
			gvUsers.DataSource = Membership.GetAllUsers();
			gvUsers.DataBind();
		}
    }
	protected void LinkButtonClick(object sender, CommandEventArgs e) {
		// 实现角色编辑
		if (e.CommandName.Equals("EditRole")) {
			//显示用户信息，主要设置CheckBox的选中状态
			string roleName = e.CommandArgument.ToString();
			gvUsers.Caption = "设置角色<b>" + roleName + "</b>的用户";
			for (int i = 0; i < Membership.GetAllUsers().Count; i++) {
				CheckBox cb = (CheckBox)gvUsers.Rows[i].FindControl("cbUserInRole");
				string username = cb.ToolTip;
				cb.Checked = Roles.IsUserInRole(username, roleName);
				//将角色信息传递到显示角色信息列表中
				cb.Attributes["role"] = roleName;
			}
			plUsers.Visible = true;
		}
		//处理角色删除
		if (e.CommandName.Equals("DeleteRole")) {
			string delRole = e.CommandArgument.ToString();
			int temp = Roles.GetUsersInRole(delRole).Length;
			//如果角色中还包含用户，则不删除
			if (temp != 0) {
				lbMessage.Text = "该角色中还包含一些用户，因此不能删除.";
				return;
			}
			// 调用DeleteRole方法进行删除
			if (Roles.DeleteRole(delRole)) {
				gvRoles.DataSource = Roles.GetAllRoles();
				gvRoles.DataBind();
				lbMessage.Text = "删除成功.";
			}
			else {
				lbMessage.Text = "未能删除成功.";
			}
		}
	}
	protected void btnSubmit_Click(object sender, EventArgs e) {
		string createRole = txtRole.Text;
		//如果角色为空，则要求输入角色名
		if (txtRole.Text == string.Empty) {
			lbMessage.Text = "请输入角色名.";
			return;
		}
		//如果角色不存在，则调用CreateRole方法创建角色；否则显示提示信息
		if (!Roles.RoleExists(createRole)) {
			Roles.CreateRole(createRole);
			gvRoles.DataSource = Roles.GetAllRoles();
			gvRoles.DataBind();
			lbMessage.Text = "添加成功.";
		}
		else {
			lbMessage.Text = "存在同名的角色.";
		}
	}
	protected void CheckBox_Click(object sender, EventArgs e) {
		try {
			//获取角色和用户信息
			CheckBox cbUserInRole = (CheckBox)sender;
			string username = cbUserInRole.ToolTip;
			string roleName = cbUserInRole.Attributes["role"];
			//如果未被选中，则调用RemoveUserFromRole删除用户；否则调用AddUserToRole添加用户
			if (!cbUserInRole.Checked) {
				Roles.RemoveUserFromRole(username, roleName);
			}
			else {
				Roles.AddUserToRole(username, roleName);
			}
			lbMessage.Text = "更新成功.";
		}
		catch (System.Configuration.Provider.ProviderException ex) {
			//抛出异常
			lbMessage.Text = ex.Message;
		}
	}
}
