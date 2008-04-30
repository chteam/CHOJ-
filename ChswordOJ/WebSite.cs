using System;
using System.Collections.Generic;
using System.Text;

namespace ChswordOJ {
	/// <summary>
	/// 网站基础信息类。
	/// </summary>
	public static class WebSite {
		/// <summary>
		/// 得到网站配置Config.xml中的信息
		/// </summary>
		/// <param name="Name">要检索的结点名称。</param>
		/// <returns>检索结点所指的内容。</returns>
		public static String GetConfig(String Name) {
			return Xml.GetItemText("Config", Name);
		}
		///// <summary>
		///// 得到网站的标题。
		///// </summary>
		//public static String Title {
		//    get {
		//        return GetConfig("Title");
		//    }
		//}
		///// <summary>
		///// 得到网站的名称。
		///// </summary>
		//public static String WebSiteName {
		//    get {
		//        return GetConfig("WebSiteName");
		//    }
		//}
		///// <summary>
		///// 登录。
		///// </summary>
		//public static String Login {
		//    get {
		//        return GetConfig("Login");
		//    }
		//}
		///// <summary>
		///// 注销。
		///// </summary>
		//public static String Logout {
		//    get {
		//        return GetConfig("Logout");
		//    }
		//}
		///// <summary>
		///// 注册。
		///// </summary>
		//public static String Register {
		//    get {
		//        return GetConfig("Register");
		//    }
		//}
		///// <summary>
		///// 修改密码字符串。
		///// </summary>
		//public static String ChangePassword {
		//    get {
		//        return GetConfig("ChangePassword");
		//    }
		//}
		///// <summary>
		///// 得到网站底部版权信息
		///// </summary>
		//public static String Floor {
		//    get {
		//        return GetConfig("Floor");
		//    }
		//}
		///// <summary>
		///// 得到用户登录称乎
		///// </summary>
		//public static String Hello {
		//    get {
		//        return GetConfig("Hello");
		//    }
		//}

	}
}
