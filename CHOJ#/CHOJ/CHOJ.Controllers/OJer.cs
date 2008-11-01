using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
namespace CHOJ {
	public class OJer {
		#region init
		public string Username { get; set; }
		public string Code { get; set; }
		public Compiler Compiler { get; set; }
		public DataRow Question { get; set; }
		public Guid Guid { get; set; }
		public string  RootPath { get; set; }
		public string ExeFile { get; set; }
		public AnswerType AnswerType { get; set; }
		StringBuilder _log;
		public StringBuilder Log {
			get {
				if (_log == null) {
					_log = new StringBuilder();
				}
				return _log;
			}
		}
	//	DataBaseExecutor DB { get; set; }
		long UseTime { get; set; }
		long UseMemory { get; set; }
		public OJer(string Username, string Code, Guid Guid, long QuestionId,string SiteRoot) {
			DataBaseExecutor DB= new DataBaseExecutor(new OleDbDataOpener(ConfigurationManager.ConnectionStrings["AccessFileName"].ConnectionString));
			this.Guid = Guid.NewGuid();
			this.Username = Username;
			this.Code = Code;
			this.Compiler = ConfigSerializer.Load<List<Compiler>>("Compiler").Where(c => c.Guid == Guid).FirstOrDefault();
			this.Question = QuestionHelper.Question(DB, QuestionId);
			this.RootPath = SiteRoot;
			this.AnswerType = AnswerType.Queuing;
			this.ExeFile = RootPath + string.Format(@"temp\{0}.exe", Guid.ToString());
			DB.Dispose();
		}
		#endregion

		public void Start(Object stateInfo) {
			//检查
			if (CheckCode()) {
				//编译
				this.AnswerType = AnswerType.Compiling;
				if (CompileExecutable()) {
					//编译完成
					//测试
					this.AnswerType = AnswerType.Testing;
					Test();
				}
				else {
					this.AnswerType = AnswerType.CompileError;
				}
			}
			else {
				this.AnswerType = AnswerType.DangerCode;
			}
			DataBaseExecutor DB = new DataBaseExecutor(new OleDbDataOpener(ConfigurationManager.ConnectionStrings["AccessFileName"].ConnectionString));
			AnswerHelper.SaveAnswer(DB,
				this.Question.Field<int>("id"),
				this.Username,
				(int)this.AnswerType,
				this.Compiler.Name,
				this.UseTime,
				this.UseMemory,
				this.Guid
				);
			DB.Dispose();
			File.WriteAllText(RootPath + string.Format(@"SourceCode\{0}.sc", this.Guid.ToString())
				, this.Code);
			if (this.AnswerType == AnswerType.CompileError) {
				File.WriteAllText(RootPath + string.Format(@"CompilerInfo\{0}.txt", this.Guid.ToString()), this.Log.ToString());
			}
			File.Delete(this.ExeFile);
		}
		#region Test
		StringBuilder SystemOutString = new StringBuilder();
		StringBuilder CurrentOutString = new StringBuilder();
		void Test() {
			string TestFile = this.Question["Test"].ToString();
			String input;
			var p = new Process();
			p.StartInfo.FileName = this.ExeFile;
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.CreateNoWindow = true;
			p.StartInfo.RedirectStandardInput = true;
			p.StartInfo.RedirectStandardOutput = true;
			p.OutputDataReceived += new DataReceivedEventHandler(TestOutputHandler);
		//p.StartInfo.RedirectStandardError = true;
		p.Exited += new EventHandler(Process_Exited);
			
		//	p.StartInfo.ErrorDialog = false;
		//	p.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);
			p.Start();

			p.BeginOutputReadLine();

		//	long _myMemory = (p.PeakWorkingSet64 >> 10);//获取内存大小
			StreamWriter sortStreamWriter = p.StandardInput;//设置异步读取流
	//		StreamReader redirectreader = p.StandardOutput;
			try {
				using (StringReader sr = new StringReader(TestFile)) {
					while (((input = sr.ReadLine()) != null)) {
						if (input.StartsWith("EOF"))//C/C++程序的结束(CTRL+Z)方式
							p.CloseMainWindow();
						if (input.StartsWith(">")) {//测试的写操作
							sortStreamWriter.WriteLine(input.Substring(1));
						}
						if (input.StartsWith("<"))//测试的读操作
							SystemOutString.AppendLine(input.Substring(1));
					}
				}
			//	CurrentOutString.Append(redirectreader.);
				sortStreamWriter.Close();
		//		redirectreader.Close();
				
			 
				p.WaitForExit(2000);
				if (!p.HasExited)
					p.Kill();
				//	_TestEnd = true;
			}
			catch(Exception e) {
				string s1 = e.Message;
				//_TestEnd = true;
				if (!p.HasExited)
				p.Kill();
			}
			while (!p.HasExited) {
				Thread.Sleep(100);
			}
			p.Close();
			p.Dispose();
			return;
		}
		private void Process_Exited(object sender, EventArgs e) {//测试程序是否超时的判断
			var p = sender as Process;
			int outtime = 0;
			while (!OutputOver && CurrentOutString.Length == 0 && outtime < 100) {
				Thread.Sleep(10);
				outtime++;
			}
			//p.OutputDataReceived;
			bool f = (SystemOutString.ToString() == CurrentOutString.ToString());
			this.UseTime = Convert.ToInt64(p.TotalProcessorTime.TotalMilliseconds);
			this.UseMemory = p.PeakWorkingSet64 >> 10;
			long systemMemory = Convert.ToInt64(this.Question["MemoryLimit"]);
			long systemTime = Convert.ToInt64(this.Question["TimeLimit"]);
			switch (p.ExitCode) {
				case 0:
					if (this.UseMemory > systemMemory) {//内存消耗太大
						this.AnswerType = AnswerType.MemoryLimitExceed;
						break;
					}
					if (UseTime > systemTime) {
						if (SystemOutString.ToString().StartsWith(CurrentOutString.ToString()))
							this.AnswerType = AnswerType.TimeLimitExceed;
						else
							this.AnswerType = AnswerType.WrongAnswer;
						break;
					}
					if (f) this.AnswerType = AnswerType.Accepted;
					else
						this.AnswerType = AnswerType.WrongAnswer;
					break;
				case -1:
					if (UseTime > systemTime) {
						if (SystemOutString.ToString().StartsWith(CurrentOutString.ToString()))
							this.AnswerType = AnswerType.TimeLimitExceed;
						else
							this.AnswerType = AnswerType.WrongAnswer;
						break;
					}
					break;
				case -532459699:
				case -1073741676:
				case -1073741819:
				case -1073741571:
				default:
					this.AnswerType = AnswerType.RunningError;
					break;
			}
		}
		Boolean OutputOver=false;
		private void TestOutputHandler(object sender, DataReceivedEventArgs outLine) {
			if (!String.IsNullOrEmpty(outLine.Data)) {
				CurrentOutString.AppendLine(outLine.Data);
				if ((sender as Process).HasExited)
					OutputOver = true;
			}

		}
		private void ErrorHandler(object sender, DataReceivedEventArgs outLine) {

		}
		#endregion

		#region Compiler
		/// <summary>
		/// 编译
		/// </summary>
		/// <returns></returns>
		bool CompileExecutable() {
			
			CodeDomProvider provider = GetCurrentProvider();
			CompilerResults cr = CompileCode(provider);
			if (cr.Errors.Count > 0) {
				foreach (CompilerError ce in cr.Errors)
					this.Log.AppendLine(ce.ErrorText);
				return false;
			}
			return true;
		}
		/// <summary>
		/// 设置编译代码
		/// </summary>
		/// <param name="provider"></param>
		/// <param name="exeFile"></param>
		/// <returns></returns>
		CompilerResults CompileCode(CodeDomProvider provider) {
			String[] referenceAssemblies = { "System.dll" };
			CompilerParameters cp = new CompilerParameters(referenceAssemblies, this.ExeFile, false);
			cp.GenerateInMemory = true;
			// Generate an executable rather than a DLL file.
			cp.GenerateExecutable = true;
			//cp.CompilerOptions = "/debug:pdbonly";
			//cp.MainClass = "Class1";
			// Invoke compilation.
			return provider.CompileAssemblyFromSource(cp, this.Code);
		}

		/// <summary>
		/// CodeDomProvider Factory.
		/// </summary>
		/// <returns></returns>
		CodeDomProvider GetCurrentProvider() {
			return CodeDomProvider.CreateProvider(this.Compiler.Language);
			//switch () {
			//    case "CSharp":
			//        provider = CodeDomProvider.CreateProvider("CSharp");
			//        break;
			//    case "VisualBasic":
			//        provider = CodeDomProvider.CreateProvider("VisualBasic");
			//        break;
			//    case "JScript":
			//        provider = CodeDomProvider.CreateProvider("JScript");
			//        break;
			//    default:
					
			//        break;
			//}
		//	return provider;
		}
		#endregion
		#region check
		bool CheckCode() {
			Boolean result = true;
			foreach (string item in Compiler.DangerCode) {
				if (!string.IsNullOrEmpty(item.Trim()))
					if (Regex.IsMatch(Code, item, RegexOptions.IgnoreCase)) {
						result = false;
						break;
					}
			}
			return result;
		}
		#endregion
	}
}
