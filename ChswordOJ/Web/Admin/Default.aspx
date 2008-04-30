<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" 
CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="基本设置" 
 Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<ul>
<li><a href="XmlFile.aspx?file=Config">基本配置更改</a></li>
<li><a href="XmlFile.aspx?file=Compiler">编译器更改</a></li>
<li><a href="XmlFile.aspx?file=Status">测试状态更改</a></li>
</ul>
</div>
</asp:Content>

