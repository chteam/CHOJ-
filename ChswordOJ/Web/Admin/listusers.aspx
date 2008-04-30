<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
 CodeFile="listusers.aspx.cs" Inherits="Admin_listusers" Title="用户管理" Theme="MemberShipSkin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div>
            <fieldset style="width: 100%">
				<legend class="mainTitle">用户管理</legend>
                            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" Font-Size="Small"
								GridLines="None" Width="100%">
                                <Columns>
<asp:TemplateField HeaderText="用户名"><ItemTemplate>
                                            <asp:Label runat="server" ID="lbUserName" ForeColor='black' Text='<%#DataBinder.Eval(Container.DataItem, "UserName")%>' />
                                        
</ItemTemplate>

<HeaderStyle Height="25px"></HeaderStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="启用"><ItemTemplate>
                                            <asp:CheckBox ID="cbActive" runat="server" AutoPostBack="true" Checked='<%# DataBinder.Eval(Container.DataItem, "IsApproved")%>'
												ForeColor="blue" OnCheckedChanged="CheckBox_Click" ToolTip='<%#DataBinder.Eval(Container.DataItem, "UserName")%>' />
                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                                            ◆<asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'
												CommandName="EditUser" ForeColor="blue" PostBackUrl='<%#String.Format("EditUser.aspx?user={0}",DataBinder.Eval(Container.DataItem, "UserName"))%>'
												Text="编辑用户"></asp:LinkButton>
                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                                            ╳<asp:LinkButton ID="lbDel" runat="server"
                                                Text="删除用户" CommandName="DeleteUser" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'
                                                OnCommand="LinkButton_Click" ForeColor="blue" OnClientClick="return confirm('确定删除该用户吗？');"></asp:LinkButton>
                                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                                            ◆<asp:LinkButton ID="lbA" runat="server"
                                                Text="添加角色" CommandName="AddRole" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'
                                               ForeColor="blue" OnClick="lbA_Click"></asp:LinkButton>
                                        
</ItemTemplate>
</asp:TemplateField>
</Columns>
                            </asp:GridView>
<asp:Panel ID="plListRole" runat="server" Visible="false">
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
</asp:Panel>
<asp:Label ID="lbMessage" runat="server" ForeColor="red"></asp:Label>
<a href="AddRoleToUser.aspx">为角色设置用户</a>
<asp:LinkButton ID="lbtExit" runat="server" OnClick="lbtExit_Click">退出系统</asp:LinkButton>
            </fieldset>
        </div>
</asp:Content>

