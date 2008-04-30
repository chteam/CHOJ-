<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
CodeFile="GetPassWord.aspx.cs" Inherits="GetPassWord"
 EnableViewState="false"
Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<h3><%=GetConfig("PasswordRecovery")%></h3>
<div class="l30">
<asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
</asp:PasswordRecovery>
</div>
</asp:Content>

