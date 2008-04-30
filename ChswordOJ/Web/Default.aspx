<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"
AutoEventWireup="true" CodeFile="Default.aspx.cs"
Inherits="_Default"
EnableViewState="false"
EnableViewStateMac="false"
EnableEventValidation="false"
 Theme="MemberShipSkin"
 %>
<asp:Content ID="Content" ContentPlaceHolderID="Content" Runat="Server">
<div class="center">
<dl>
<dd><a href="List.aspx"><%=GetConfig("ProblemsOnline") %></a></dd>
<dd><a href="Status.aspx"><%=GetConfig("Status") %></a></dd>
<dd><a href="Sort.aspx"><%=GetConfig("RankList")%></a></dd>
<asp:LoginView ID="Lv1" runat="server">
<LoggedInTemplate>
<dd>
<a href="Submit.aspx"><%=GetConfig("SubmitAnswer")%></a>
</dd>
</LoggedInTemplate>
</asp:LoginView>
<dd><%=GetConfig("SuggestTools")%><br />
<a href="http://download.csdn.net/source/164917">DevCpp 4.9.9.2</a><br />
<a href="http://www.microsoft.com/china/msdn/express/vc.aspx" title="Visual C++ Express Edition">
Visual C++ 2005 Express Edition</a><br />
<a href="http://www.microsoft.com/china/msdn/express/vb.aspx" title="Visual Basic 2005 Express Edition">
Visual Basic 2005 Express Edition
</a><br />
<a href="http://www.microsoft.com/china/msdn/express/csharp.aspx" title="Visual C# 2005 Express Edition">
Visual C# 2005 Express Edition
</a><br />
<a href="http://www.microsoft.com/china/msdn/express/vj.aspx" title="Visual J# 2005 Express Edition">
Visual J# 2005 Express Edition
</a><br />
</dd>
</dl>
</div>
</asp:Content>
<%--		
<p><%
MembershipUser u;
u = Membership.GetUser(User.Identity.Name);
 %></p>--%>