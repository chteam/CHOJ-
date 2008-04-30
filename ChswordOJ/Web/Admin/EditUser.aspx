<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Admin_EditUser" Title="成员管理"  Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
            <fieldset style="width: 300px">
                <legend class="mainTitle">实现成员管理功能</legend>
                <br />
                <table border="0" cellpadding="2" cellspacing="2" class="Main" width="100%">
                    <tr>
                        <td align="center" class="Head" colspan="2">
                            <b>用户编辑</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 30%">
                            用户名：
                        </td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtUsername" runat="server" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            电子邮件：
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            备注：
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lbMessage" runat="server" ForeColor="red"></asp:Label><br />
                            <asp:Button ID="btSubmit" runat="server" Text=" 保存 " OnClick="btSubmit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Head" align="right" colspan="2" style="height: 23px">
                            <a class="Head" href="ListUsers.aspx">返回用户列表</a>                            
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>

</asp:Content>

