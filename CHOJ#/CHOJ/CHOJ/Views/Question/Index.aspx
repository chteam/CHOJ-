<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	CodeBehind="Index.aspx.cs" Inherits="CHOJ.Views.Question.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
		<% System.Data.DataRow q = ViewData.Model as System.Data.DataRow; %>
		<h3><%=q["title"] %></h3>
		<div class="center">
			<span class="limit">Time limit:</span><%=q["TimeLimit"]%> Seconds			<span class="limit">Memory limit:</span><%=q["MemoryLimit"]%> K 
			<span class="limit">Total submit:</span><%=q["SubmitCount"]%>&nbsp;&nbsp; 
			<span class="limit">Accepted submit: </span><%=q["AcceptedCount"]%>
		</div>
		<div id="main">
			<div id="contentHeadLeft">
				<div id="contentHeadRight">
					<div id="contentHeadCenter">
					</div>
				</div>
			</div>
			<div id="contentBodyLeft">
				<div id="contentBodyRight">
					<div id="contentBodyCenter">
						<div id="content">
							<div id="entries">
						<%=Html.QuestionFormat(q["body"].ToString()) %>
							</div>
						</div>
						<div class="clear">
							&nbsp;</div>
					</div>
				</div>
			</div>
			<div id="contentFootLeft">
				<div id="contentFootRight">
					<div id="contentFootCenter">
					</div>
				</div>
			</div>
		</div>
		<div class="center">
			<%=Html.SubmitLink("Submit",q["id"]) %>
			<a href="<%=ViewData["comefrom"]  %>">Back</a> 
			
			<a href="Status.aspx?id=1">
				Status</a>
		</div>
</asp:Content>
