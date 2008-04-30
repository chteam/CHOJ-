using System;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

public partial class Admin_XmlFile : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {

	}
	protected String GetList() {
		StringBuilder sb = new StringBuilder("<div><ul>");
		string fn;
		if (String.IsNullOrEmpty(Request.QueryString["file"]))
			fn = "Config";
		else
			fn = Request.QueryString["file"].ToString();
		XmlDocument dom = new XmlDocument();
		dom.Load(Server.MapPath(String.Format("~/xml/{0}.Xml", fn)));
		XmlNodeList nodeList = dom.SelectSingleNode(fn).ChildNodes;
		foreach(XmlNode xn in nodeList){//遍历所有子节点
			XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
			sb.AppendLine(String.Format("<li><a href=\"GetXml.aspx?file={0}&name={1}\">{2}</a>:---->{3}</li>",fn, xe.GetAttribute("name"),xe.GetAttribute("name"), Server.HtmlEncode(xe.InnerText)));
		}
		sb.AppendLine("</ul></div>");
		return sb.ToString();
	}
}