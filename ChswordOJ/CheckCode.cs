using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace ChswordOJ {
	/// <summary>
	/// Code 
	/// �ǽ���CODE��֤��һ������ȷ��CODE��û�и�Σ����
	/// </summary>
 class Code {
		String _fn;
		String _code;
		/// <summary>
		/// ���캯����
		/// </summary>
		/// <param name="fn">�����ļ����͡�</param>
		/// <param name="code">���롣</param>
		public Code(String fn,string code) {
			_fn = fn;
			_code=code;
		}
		/// <summary>
		/// ���Դ����
		/// </summary>
		/// <returns>��Ƿ��򷵻�False���Ϸ�����True</returns>
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
		/// �ж��ַ����Ƿ�����������
		/// </summary>
		/// <param name="str">Ҫ�����ַ�����</param>
		/// <param name="Reg">����淶��</param>
		/// <returns>[b]Boolean[/b] ������������򷵻�True</returns>
		Boolean IsMatch(String str, String Reg) {
			Regex Regex = new Regex(Reg, RegexOptions.IgnoreCase);
			return Regex.Match(str).Success;
		}
	}
}
