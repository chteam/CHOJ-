<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" 
CodeFile="AddUserToRole.aspx.cs" Inherits="Admin_AddUserToRole" Title="角色管理" Theme="MemberShipSkin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
            <fieldset style="width: 300px">
                <legend class="mainTitle">实现角色管理功能</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head">
                            <b>角色管理</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" Width="100%" Font-Size="Small">
                                <Columns>
                                    <asp:TemplateField HeaderText="用户名">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbUserName" ForeColor='black' Text='<%#DataBinder.Eval(Container.DataItem, "UserName")%>' />
                                        </ItemTemplate>
                                        <HeaderStyle Height="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img src="../images/icon_edit.gif" alt="add" /><asp:LinkButton ID="lbAddRole" runat="server"
                                                Text="添加角色" CommandName="AddRole" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'
                                                OnCommand="LinkButtonClick" ForeColor="blue"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <asp:Panel ID="plListRole" runat="server" Visible="false">
                        <tr>
                            <td align="center">
                                <hr />
                                <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" Width="100%"
                                    GridLines="None" Font-Size="Small">
                                    <Columns>
                                        <asp:TemplateField HeaderText="角色名">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItem.ToString() %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Height="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否分配">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbAddRoleToUser" runat="server" AutoPostBack="true" ForeColor="blue"
                                                    OnCheckedChanged="AddRoleToUserCheckBox_Click" ToolTip='<%#Container.DataItem.ToString() %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbMessage" runat="server" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Head" align="right" style="height: 23px">
                            <a href="AddRoleToUser.aspx">返回</a>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
</asp:Content>

