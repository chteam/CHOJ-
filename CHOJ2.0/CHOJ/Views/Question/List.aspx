<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
	 Inherits="System.Web.Mvc.ViewPage<IEnumerable<Question>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<% var g = ViewData["group"] as  CHOJ.Models.Group;%>
 <span>
 <span><%=Html.ActionLink("Problems Online","List","Group") %></span>
 <span class="textStyle">&gt;</span>
 <span class="textSample"><%=Html.QuestionList(g.Title, g.Id)%></span>
 
	</span>
	<div>
		<h3>
			<%=g.Title%> (<%=g.QuestionCount%>)</h3>
		<div>
			<table class="GV" cellspacing="0" rules="all" border="1" style="border-collapse: collapse;">
				<tr class="Login_td">
					<th scope="col">ID</th>
					<th scope="col">标题</th>
					<th scope="col" style="width: 40px;">通过</th>
					<th scope="col" style="width: 40px;">提交</th>
					<th scope="col" style="width: 40px;">比例</th>
				</tr>
				<%
					bool line = false ;
					foreach (Question q in Model) {
						line = !line;
		   %>
		   		<tr class="<%=line?"rb":"re" %>">
					<td><%--<%=q.Id %>--%></td>
					<td><%=Html.QuestionLink(q.Title,q.Id) %></td>
					<td><%=q.AcceptedCount%></td>
					<td><%=q.SubmitCount%></td>
					<td><%=Html.GetRatio(q.AcceptedCount, q.SubmitCount)%></td>
				</tr>
				<%} %> 
			</table>
		</div>
	</div>
</asp:Content>
