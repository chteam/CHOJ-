using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ChswordOJ {
	/// <summary>
	/// ���ص�Master�ࡣ
	/// </summary>
	public class ChMasterPage : MasterPage {
		/// <summary>
		/// ���캯����
		/// </summary>
		public ChMasterPage() { }
		/// <summary>
		/// �õ���վ����Config.xml�е���Ϣ
		/// </summary>
		/// <param name="Name">Ҫ�����Ľ�����ơ�</param>
		/// <returns>���������ָ�����ݡ�</returns>
		protected String GetConfig(String Name) {
			return Xml.GetItemText("Config", Name);
		}
		/// <summary>
		/// �ú����ɻ��web.config�е��ַ�����
		/// </summary>
		/// <param name="Str">ָ����ļ�ֵ��</param>
		/// <returns>���ؼ�ֵ��ָ��ֵ��</returns>
		protected string GetString(string Str) {
			return System.Configuration.ConfigurationManager.AppSettings[Str];
		}
	}
	//public class ChDynamicDataPage : Microsoft.Web.DynamicDataControls.DynamicDataPage {
	//    /// <summary>
	//    /// ���캯��
	//    /// </summary>
	//    public ChDynamicDataPage() { }
	//    /// <summary>
	//    /// �õ���վ����Config.xml�е���Ϣ
	//    /// </summary>
	//    /// <param name="Name">Ҫ�����Ľ�����ơ�</param>
	//    /// <returns>���������ָ�����ݡ�</returns>
	//    protected String GetConfig(String Name)
	//    {
	//        return Xml.GetItemText("Config", Name);
	//    }
	//    /// <summary>
	//    /// ���ص�Render������
	//    /// </summary>
	//    /// <param name="writer">HtmlTextWriter��</param>
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
	//    /// ����Html��ǩ�ڣ���Link��ǩ����Css
	//    /// </summary>
	//    /// <param name="cssfile">Css�ļ���</param>
	//    protected void SetHtmlLink(string cssfile)
	//    {
	//        HtmlLink myHtmlLink = new HtmlLink();
	//        myHtmlLink.Href = cssfile;
	//        myHtmlLink.Attributes.Add("rel", "stylesheet");
	//        myHtmlLink.Attributes.Add("type", "text/css");
	//        Page.Header.Controls.Add(myHtmlLink);
	//    }
	//    /// <summary>
	//    /// �ú����ɻ��web.config�е��ַ�����
	//    /// </summary>
	//    /// <param name="Str">ָ����ļ�ֵ��</param>
	//    /// <returns>���ؼ�ֵ��ָ��ֵ��</returns>
	//    protected string GetString(string Str)
	//    {
	//        return System.Configuration.ConfigurationManager.AppSettings[Str];
	//    }
	//}
	/// <summary>
	/// ���ص�Page�ࡣ
	/// </summary>
	public class ChPage : Page {
		/// <summary>
		/// ���캯����
		/// </summary>
		public ChPage() { }
		/// <summary>
		/// �õ���վ����Config.xml�е���Ϣ
		/// </summary>
		/// <param name="Name">Ҫ�����Ľ�����ơ�</param>
		/// <returns>���������ָ�����ݡ�</returns>
		protected String GetConfig(String Name) {
			return Xml.GetItemText("Config", Name);
		}
		/// <summary>
		/// ���ص�Render������
		/// </summary>
		/// <param name="writer">HtmlTextWriter��</param>
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
		/// ����Html��ǩ�ڣ���Link��ǩ����Css
		/// </summary>
		/// <param name="cssfile">Css�ļ���</param>
		protected void SetHtmlLink(string cssfile) {
			HtmlLink myHtmlLink = new HtmlLink();
			myHtmlLink.Href = cssfile;
			myHtmlLink.Attributes.Add("rel", "stylesheet");
			myHtmlLink.Attributes.Add("type", "text/css");
			Page.Header.Controls.Add(myHtmlLink);
		}
		/// <summary>
		/// �ú����ɻ��web.config�е��ַ�����
		/// </summary>
		/// <param name="Str">ָ����ļ�ֵ��</param>
		/// <returns>���ؼ�ֵ��ָ��ֵ��</returns>
		protected string GetString(string Str) {
			return System.Configuration.ConfigurationManager.AppSettings[Str];
		}
	}

	internal class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter {
		private string _url; // �ٵ�URL
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
