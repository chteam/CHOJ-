<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="CHOJ.Views.Group.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="center">
	<ul>
	<%foreach (System.Data.DataRow dr in ViewData.Model) { %>
		<li>
		<%=Html.QuestionList(dr["name"].ToString(), dr["id"])%></li>
	<%} %>
	</ul>
	</div>
</asp:Content>
