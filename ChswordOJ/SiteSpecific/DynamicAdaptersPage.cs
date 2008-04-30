using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace CSSFriendly
{
    public class DynamicAdaptersPage : System.Web.UI.Page
    {
        private Hashtable _adaptersOrig = new Hashtable();

        private bool _compatible = false;
        public bool Compatible
        {
            get { return _compatible; }
        }

        public override string StyleSheetTheme
        {
            get
            {
                return (Request.Cookies["PreferredTheme"] != null) ? Request.Cookies["PreferredTheme"].Value : base.StyleSheetTheme;            
            }
            set
            {
                base.StyleSheetTheme = value;
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (IsPostBack && (Request.Form["__EVENTTARGET"] != null) && (Request.Form["__EVENTTARGET"].IndexOf("adaptersenabled", StringComparison.OrdinalIgnoreCase) > -1))
            {
                CSSFriendly.Context.Enabled = !CSSFriendly.Context.Enabled;
            }

            DetermineCompatibility();
            if (_compatible && (!CSSFriendly.Context.Enabled))
            {
                DisableAdapters();
            }

            base.OnPreInit(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);

            if (_compatible)
            {
                RestoreAdapters();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////        

        protected void DisableAdapters()
        {
            _adaptersOrig.Clear();

            foreach (DictionaryEntry entry in HttpContext.Current.Request.Browser.Adapters)
            {
                _adaptersOrig.Add(entry.Key, entry.Value);
            }

            HttpContext.Current.Request.Browser.Adapters.Clear();
        }

        protected void RestoreAdapters()
        {
            foreach (DictionaryEntry entry in _adaptersOrig)
            {
                HttpContext.Current.Request.Browser.Adapters.Add(entry.Key, entry.Value);
            }

            _adaptersOrig.Clear();
        }

        private bool DetermineCompatibility()
        {
            _compatible = false;
            foreach (DictionaryEntry entry in HttpContext.Current.Request.Browser.Adapters)
            {
                if (entry.Value.ToString().IndexOf("CSSFriendly", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    _compatible = true;
                    break;
                }
            }

            return _compatible;
        }
    }
}