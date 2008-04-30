using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ChswordOJ {
	/// <summary>
	/// 重载的Master类。
	/// </summary>
	public class ChMasterPage : MasterPage {
		/// <summary>
		/// 构造函数。
		/// </summary>
		public ChMasterPage() { }
		/// <summary>
		/// 得到网站配置Config.xml中的信息
		/// </summary>
		/// <param name="Name">要检索的结点名称。</param>
		/// <returns>检索结点所指的内容。</returns>
		protected String GetConfig(String Name) {
			return Xml.GetItemText("Config", Name);
		}
		/// <summary>
		/// 该函数可获得web.config中的字符串。
		/// </summary>
		/// <param name="Str">指定项的键值。</param>
		/// <returns>返回键值所指的值。</returns>
		protected string GetString(string Str) {
			return System.Configuration.ConfigurationManager.AppSettings[Str];
		}
	}
	//public class ChDynamicDataPage : Microsoft.Web.DynamicDataControls.DynamicDataPage {
	//    /// <summary>
	//    /// 构造函数
	//    /// </summary>
	//    public ChDynamicDataPage() { }
	//    /// <summary>
	//    /// 得到网站配置Config.xml中的信息
	//    /// </summary>
	//    /// <param name="Name">要检索的结点名称。</param>
	//    /// <returns>检索结点所指的内容。</returns>
	//    protected String GetConfig(String Name)
	//    {
	//        return Xml.GetItemText("Config", Name);
	//    }
	//    /// <summary>
	//    /// 重载的Render函数。
	//    /// </summary>
	//    /// <param name="writer">HtmlTextWriter。</param>
	//    protected override void Render(HtmlTextWriter writer)
	//    {
	//        if (writer is System.Web.UI.Html32TextWriter)
	//        {
	//            writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
	//        }
	//        else
	//        {
	//            writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
	//        }
	//        base.Render(writer);
	//    }
	//    /// <summary>
	//    /// 设置Html标签内，的Link标签，如Css
	//    /// </summary>
	//    /// <param name="cssfile">Css文件。</param>
	//    protected void SetHtmlLink(string cssfile)
	//    {
	//        HtmlLink myHtmlLink = new HtmlLink();
	//        myHtmlLink.Href = cssfile;
	//        myHtmlLink.Attributes.Add("rel", "stylesheet");
	//        myHtmlLink.Attributes.Add("type", "text/css");
	//        Page.Header.Controls.Add(myHtmlLink);
	//    }
	//    /// <summary>
	//    /// 该函数可获得web.config中的字符串。
	//    /// </summary>
	//    /// <param name="Str">指定项的键值。</param>
	//    /// <returns>返回键值所指的值。</returns>
	//    protected string GetString(string Str)
	//    {
	//        return System.Configuration.ConfigurationManager.AppSettings[Str];
	//    }
	//}
	/// <summary>
	/// 重载的Page类。
	/// </summary>
	public class ChPage : Page {
		/// <summary>
		/// 构造函数。
		/// </summary>
		public ChPage() { }
		/// <summary>
		/// 得到网站配置Config.xml中的信息
		/// </summary>
		/// <param name="Name">要检索的结点名称。</param>
		/// <returns>检索结点所指的内容。</returns>
		protected String GetConfig(String Name) {
			return Xml.GetItemText("Config", Name);
		}
		/// <summary>
		/// 重载的Render函数。
		/// </summary>
		/// <param name="writer">HtmlTextWriter。</param>
		protected override void Render(HtmlTextWriter writer) {
			if (writer is System.Web.UI.Html32TextWriter) {
				writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
			}
			else {
				writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
			}
			base.Render(writer);
		}
		/// <summary>
		/// 设置Html标签内，的Link标签，如Css
		/// </summary>
		/// <param name="cssfile">Css文件。</param>
		protected void SetHtmlLink(string cssfile) {
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
		protected string GetString(string Str) {
			return System.Configuration.ConfigurationManager.AppSettings[Str];
		}
	}

	internal class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter {
		private string _url; // 假的URL
		internal FormFixerHtml32TextWriter(TextWriter writer)
			: base(writer) {
			_url = HttpContext.Current.Request.RawUrl;
		}
		public override void WriteAttribute(string name, string value, bool encode) {
			if (_url != null && string.Compare(name, "action", true) == 0) {
				value = _url;
			}
			base.WriteAttribute(name, value, encode);
		}
	}
	internal class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter {
		private string _url;
		internal FormFixerHtmlTextWriter(TextWriter writer)
			: base(writer) {
			_url = HttpContext.Current.Request.RawUrl;
		}
		public override void WriteAttribute(string name, string value, bool encode) {
			if (_url != null && string.Compare(name, "action", true) == 0) {
				value = _url;
			}
			base.WriteAttribute(name, value, encode);
		}
	}
}
