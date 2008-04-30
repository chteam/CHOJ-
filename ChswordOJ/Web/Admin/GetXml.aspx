<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" 
CodeFile="GetXml.aspx.cs" Inherits="Admin_GetXml" EnableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	名称：<asp:TextBox ID="Tname" runat="server" Enabled="False"></asp:TextBox>
	值：<asp:TextBox ID="TValue" runat="server" Height="132px" TextMode="MultiLine" Width="365px"></asp:TextBox>
	<asp:Button ID="Button1"
		runat="server" Text="Update" OnClick="Button1_Click" />
</asp:Content>

