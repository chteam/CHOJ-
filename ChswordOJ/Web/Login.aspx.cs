using System;
using CSSFriendly;
using Wilco.Web.SyntaxHighlighting;
public partial class PageLogin : ChswordOJ.ChPage
{
    protected void Page_Init(object sender, EventArgs e){
        //this.SetHtmlLink("css/MemberShip.css");
        myLogin.LoginButtonText = GetConfig("Login");
        myLogin.UserNameLabelText = GetConfig("UserNameLabelText");
        myLogin.PasswordLabelText = GetConfig("PasswordLabelText");
        myLogin.TitleText = GetConfig("Login");
        myLogin.RememberMeText = GetConfig("RememberMeText");
        myLogin.FailureText = GetConfig("LoginFailureText");
        myLogin.CreateUserText = GetConfig("CreateUserText");
        myLogin.PasswordRecoveryText = GetConfig("PasswordRecovery");
        myLogin.ToolTip = GetConfig("LoginToolTip");
        myLogin.DestinationPageUrl = "Default.aspx";
        myLogin.PasswordRecoveryUrl = "GetPassWord.aspx";
    }
}
