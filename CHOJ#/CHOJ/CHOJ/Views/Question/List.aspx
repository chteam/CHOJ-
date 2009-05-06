<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	 Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<% System.Data.DataRow g = ViewData["group"] as System.Data.DataRow;%>
 <span>
 <span><%=Html.ActionLink("Problems Online","List","Group") %></span>
 <span class="textStyle">&gt;</span>
 <span class="textSample"><%=Html.QuestionList(g["name"].ToString(), g["id"])%></span>
 
	</span>
	<div>
		<h3>
			<%=g["name"]%> (<%=g["QuestionCount"]%>)</h3>
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
					foreach (System.Data.DataRow dr in ViewData["source"] as IEnumerable<System.Data.DataRow>) {
						line = !line;
		   %>
		   		<tr class="<%=line?"rb":"re" %>">
					<td><%=dr["id"] %></td>
					<td><%=Html.QuestionLink(dr["title"].ToString(),dr["id"]) %></td>
					<td><%=dr["AcceptedCount"]%></td>
					<td><%=dr["SubmitCount"]%></td>
					<td><%=Html.GetRatio(dr["AcceptedCount"], dr["SubmitCount"])%></td>
				</tr>
				<%} %>
			</table>
		</div>
	</div>
</asp:Content>
