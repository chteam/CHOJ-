<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewPage" %>
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
