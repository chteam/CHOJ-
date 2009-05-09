<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"  Inherits="System.Web.Mvc.ViewPage<IList<CHOJ.Models.Group>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="center">
	<ul>
	<%foreach (CHOJ.Models.Group dr in ViewData.Model)
   { 
       
       %>
		<li>
		<%=Html.QuestionList(dr.Name, dr.ID)%></li>
	<%} %>
	</ul>
	</div>
</asp:Content>
