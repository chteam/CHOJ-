using System;
using System.Text.RegularExpressions;
using System.Reflection;
namespace ChswordOJ {
	/// <summary>
	/// ChString �Ƕ����ڲ��ַ������д�����࣬������һ����̬�ࡣ
	/// </summary>
	public static class ChString {
		/// <summary>
		/// ��֪���Ӻͷ�ĸ������£����ذٷֱȡ�
		/// </summary>
		/// <param name="fz">����</param>
		/// <param name="fm">��ĸ</param>
		/// <returns>�������ĸ����İٷֱȡ�</returns>
		public static String Ratio(Object fz,Object fm) {
			try {
				Int64 numz = (Int64)fz;
				Int64 numm = (Int64)fm;
				if (numz == 0) return "0%";
				if (numm == 0) return "0%";
				return String.Format("{0}%", numz * 100 / numm);
			}
			catch {
				return "error";
			}
		}
		/// <summary>
		/// ���ع����õ���ǰ����״̬�������Ա�����
		/// </summary>
		/// <param name="i">����״̬���롣</param>
		/// <param name="AnswerId">�Ǹ��ύ�Ĵ����AnswerId</param>
		/// <returns>����һ���ַ�������ʾ�û��ύ�����״̬��֧��HTML</returns>
		public static String GetStatus(String i, Int64 AnswerId) {
			return GetStatus(i, AnswerId, false);
		}
		/// <summary>
		/// ���ع����õ���ǰ����״̬�������Ա�����
		/// </summary>
		/// <param name="i">����״̬���롣</param>
		/// <param name="AnswerId">�Ǹ��ύ�Ĵ����AnswerId</param>
		/// <param name="IsAdmin">�Ƿ�Ϊ��̨�û�������ǣ�����Բ鿴Դ����</param>
		/// <returns>����һ���ַ�������ʾ�û��ύ�����״̬��֧��HTML</returns>
		public static String GetStatus(String i, Int64 AnswerId, Boolean IsAdmin) {
			String Result;
			if (i != "70")
				Result = Xml.GetItemText("Status", i);
			else
				Result = string.Format(Xml.GetItemText("Status", i), AnswerId);
			if (IsAdmin)
				Result = Result + string.Format(Xml.GetItemText("Status", "true"), AnswerId);
			else
				Result = Result + Xml.GetItemText("Status", "false");
			return Result;
		}
		/// <summary>
		/// �õ�������������
		/// </summary>
		/// <param name="s">�������Ĵ��š�</param>
		/// <returns>���ر�������ȫ��</returns>
		public static String GetCompiler(String s) {
			String temp = s.ToLower();
			return Xml.GetItemName("Compiler", temp);
		}
		/// <summary>
		/// ��Question���и�ʽ����
		/// </summary>
		/// <param name="Question">Question��Ϊһ���ַ�����</param>
		/// <returns>��ʽ�����Question��</returns>
		public static String SetQuestion(String Question) {
			Question = Question.Replace("<", "&lt;");
			Question = Question.Replace(">", "&gt;");
			Question = Regex.Replace(Question, @"[\n\r]+input[\n\r]+", "<br /><strong>Input</strong><br />", RegexOptions.IgnoreCase);
			Question = Regex.Replace(Question, @"[\n\r]+output[\n\r]+", "<br /><strong>Output</strong><br />", RegexOptions.IgnoreCase);
			Question = Regex.Replace(Question, @"[\n\r]+sample[\s+]input[\n\r]+", "<br /><strong>Sample Input</strong><br />", RegexOptions.IgnoreCase);
			Question = Regex.Replace(Question, @"[\n\r]+sample[\s+]output[\n\r]+", "<br /><strong>Sample Output</strong><br />", RegexOptions.IgnoreCase);
			Question = Question.Replace("\r\n", "<br/>");
			Question = Question.Replace("\r", "<br/>");
			Question = Question.Replace("\n", "<br/>");
			return Question;
		}

	}

}
