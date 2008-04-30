<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="PageList" 
 EnableViewState="false"
  Title="Question Group List  - Online Judge"
   Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<div class="center"><ul>
<asp:Repeater ID="RG" runat="server">
<ItemTemplate><li><a href="Group.aspx?id=<%# Eval("id") %>"><%# Eval("name") %></a></li></ItemTemplate>
</asp:Repeater>
</ul></div></asp:Content>

