using System;
using System.Collections.Generic;
using System.Text;

namespace ChswordOJ {
	/// <summary>
	/// ��վ������Ϣ�ࡣ
	/// </summary>
	public static class WebSite {
		/// <summary>
		/// �õ���վ����Config.xml�е���Ϣ
		/// </summary>
		/// <param name="Name">Ҫ�����Ľ�����ơ�</param>
		/// <returns>���������ָ�����ݡ�</returns>
		public static String GetConfig(String Name) {
			return Xml.GetItemText("Config", Name);
		}
		///// <summary>
		///// �õ���վ�ı��⡣
		///// </summary>
		//public static String Title {
		//    get {
		//        return GetConfig("Title");
		//    }
		//}
		///// <summary>
		///// �õ���վ�����ơ�
		///// </summary>
		//public static String WebSiteName {
		//    get {
		//        return GetConfig("WebSiteName");
		//    }
		//}
		///// <summary>
		///// ��¼��
		///// </summary>
		//public static String Login {
		//    get {
		//        return GetConfig("Login");
		//    }
		//}
		///// <summary>
		///// ע����
		///// </summary>
		//public static String Logout {
		//    get {
		//        return GetConfig("Logout");
		//    }
		//}
		///// <summary>
		///// ע�ᡣ
		///// </summary>
		//public static String Register {
		//    get {
		//        return GetConfig("Register");
		//    }
		//}
		///// <summary>
		///// �޸������ַ�����
		///// </summary>
		//public static String ChangePassword {
		//    get {
		//        return GetConfig("ChangePassword");
		//    }
		//}
		///// <summary>
		///// �õ���վ�ײ���Ȩ��Ϣ
		///// </summary>
		//public static String Floor {
		//    get {
		//        return GetConfig("Floor");
		//    }
		//}
		///// <summary>
		///// �õ��û���¼�ƺ�
		///// </summary>
		//public static String Hello {
		//    get {
		//        return GetConfig("Hello");
		//    }
		//}

	}
}
