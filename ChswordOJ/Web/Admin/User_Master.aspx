<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
 CodeFile="User_Master.aspx.cs" Inherits="Admin_User_Master" Title="角色管理" Theme="MemberShipSkin" %>
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
                            添加角色：<asp:TextBox ID="txtRole" runat="server" Width="120px"></asp:TextBox>&nbsp;&nbsp;<asp:Button
                                ID="btnSubmit" runat="server" Text=" 确定 " OnClick="btnSubmit_Click" />
                            <hr />
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
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img src="../images/icon_edit.gif" alt="edit" /><asp:LinkButton ID="lbEdit" runat="server"
                                                Text="编辑" CommandName="EditRole" CommandArgument='<%# Container.DataItem.ToString() %>'
                                                OnCommand="LinkButtonClick" ForeColor="blue"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img src="../images/icon_delete.gif" alt="del" /><asp:LinkButton ID="lbDel" runat="server"
                                                Text="删除" CommandName="DeleteRole" CommandArgument='<%# Container.DataItem.ToString() %>'
                                                OnCommand="LinkButtonClick" ForeColor="blue" OnClientClick="return confirm('确定删除该角色吗？');"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <asp:Panel ID="plUsers" runat="server" Visible="false">
                        <tr>
                            <td align="center">
                                <hr />
                                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" Width="100%"
                                    GridLines="None" Font-Size="Small">
                                    <Columns>
                                        <asp:TemplateField HeaderText="用户名">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbUserName" ForeColor='black' Text='<%#DataBinder.Eval(Container.DataItem,"UserName") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle Height="25px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否属于角色">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbUserInRole" runat="server" AutoPostBack="true" ForeColor="blue"
                                                    OnCheckedChanged="CheckBox_Click" ToolTip='<%#DataBinder.Eval(Container.DataItem,"UserName") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle Height="25px" />
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
                            <a href="AddUserToRole.aspx">为用户设置角色</a>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
</asp:Content>

