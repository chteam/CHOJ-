<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" 
CodeFile="Contest_Master.aspx.cs" Inherits="Admin_Contest_Master"
 Title="竞赛管理"
  Theme="MemberShipSkin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
	ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
	InsertCommand="GroupInsert" InsertCommandType="StoredProcedure"
	 SelectCommand="GroupSelect" SelectCommandType="StoredProcedure" 
	 UpdateCommand="GroupUpdate" UpdateCommandType="StoredProcedure" 
	 DeleteCommand="GroupDelete" DeleteCommandType="StoredProcedure">
		<UpdateParameters>
			<asp:Parameter Name="name" Type="String" />
			<asp:Parameter Name="id" Type="Int64" />
		</UpdateParameters>
		<InsertParameters>
			<asp:Parameter Name="name" Type="String" />
			<asp:Parameter Name="type"  Type="int16" DefaultValue="1" />
			<asp:Parameter Name="begintime" Type="DateTime" />
			<asp:Parameter Name="endtime" Type="DateTime" />
		</InsertParameters>
		<DeleteParameters>
			<asp:Parameter Name="id" Type="Int64" />
		</DeleteParameters>
		<SelectParameters>
			<asp:Parameter Name="type"  Type="int16" DefaultValue="1" />
		</SelectParameters>
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
			<asp:BoundField DataField="begintime" HeaderText="开始时间" SortExpression="begintime" />
			<asp:BoundField DataField="endtime" HeaderText="结束时间" SortExpression="endtime" />
			<asp:CommandField ShowInsertButton="True" />
		</Fields>
	</asp:DetailsView></div>

</asp:Content>

