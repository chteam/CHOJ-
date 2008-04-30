<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
 CodeFile="DisplayRoleandUser.aspx.cs" Inherits="Admin_DisplayRoleandUser" Title="角色管理"
  Theme="MemberShipSkin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div>
            <fieldset style="width: 300px">
                <legend class="mainTitle">实现自定义角色管理提供程序</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head">
                            <b>显示角色和对应用户</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" Width="100%"
                                GridLines="None" Font-Size="Small">
                                <Columns>
                                    <asp:TemplateField HeaderText="角色名">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbRoleName" ForeColor='black' Text='<%# Container.DataItem.ToString() %>' />
                                        </ItemTemplate>
                                        <HeaderStyle Height="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="包含用户">
                                        <ItemTemplate>
                                            <asp:BulletedList ID="blUsers" runat="server" Height="40px" BulletImageUrl="~/images/user.gif"
                                                BulletStyle="CustomImage" DataSource='<%#Roles.GetUsersInRole(Container.DataItem.ToString()) %>'>
                                            </asp:BulletedList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
</asp:Content>

