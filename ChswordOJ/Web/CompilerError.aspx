<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
CodeFile="CompilerError.aspx.cs" Inherits="CompilerError"
%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<asp:Repeater ID="Repeater" runat="server">
<ItemTemplate>
<h3><%=GetConfig("AnswerId") %>:<%=Request.QueryString["id"] %>
<%=GetConfig("QuestionId") %>:<%#Eval("QuestionId") %></h3>
<pre><%#ChswordOJ.ChString.SetQuestion(Eval("Complier").ToString())%>
</pre><div><%=GetConfig("UserName") %>:<%#Eval("username") %> <%=GetConfig("SubmitTime") %>:<%#Eval("Addtime")%></div>
</ItemTemplate>
</asp:Repeater>
</asp:Content>

