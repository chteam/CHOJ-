<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="Reg.aspx.cs" Inherits="Reg" Title="Register - Online Judge"
Theme="MemberShipSkin"
EnableViewState="false"
EnableViewStateMac="false"%>
<asp:Content ID="Content" ContentPlaceHolderID="Content" Runat="Server">
<div class="l30">
<asp:CreateUserWizard ID="cuw" runat="server" EnableViewState="false" OnCreatedUser="cuw_CreatedUser">
	<WizardSteps>
		<asp:CreateUserWizardStep runat="server">
		</asp:CreateUserWizardStep>
		<asp:CompleteWizardStep runat="server">
		</asp:CompleteWizardStep>
	</WizardSteps>
</asp:CreateUserWizard>
</div>
</asp:Content>

