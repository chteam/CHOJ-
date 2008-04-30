using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ChswordOJ {
	/// <summary>
	/// �Գɻ�Online Judge���� ��Xml������
	/// </summary>
	public static class Xml {
		/// <summary>
		/// ͨ��һ��item����name������value���Ե����ݡ�
		/// </summary>
		/// <param name="fn">���ҵ�Xml�ļ���</param>
		/// <param name="name">name���Ե�ֵ��</param>
		/// <returns>����value���Ե�ֵ��</returns>
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
		/// ͨ��һ��item����name��������Ԫ�ص����ݡ�
		/// </summary>
		/// <param name="fn">���ҵ�Xml�ļ���</param>
		/// <param name="name">name���Ե�ֵ��</param>
		/// <returns>��������Ԫ�ص����ݡ�</returns>
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
		/// ����һ��XML���ӽڵ㡣
		/// </summary>
		/// <param name="fn">���ҵ�Xml�ļ���</param>
		/// <param name="Xpath">Xpath��ѯ���ʽ��</param>
		/// <returns>���صķ���Xpath��Node��</returns>
		static System.Xml.XmlNode GetNode(String fn,String Xpath) {
				System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
				dom.LoadXml(HttpContext.Current.Cache[fn].ToString());
				return dom.SelectSingleNode(Xpath);
		}
		/// <summary>
		/// �鿴ָ�������Ƿ���ڡ�
		/// </summary>
		/// <param name="CacheName">Ҫ���Ļ������ơ�</param>
		/// <returns>����һ��Boolean����ʾ�Ƿ���ڡ�</returns>
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
