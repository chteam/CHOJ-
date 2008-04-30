using System;
using System.Text.RegularExpressions;
using System.Reflection;
namespace ChswordOJ {
	/// <summary>
	/// ChString 是对于内部字符串进行处理的类，本类是一个静态类。
	/// </summary>
	public static class ChString {
		/// <summary>
		/// 已知分子和分母的情况下，返回百分比。
		/// </summary>
		/// <param name="fz">分子</param>
		/// <param name="fm">分母</param>
		/// <returns>分子与分母相除的百分比。</returns>
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
		/// 已重构，得到当前代码状态的文字性表述。
		/// </summary>
		/// <param name="i">代码状态代码。</param>
		/// <param name="AnswerId">那个提交的代码的AnswerId</param>
		/// <returns>返回一个字符串，表示用户提交代码的状态，支持HTML</returns>
		public static String GetStatus(String i, Int64 AnswerId) {
			return GetStatus(i, AnswerId, false);
		}
		/// <summary>
		/// 已重构，得到当前代码状态的文字性表述。
		/// </summary>
		/// <param name="i">代码状态代码。</param>
		/// <param name="AnswerId">那个提交的代码的AnswerId</param>
		/// <param name="IsAdmin">是否为后台用户，如果是，则可以查看源代码</param>
		/// <returns>返回一个字符串，表示用户提交代码的状态，支持HTML</returns>
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
		/// 得到编译器的名称
		/// </summary>
		/// <param name="s">编译器的代号。</param>
		/// <returns>返回编译器的全称</returns>
		public static String GetCompiler(String s) {
			String temp = s.ToLower();
			return Xml.GetItemName("Compiler", temp);
		}
		/// <summary>
		/// 对Question进行格式化。
		/// </summary>
		/// <param name="Question">Question，为一个字符串。</param>
		/// <returns>格式化后的Question。</returns>
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
