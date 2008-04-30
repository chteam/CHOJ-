<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" 
AutoEventWireup="true" CodeFile="Answer_Pass.aspx.cs" Inherits="Admin_Answer_Pass" 
Title="代码"  Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
		SelectCommand="GetAnswerPass" SelectCommandType="StoredProcedure">
		<SelectParameters>
<asp:QueryStringParameter Name="answerid" QueryStringField="id" Type="Int64" DefaultValue="0" />
		</SelectParameters>
		</asp:SqlDataSource>
	<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
	<ItemTemplate>
<pre style="margin-left:10%"><%#Server.HtmlEncode(Eval("code").ToString()) %></pre>
	</ItemTemplate>
	</asp:Repeater>
</asp:Content>

