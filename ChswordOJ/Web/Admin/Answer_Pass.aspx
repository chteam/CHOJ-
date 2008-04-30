<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
	Inherits="System.Web.UI.Page" Title="代码" Theme="MemberShipSkin" %>
<%@ Import Namespace="ChswordOJ.Models" %>
<script runat="server">
	protected void Page_Load(object sender, EventArgs e) {
		
	}

	protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e) {
		OJDataDataContext data = OJDataExecutor.OJDataFactory();
		e.Result = data.GetAnswerPass(null);
		
	}
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:LinqDataSource ID="LinqDataSource1" runat="server" 
onselecting="LinqDataSource1_Selecting">
	</asp:LinqDataSource>
	<asp:Repeater ID="Repeater1" runat="server"
	DataSourceID="SqlDataSource1">
		<ItemTemplate>
			<pre style="margin-left: 10%"><%#Server.HtmlEncode(Eval("Code").ToString()) %></pre>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>
