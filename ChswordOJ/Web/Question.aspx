<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"
AutoEventWireup="true" CodeFile="Question.aspx.cs"
Inherits="PageQuestion"
EnableViewState="false"
Theme="MemberShipSkin"
%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<asp:Repeater ID="RQuestion" runat="server">
<ItemTemplate>
<h3><%#Eval("Title") %></h3>
<div class="center">
<span class="limit"><%=GetConfig("TimeLimit")%>:</span><%#Eval("TimeLimit") %> <%=GetConfig("Seconds")%>
<span class="limit"><%=GetConfig("MemoryLimit")%>: </span><%#Eval("MemoryLimit") %> K
<span class="limit"><%=GetConfig("TotalSubmit")%>:</span><%#Eval("SubmitCount") %>&nbsp;&nbsp;
<span class="limit"><%=GetConfig("AcceptedSubmit")%>: </span><%#Eval("AcceptedCount") %>
</div>
<div id="main">
<div id="contentHeadLeft">
<div id="contentHeadRight">
<div id="contentHeadCenter">
</div></div></div>
<div id="contentBodyLeft">
<div id="contentBodyRight">
<div id="contentBodyCenter">
<div id="content">
<div id="entries">
<%#ChswordOJ.ChString.SetQuestion(Eval("Body").ToString())%>
</div>
</div>
<div class="clear">&nbsp;</div>
</div>
</div>
</div>
<div id="contentFootLeft"><div id="contentFootRight"><div id="contentFootCenter"></div></div></div>
</div><hr />
<div class="center">
<a href="Submit.aspx?id=<%=Request.QueryString["id"] %>"><%=GetConfig("Submit")%></a>
<a href="Group.aspx?id=<%#Eval("Groupid") %>"><%=GetConfig("Back")%></a>
<a href="Status.aspx?id=<%=Request.QueryString["id"] %>"><%=GetConfig("Status")%></a>
</div></ItemTemplate></asp:Repeater>
</asp:Content>

