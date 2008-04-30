

using System;
public partial class GetPassWord : ChswordOJ.ChPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        PasswordRecovery1.UserNameTitleText = GetConfig("PasswordRecoveryUserNameTitleText");
        PasswordRecovery1.UserNameLabelText = GetConfig("UserNameLabelText");
        PasswordRecovery1.UserNameInstructionText = GetConfig("PasswordRecoveryUserNameInstructionText");

        PasswordRecovery1.QuestionTitleText = GetConfig("PasswordRecoveryQuestionTitleText");
        PasswordRecovery1.AnswerLabelText = GetConfig("AnswerLabelText");
        PasswordRecovery1.QuestionLabelText =  GetConfig("QuestionLabelText");
        PasswordRecovery1.QuestionInstructionText = GetConfig("QuestionInstructionText");

        PasswordRecovery1.SuccessText =  GetConfig("PasswordRecoverySuccessText");

        PasswordRecovery1.GeneralFailureText =  GetConfig("PasswordRecoveryGeneralFailureText");
        PasswordRecovery1.UserNameFailureText = GetConfig("PasswordRecoveryUserNameFailureText");
        PasswordRecovery1.QuestionFailureText = GetConfig("PasswordRecoveryQuestionFailureText");
        
        PasswordRecovery1.SubmitButtonText = GetConfig("Submit"); 
            
    }
}
