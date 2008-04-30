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

public partial class Admin_AddUserToRole : System.Web.UI.Page
{
 protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //绑定用户和角色信息
            gvUsers.DataSource = Membership.GetAllUsers();
            gvUsers.DataBind();
            gvRoles.DataSource = Roles.GetAllRoles();
            gvRoles.DataBind();
        }
    }
    protected void LinkButtonClick(object sender, CommandEventArgs e)
    {
        //处理添加角色
        if (e.CommandName.Equals("AddRole"))
        {
            //如果当前没有角色，则重定向创建新角色
            if (Roles.GetAllRoles().Length == 0)
            {
                Response.Redirect("ListRoles.aspx");
                return;
            }
            //显示角色信息，主要设置CheckBox的选中状态
            string username = e.CommandArgument.ToString();
            gvRoles.Caption = "设置用户<b>" + username + "</b>的角色";
            for (int i = 0; i < Roles.GetAllRoles().Length; i++)
            {
                CheckBox cb = (CheckBox)gvRoles.Rows[i].FindControl("cbAddRoleToUser");
                string roleName = cb.ToolTip;
                cb.Checked = Roles.IsUserInRole(username, roleName);
                //将用户信息传递到显示角色信息的列表中
                cb.Attributes["user"] = username;
            }
            plListRole.Visible = true;
        }
    }
    protected void AddRoleToUserCheckBox_Click(object sender, EventArgs e)
    {
        try
        {
            //为用户分配角色
            CheckBox cbAddRoleToUser = (CheckBox)sender;
            string username = cbAddRoleToUser.Attributes["user"];
            string roleName = cbAddRoleToUser.ToolTip;
            //如果用户已经分配角色，则删除；否则为用户添加角色
            if (!cbAddRoleToUser.Checked)
            {
                Roles.RemoveUserFromRole(username, roleName);
            }
            else
            {
                Roles.AddUserToRole(username, roleName);
            }
            lbMessage.Text = "更新成功.";
        }
        catch (System.Configuration.Provider.ProviderException ex)
        {
            //抛出异常
            lbMessage.Text = ex.Message;
        }
    }
    }