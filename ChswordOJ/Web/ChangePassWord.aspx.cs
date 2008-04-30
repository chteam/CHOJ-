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

public partial class PageChangePassWord : ChswordOJ.ChPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
		ChangePassword1.CancelButtonText = GetConfig("Cancel");
		ChangePassword1.ChangePasswordButtonText = GetConfig("ChangePassword");
		ChangePassword1.ChangePasswordFailureText = GetConfig("ChangePasswordFailureText");
		ChangePassword1.ConfirmNewPasswordLabelText = GetConfig("ConfirmNewPasswordLabelText");
		ChangePassword1.ContinueButtonText = GetConfig("ContinueButtonText");
		ChangePassword1.NewPasswordLabelText = GetConfig("NewPasswordLabelText");
		ChangePassword1.PasswordLabelText = GetConfig("PasswordLabelText");
		ChangePassword1.SuccessText = GetConfig("ChangePassword.SuccessText");
		ChangePassword1.SuccessTitleText = GetConfig("ChangePassword.SuccessTitleText");
		ChangePassword1.UserNameLabelText = GetConfig("UserNameLabelText");
		ChangePassword1.ConfirmPasswordCompareErrorMessage = GetConfig("ConfirmPasswordCompareErrorMessage");
		ChangePassword1.ConfirmPasswordRequiredErrorMessage = GetConfig("ConfirmPasswordRequiredErrorMessage");
		ChangePassword1.NewPasswordRegularExpressionErrorMessage = GetConfig("NewPasswordRegularExpressionErrorMessage");
		ChangePassword1.PasswordRequiredErrorMessage = GetConfig("PasswordRequiredErrorMessage");
		ChangePassword1.UserNameRequiredErrorMessage = GetConfig("UserNameRequiredErrorMessage");
		ChangePassword1.ContinueDestinationPageUrl = "~/";
        ChangePassword1.ChangePasswordTitleText = GetConfig("ChangePassword");
    }
}
