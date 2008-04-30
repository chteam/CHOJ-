<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="submit.aspx.cs" Inherits="Submit" ValidateRequest="false" EnableViewState="false"
    Theme="MemberShipSkin" %>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="Server">
    <div class="center">
        <%=GetConfig("UserName") %>
        :
        <asp:TextBox ID="username" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
            ErrorMessage="请先登录">*</asp:RequiredFieldValidator><br />
        <%=GetConfig("QuestionId") %>
        :<asp:TextBox ID="Num" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Num"
            ErrorMessage="Please input your id of Problem">*</asp:RequiredFieldValidator><br />
        <%=GetConfig("Compiler") %>
        :<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Selected="True" Value="cpp,">C++</asp:ListItem>
            <asp:ListItem Value="c,">C</asp:ListItem>
            <asp:ListItem Value="cs,2">C# on .Net2.0</asp:ListItem>
            <asp:ListItem Value="vb,2">VB.net on .Net2.0</asp:ListItem>
        </asp:DropDownList><br />
        <%=GetConfig("Code") %>
        :<asp:TextBox ID="TCode" TextMode="MultiLine" runat="server" Height="237px" Width="416px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TCode"
            ErrorMessage="Please Input your Code">*</asp:RequiredFieldValidator><br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" /></div>
</asp:Content>
<%--
<asp:ListItem Value="cs,1">C# on .Net1.1</asp:ListItem>
<asp:ListItem Value="vb,1">VB.net on .Net1.1</asp:ListItem>
<asp:ListItem Value="jsl,2">J# on .Net2.0</asp:ListItem>
<asp:ListItem Value="js,2">JScript on .Net2.0</asp:ListItem>
<asp:ListItem Value="js,1">JScript on .Net1.1</asp:ListItem>--%>
