using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace ChswordOJ {
	/// <summary>
	/// Code 
	/// 是进行CODE验证的一个类以确保CODE中没有高危代码
	/// </summary>
 class Code {
		String _fn;
		String _code;
		/// <summary>
		/// 构造函数。
		/// </summary>
		/// <param name="fn">测试文件类型。</param>
		/// <param name="code">代码。</param>
		public Code(String fn,string code) {
			_fn = fn;
			_code=code;
		}
		/// <summary>
		/// 检测源代码
		/// </summary>
		/// <returns>如非法则返回False，合法返回True</returns>
		public Boolean Check() {
			User u =new User ("","","");
			List<string> list=new List<string>();
			string input;
			Boolean result=true;
			using (StreamReader sr = new StreamReader(u.GetTestPath(_fn))) {
				while (!sr.EndOfStream) {
					input = sr.ReadLine();
				if (String.IsNullOrEmpty(input.Trim()))
					break;
					list.Add(input);
				}
			}
			foreach (string item in list) { 
				if(!string.IsNullOrEmpty(item.Trim()))
					if (IsMatch(_code , item)) {
						result = false;
						break;
					}
			}
			return result;
		}
		/// <summary>
		/// 判断字符串是否符合正则规则。
		/// </summary>
		/// <param name="str">要检测的字符串。</param>
		/// <param name="Reg">正则规范。</param>
		/// <returns>[b]Boolean[/b] 符合正则规则则返回True</returns>
		Boolean IsMatch(String str, String Reg) {
			Regex Regex = new Regex(Reg, RegexOptions.IgnoreCase);
			return Regex.Match(str).Success;
		}
	}
}
