using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ChswordOJ {
	/// <summary>
	/// 对成幻Online Judge内置 的Xml操作。
	/// </summary>
	public static class Xml {
		/// <summary>
		/// 通过一个item结点的name查找其value属性的内容。
		/// </summary>
		/// <param name="fn">查找的Xml文件。</param>
		/// <param name="name">name属性的值。</param>
		/// <returns>返回value属性的值。</returns>
		public static String GetItemName(String fn, String name) {
			/*if (CheckCache(fn)) {
				//System.Xml.XmlNode Node = ;
				//String result = GetNode(fn, String.Format("//item[@name=\"{0}\"]", name)).Attributes["value"].InnerXml;
				if (CheckCache(String.Format("{0}.{1}", fn, name), result))
					return result;
			}*/
			return GetItemText(fn,name);
		}
		/// <summary>
		/// 通过一个item结点的name查找其子元素的内容。
		/// </summary>
		/// <param name="fn">查找的Xml文件。</param>
		/// <param name="name">name属性的值。</param>
		/// <returns>查找其子元素的内容。</returns>
		public static String GetItemText(String fn, String name) {
			if (CheckCache(fn)) {
				//System.Xml.XmlNode Node = ;
				String result = GetNode(fn,String.Format("//item[@name=\"{0}\"]", name)).InnerText;
				if (CheckCache(String.Format("{0}.{1}", fn, name), result))
					return result;
			}
			return "";
		}
		/// <summary>
		/// 查找一个XML的子节点。
		/// </summary>
		/// <param name="fn">查找的Xml文件。</param>
		/// <param name="Xpath">Xpath查询表达式。</param>
		/// <returns>返回的符合Xpath的Node。</returns>
		static System.Xml.XmlNode GetNode(String fn,String Xpath) {
				System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
				dom.LoadXml(HttpContext.Current.Cache[fn].ToString());
				return dom.SelectSingleNode(Xpath);
		}
		/// <summary>
		/// 查看指定缓存是否存在。
		/// </summary>
		/// <param name="CacheName">要检测的缓存名称。</param>
		/// <returns>返回一个Boolean，表示是否存在。</returns>
		static Boolean CheckCache(String CacheName) {
			Cache cache=new Cache();
			if (cache.IsNullorEmpty(CacheName))
				if (!cache.SetCache(CacheName))
					return false;
			return true;
		}
		static Boolean CheckCache(String CacheName,String CacheValue) {
			Cache cache = new Cache();
			if (cache.IsNullorEmpty(CacheName))
				if (!cache.SetCache(CacheName,CacheValue))
					return false;
			return true;
		}
	}
}
