using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Reg : ChswordOJ.ChPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //cuw..CssSelectorClass="PrettyCreateUserWizard";
        cuw.HeaderText = GetConfig("Registration");
        cuw.InstructionText = GetConfig("RegistrationInstructionText");
        cuw.UserNameLabelText = GetConfig("UserNameLabelText");
        cuw.PasswordLabelText = GetConfig("PasswordLabelText"); 
            //PasswordHintText="Please see the HINT box below for the user name and password that can be used with this sample." 
        cuw.ConfirmPasswordLabelText = GetConfig("ConfirmPasswordLabelText"); 
        cuw.EmailLabelText=GetConfig("EmailLabelText");
        cuw.QuestionLabelText=GetConfig("QuestionLabelText");
        cuw.AnswerLabelText=GetConfig("AnswerLabelText");
        cuw.CompleteSuccessText =GetConfig("CompleteSuccessText") ;
        cuw.ContinueDestinationPageUrl = "Default.aspx";
        cuw.ContinueButtonText=GetConfig("ContinueButtonText");
        cuw.CreateUserButtonText=GetConfig("CreateUserButtonText");
        cuw.CreateUserStep.Title = GetConfig("CreateUserStep");
        cuw.CompleteStep.Title = GetConfig("Complete");
    }
	protected void ContinueButton_Click(object sender, EventArgs e) {
		Response.Redirect("Default.aspx");
	}
	protected void cuw_CreatedUser(object sender, EventArgs e) {
		ChswordOJ.Option op=new ChswordOJ.Option();//在创立membership的同时建立数据
		op.SetUser(cuw.UserName);
	
	}
}
