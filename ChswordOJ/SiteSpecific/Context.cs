using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CSSFriendly
{
    public class Context
    {
        static public bool Enabled
        {
            get { return ((HttpContext.Current == null) || (HttpContext.Current.Request == null) || (HttpContext.Current.Request.Cookies["CssFriendlyAdaptersEnabled"] == null) || (HttpContext.Current.Request.Cookies["CssFriendlyAdaptersEnabled"].Value == Boolean.TrueString)); }
            set
            {
                if ((HttpContext.Current != null) && (HttpContext.Current.Request != null))
                {
                    HttpCookie cookie = new HttpCookie("CssFriendlyAdaptersEnabled");
                    cookie.Value = value.ToString();
                    if (HttpContext.Current.Request.Cookies["CssFriendlyAdaptersEnabled"] == null)
                    {
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        HttpContext.Current.Response.Cookies.Set(cookie);
                    }
                }
            }
        }
    }
}
