<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	 Inherits="System.Web.Mvc.ViewPage<IEnumerable<Answer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<span>
	<span><%=Html.ActionLink("Home","Index","Home") %></span>
	<span class="textStyle">&gt;</span><span
		class="textSample">Status</span></span>
	<div>
		<div>
			<table class="GV" cellspacing="0" rules="all" border="1" style="border-collapse: collapse;">
				<tr class="Login_td">
					<th scope="col" style="width: 100px;">ID</th>
					<th scope="col" style="width: 150px;">提交时间</th>
					<th scope="col">标题</th>
					<th scope="col" style="width: 150px;">评判结果	</th>
					<th scope="col" style="width: 150px;">编译器</th>
					<th scope="col" style="width: 80px;">用户名</th>
				</tr>
				<%
					bool line = false ;
					foreach (Answer a in Model) {
						line = !line;
		   %>
		   		<tr class="<%=line?"rb":"re" %>">
					<td>-</td>
					<td><%=a.AddTime.ToString("hh:mm:ss")%></td>
					<td><%=Html.QuestionLink((a.QuestionTitle??"")+" ", a.QuestionId)%></td>
					<td><%=Html.Status(a.Status,a.Id)%></td>
					<td><%=a.Complier%></td>
					<td><%=a.UserName%></td>
				</tr>
				<%} %>				

			</table>
		</div>
	</div>
</asp:Content>
