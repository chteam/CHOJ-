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
using System.Xml;
public partial class Admin_GetXml : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {
		string fn,name;
		if (String.IsNullOrEmpty(Request.QueryString["file"]))
			fn = "Config";
		else
			fn = Request.QueryString["file"].ToString();
		if (String.IsNullOrEmpty(Request.QueryString["name"]))
			name = "Title";
		else
			name = Request.QueryString["name"].ToString();
		if (!IsPostBack) {
			System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
			dom.Load(Server.MapPath(String.Format("~/xml/{0}.Xml", fn)));
			TValue.Text = dom.SelectSingleNode(String.Format("//item[@name=\"{0}\"]", name)).InnerText;
			Tname.Text = name;
		}
	}
	protected void Button1_Click(object sender, EventArgs e) {
		string fn, name;
		if (String.IsNullOrEmpty(Request.QueryString["file"]))
			fn = "Config";
		else
			fn = Request.QueryString["file"].ToString();
		if (String.IsNullOrEmpty(Request.QueryString["name"]))
			name = "Title";
		else
			name = Request.QueryString["name"].ToString();
		XmlDocument dom = new XmlDocument();
		dom.Load(Server.MapPath(String.Format("~/xml/{0}.Xml", fn)));
		XmlNodeList nodeList = dom.SelectSingleNode(fn).ChildNodes;
		foreach (XmlNode xn in nodeList) {//遍历所有子节点
			XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型  
			if (xe.GetAttribute("name") == name){
				xe.InnerText = TValue.Text;//则修改该属性为“update李赞红”  
				break;
			}   
		}
		dom.Save(Server.MapPath(String.Format("~/xml/{0}.Xml", fn)));//保存。 
	}
}
