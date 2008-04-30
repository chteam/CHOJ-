using System;
using System.Configuration;

namespace ChswordOJ {
	/// <summary>
	/// User 的摘要说明
	/// </summary>
 public class User {
		private string _username;
		private string _sign;
		private string _path;
		private String _dotnetV;
		private String _Compiler;
		public User(String value, String CompilerName, String dotnetV) {
			_Compiler = CompilerName;
			_dotnetV = dotnetV;
			_username = "temp";
			_sign = DateTime.Now.ToString().Replace(":", "").Replace(" ", "");
			_path = string.Format("{0}userfile\\{1}\\", ConfigurationManager.AppSettings["Path"], _username);
		}
		public string GetCompilerName() {
			return _Compiler;
		}
		public string GetCompiler() {
			switch (_Compiler.ToLower()) {
				case "cpp":
					return ConfigurationManager.AppSettings["DevCppPath"] + "g++.exe";
				case "c":
					return ConfigurationManager.AppSettings["DevCppPath"] + "gcc.exe";
				default:
					return "";
			}
		}
		private String GetPath(String KzName) {
			return String.Format("{0}{1}.{2}", _path, _sign, KzName);
		}
		public string GetTestPath(string Num) {
			return ConfigurationManager.AppSettings["Path"] + @"\Test\" + Num + @".txt";
		}
		public virtual string Sign {
			get {
				if (null == _sign) {
					return string.Empty;
				}
				return _sign;
			}
		}
		public virtual string TextPath {
			get { return GetPath("txt"); }
		}
		public virtual string ExePath {
			get { return GetPath("exe"); }
		}
		public virtual string CodePath {
			get {
				return GetPath(_Compiler);
			}
		}
		private String GetDotNetCompiler(String type) {
			string str;
			if (_dotnetV == "1")
				str = ConfigurationManager.AppSettings["DotNet1Path"];
			else if (_dotnetV == "2")
				str = ConfigurationManager.AppSettings["DotNet2Path"];
			else
				return "";
			return String.Format("{0}{4} /out:{1} {2} >{3}"
				, str
				, ExePath
				, CodePath
				, TextPath
				, type
				);
		}
		public virtual string CompilerString {
			get {
				switch (_Compiler.ToLower()) {
					case "c":
					case "cpp":
						return string.Format("{0} {1} 2>{2} -o {3}"
						, GetCompiler()
						, CodePath
						, TextPath
						, ExePath);
					case "cs":
						return GetDotNetCompiler("csc");
					case "vb":
						return GetDotNetCompiler("vbc");
					case "jsl":
						return GetDotNetCompiler("vjc");
					case "js":
						return GetDotNetCompiler("jsc");
					default:
						return "";
				}
			}
		}
	}

}
