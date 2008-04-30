<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master"
 AutoEventWireup="true" CodeFile="Question_Add.aspx.cs" 
 Inherits="Admin_Question_Add" Title="问题编辑" 
  ValidateRequest="false" Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
标题<asp:TextBox ID="tTitle" runat="server" Width="512px" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tTitle"
ErrorMessage="必须填写标题">*</asp:RequiredFieldValidator><br />
分类<asp:DropDownList ID="tGroupid" runat="server" DataSourceID="OGroup" DataTextField="name" DataValueField="id">
	</asp:DropDownList><br />
具体内容<asp:TextBox ID="tBody" runat="server" Height="301px" TextMode="MultiLine"
Width="490px" />
	<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tBody"
		ErrorMessage="必须填写内容">*</asp:RequiredFieldValidator><br />
测试文件<asp:TextBox ID="tTest" runat="server" Height="187px" TextMode="MultiLine"
Width="490px" />
	<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tTest"
		ErrorMessage="测试文件不能为空">*</asp:RequiredFieldValidator><br />
时间限制<asp:TextBox ID="tTimeLimit" runat="server">3</asp:TextBox>(秒)<asp:RequiredFieldValidator
	ID="RequiredFieldValidator4" runat="server" ControlToValidate="tTimeLimit" ErrorMessage="请填写时间限制">*</asp:RequiredFieldValidator>
	<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tTimeLimit"
		Display="Dynamic" ErrorMessage="时间限制必需为数字 " ValidationExpression="\d+"></asp:RegularExpressionValidator><br />
内存限制<asp:TextBox ID="tMemoryLimit" runat="server">32768</asp:TextBox>(KB)<asp:RequiredFieldValidator
	ID="RequiredFieldValidator5" runat="server" ControlToValidate="tMemoryLimit"
	ErrorMessage="请填写内存限制">*</asp:RequiredFieldValidator>
	<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tMemoryLimit"
		Display="Dynamic" ErrorMessage="内存限制必需为数字" ValidationExpression="\d+"></asp:RegularExpressionValidator><br />
<asp:Label ID="Label1" runat="server" ForeColor="red" />
<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />	<asp:ObjectDataSource ID="OGroup" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
		OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GetGroupTableAdapters.GroupSelectTableAdapter"
		UpdateMethod="Update">
	</asp:ObjectDataSource>
</asp:Content>

