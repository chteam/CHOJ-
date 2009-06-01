<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	 Inherits="System.Web.Mvc.ViewPage" %>

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
					foreach (System.Data.DataRow dr in ViewData["source"] as IEnumerable<System.Data.DataRow>) {
						line = !line;
		   %>
		   		<tr class="<%=line?"rb":"re" %>">
					<td><%=dr["id"] %></td>
					<td><%=dr["addtime"]%></td>
					<td><%=Html.QuestionLink(dr["Title"].ToString(), dr["QuestionID"])%></td>
					<td><%=Html.Status(dr["Status"],dr["Guid"])%></td>
					<td><%=dr["Complier"]%></td>
					<td><%=dr["Username"]%></td>
				</tr>
				<%} %>				
		<%--		<tr class="pg">
					<td colspan="6">
						<table border="0">
							<tr>
								<td>
									<span>1</span>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$2')">2</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$3')">3</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$4')">4</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$5')">5</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$6')">6</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$7')">7</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$8')">8</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$9')">9</a>
								</td>
								<td>
									<a href="javascript:__doPostBack('ctl00$Content$GridView1','Page$10')">10</a>
								</td>
							</tr>
						</table>
					</td>
				</tr>--%>
			</table>
		</div>
	</div>
</asp:Content>
