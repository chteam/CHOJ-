<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="Login.aspx.cs" Inherits="PageLogin"
EnableViewState="false"
Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<div class="l30">
<asp:Login ID="myLogin" runat="server"  SkinID="SampleLogin"></asp:Login>
</div>
</asp:Content>
