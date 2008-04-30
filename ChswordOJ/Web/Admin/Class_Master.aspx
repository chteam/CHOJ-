<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" 
CodeFile="Class_Master.aspx.cs" Inherits="Admin_Class_Master" Title="分类管理" 
 Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" InsertCommand="GroupInsert" InsertCommandType="StoredProcedure" SelectCommand="GroupSelect" SelectCommandType="StoredProcedure" UpdateCommand="GroupUpdate" UpdateCommandType="StoredProcedure" DeleteCommand="GroupDelete" DeleteCommandType="StoredProcedure">
		<UpdateParameters>
			<asp:Parameter Name="name" Type="String" />
			<asp:Parameter Name="id" Type="Int64" />
		</UpdateParameters>
		<InsertParameters>
			<asp:Parameter Name="name" Type="String" />
		</InsertParameters>
		<DeleteParameters>
			<asp:Parameter Name="id" Type="Int64" />
		</DeleteParameters>
	</asp:SqlDataSource>
	<asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="id">
		<Columns>
			<asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
				SortExpression="id" />
			<asp:BoundField DataField="name" HeaderText="name" SortExpression="id" />
			<asp:BoundField DataField="count" HeaderText="count" SortExpression="count" ReadOnly="True" />
			<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
		</Columns>
	</asp:GridView>
	<div id="add">
	<asp:DetailsView ID="Dv1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource1"
		DefaultMode="Insert" Height="50px" Width="125px" DataKeyNames="id" OnItemInserted="DetailsView1_ItemInserted">
		<Fields>
			<asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
			<asp:CommandField ShowInsertButton="True" />
		</Fields>
	</asp:DetailsView></div>
</asp:Content>

