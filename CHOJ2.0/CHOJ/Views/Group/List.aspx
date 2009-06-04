<%@ Page  Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<CHOJ.Models.Group>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="center">
	<ul>
	<%foreach (CHOJ.Models.Group dr in ViewData.Model)
   { 
       
       %>
		<li>
		<%=Html.QuestionList(dr.Name, dr.Id)%></li>
	<%} %>
	</ul>
	</div>
</asp:Content>
