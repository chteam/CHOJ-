<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Answer_Master.aspx.cs" Inherits="Admin_Answer_Master" Title="提交管理"  Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
		SelectCommand="AnswerSelect" SelectCommandType="StoredProcedure">
		<SelectParameters>
<asp:QueryStringParameter Name="questionid" QueryStringField="id" Type="Int64" DefaultValue="0" />
		</SelectParameters>
		</asp:SqlDataSource>
	&nbsp;
	<asp:GridView ID="GridView1" runat="server" Width="800px"
	AllowPaging="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="id">
		<Columns>
			<asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
				SortExpression="id" />
			<asp:BoundField DataField="Addtime"
			 HeaderText="Submit Time" SortExpression="Addtime" 
			  HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd hh:mm}">
				<ItemStyle Width="150px" />
			</asp:BoundField>
			<asp:TemplateField>
			<ItemTemplate>
			<a href="question.aspx?id=<%=Request.QueryString["id"] %>"><%#Eval("title") %></a>(<%=Request.QueryString["id"] %>)
			</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
			<HeaderTemplate>Judge Statuss</HeaderTemplate>
			<ItemTemplate><%#ChswordOJ.ChString.GetStatus(Eval("status").ToString(), Int64.Parse(Eval("id").ToString()), true)%></ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
		</Columns>
	</asp:GridView>
	&nbsp;
</asp:Content>

