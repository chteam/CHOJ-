using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Wilco.Web.SyntaxHighlighting;

namespace CSSFriendly
{
    public class CSSPage : DynamicAdaptersPage
    {
        private string _relevantControlName = "";
        public string RelevantControlName
        {
            get { return _relevantControlName; }
            set { _relevantControlName = value; }
        }
        /// <summary>
        /// 得到网站配置Config.xml中的信息
        /// </summary>
        /// <param name="Name">要检索的结点名称。</param>
        /// <returns>检索结点所指的内容。</returns>
        protected String GetConfig(String Name)
        {
            return ChswordOJ.Xml.GetItemText("Config", Name);
        }
        /// <summary>
        /// 设置Html标签内，的Link标签，如Css
        /// </summary>
        /// <param name="cssfile">Css文件。</param>
        protected void SetHtmlLink(string cssfile)
        {
            HtmlLink myHtmlLink = new HtmlLink();
            myHtmlLink.Href = cssfile;
            myHtmlLink.Attributes.Add("rel", "stylesheet");
            myHtmlLink.Attributes.Add("type", "text/css");
            Page.Header.Controls.Add(myHtmlLink);
        }
        /// <summary>
        /// 该函数可获得web.config中的字符串。
        /// </summary>
        /// <param name="Str">指定项的键值。</param>
        /// <returns>返回键值所指的值。</returns>
        protected string GetString(string Str)
        {
            return System.Configuration.ConfigurationManager.AppSettings[Str];
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //  GenerateSnippets needs this override to NOT throw exceptions (which the base version does by default).
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            //  Snippet generation uses the method Control.RenderControl which ends up registering controls
            //  for event validation, in some cases.  This causes problems when the call to RenderControl is using
            //  a temp HTML writer instance because it alters the page's event validation string (stored in a
            //  hidden INPUT tag on the page) but doesn't actually add content to the page (because the page's normal
            //  HTML writer was not used).  The bottom line is that snippet generation causes event validation
            //  failures upon postback.
            //
            //  Therefore, pages deriving from ExamplePage should never use event validation. This is OK in this
            //  case because these are merely sample pages used to demonstrate an unrelated topic: adapters.
            //  In a more typical web site, you would almost certainly want to leave event validation enabled.           
            EnableEventValidation = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HttpCookie cookieLastVisitedExampleUrl = new HttpCookie("LastVisitedExampleUrl");
            HttpCookie cookieLastVisitedExampleControl = new HttpCookie("LastVisitedExampleControl");
            cookieLastVisitedExampleUrl.Value = Request.Url.ToString();
            cookieLastVisitedExampleControl.Value = RelevantControlName;
            if (Response.Cookies["LastVisitedExampleUrl"] == null)
            {
                Response.Cookies.Add(cookieLastVisitedExampleUrl);
            }
            else
            {
                Response.Cookies.Set(cookieLastVisitedExampleUrl);
            }
            if (Response.Cookies["LastVisitedExampleControl"] == null)
            {
                Response.Cookies.Add(cookieLastVisitedExampleControl);
            }
            else
            {
                Response.Cookies.Set(cookieLastVisitedExampleControl);
            }
        }

        //protected void GenerateSnippets(Control c, WebControlAdapter adapter)
        //{
        //    if (Compatible)
        //    {
        //        Snippet snippet = new Snippet(c, adapter);
        //        snippet.HandleExceptions = false;

        //        SyntaxHighlighter adapted = Master.Master.FindControl("MainContent").FindControl("SnippetWithAdapterContainer").FindControl("AdapterResponse") as SyntaxHighlighter;
        //        SyntaxHighlighter unadapted = Master.Master.FindControl("MainContent").FindControl("SnippetWithoutAdapterContainer").FindControl("NativeResponse") as SyntaxHighlighter;

        //        if ((adapted != null) && (unadapted != null))
        //        {
        //            try
        //            {
        //                adapted.Text = snippet.AdaptedHtml;
        //            }
        //            catch (System.FieldAccessException fieldAccessExc)
        //            {
        //                adapted.Mode = HighlightMode.Literal;
        //                adapted.Text = "To see this snippet, please:<br /><ol><li>Turn on the CSS Friendly adapters or</li><li>Run this web application with full trust.</li></ol>";
        //            }
        //            catch (System.MethodAccessException methodAccessExc)
        //            {
        //                adapted.Mode = HighlightMode.Literal;
        //                adapted.Text = "To see this snippet, please:<br /><ol><li>Turn on the CSS Friendly adapters or</li><li>Run this web application with full trust.</li></ol>";
        //            }
        //            catch (Exception e)
        //            {
        //            }

        //            try
        //            {
        //                unadapted.Text = snippet.UnadaptedHtml;
        //            }
        //            catch (System.FieldAccessException fieldAccessExc)
        //            {
        //                unadapted.Mode = HighlightMode.Literal;
        //                unadapted.Text = "To see this snippet, please:<br /><ol><li>Turn off the CSS Friendly adapters or</li><li>Run this web application with full trust.</li></ol>";
        //            }
        //            catch (System.MethodAccessException methodAccessExc)
        //            {
        //                unadapted.Mode = HighlightMode.Literal;
        //                unadapted.Text = "To see this snippet, please:<br /><ol><li>Turn off the CSS Friendly adapters or</li><li>Run this web application with full trust.</li></ol>";
        //            }
        //            catch (Exception e)
        //            {
        //            }
        //        }
        //    }
        //}
    }
}