using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
	//	public Compiler Compiler { get; set; }
		//public DataRow Question { get; set; }
	//	public Guid Guid { get; set; }
		public string  RootPath { get; set; }
		public string ExeFile { get; set; }
		//public AnswerType AnswerType { get; set; }
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
        public OJer(string username, string code, string siteRoot)
        {
        
            Username = username;
            Code = code;
            //Compiler = ConfigSerializer.Load<List<Compiler>>("Compiler").Where(c => c.Guid == guid).FirstOrDefault();
       //     Question = QuestionHelper.Question(db, questionId);
            RootPath = siteRoot;
         //   AnswerType = AnswerType.Queuing;
            ExeFile = RootPath + string.Format(@"temp\{0}.exe", "a");
      //      db.Dispose();
        }

	    #endregion

        public void Start(Object stateInfo)
        {
            //检查
            CompileExecutable();
            //编译完成
            //测试
            Test();
        }

	    #region Test

	    readonly StringBuilder _systemOutString = new StringBuilder();
	    readonly StringBuilder _currentOutString = new StringBuilder();
		void Test() {
            var testFile = ">1\n\r<1\n\rEOF";
			String input;
			var p = new Process
			            {
			                StartInfo =
			                    {
			                        FileName = ExeFile,
			                        WindowStyle = ProcessWindowStyle.Hidden,
			                        UseShellExecute = false,
			                        CreateNoWindow = true,
			                        RedirectStandardInput = true,
			                        RedirectStandardOutput = true
			                    }
			            };
		    p.OutputDataReceived += TestOutputHandler;
		//p.StartInfo.RedirectStandardError = true;
		p.Exited += ProcessExited;

		//	p.StartInfo.ErrorDialog = false;
			p.ErrorDataReceived += ErrorHandler;
			p.Start();

			p.BeginOutputReadLine();

		//	long _myMemory = (p.PeakWorkingSet64 >> 10);//获取内存大小
			StreamWriter sortStreamWriter = p.StandardInput;//设置异步读取流
	//		StreamReader redirectreader = p.StandardOutput;
			try {
				using (var sr = new StringReader(testFile)) {
					while (((input = sr.ReadLine()) != null)) {
						if (input.StartsWith("EOF"))//C/C++程序的结束(CTRL+Z)方式
							p.CloseMainWindow();
						if (input.StartsWith(">")) {//测试的写操作
							sortStreamWriter.WriteLine(input.Substring(1));
						}
						if (input.StartsWith("<"))//测试的读操作
							_systemOutString.AppendLine(input.Substring(1));
					}
				}
			//	_currentOutString.Append(redirectreader.);
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
		private void ProcessExited(object sender, EventArgs e) {//测试程序是否超时的判断
			var p = sender as Process;
			var outtime = 0;
			while (!OutputOver && _currentOutString.Length == 0 && outtime < 100) {
				Thread.Sleep(10);
				outtime++;
			}
			//p.OutputDataReceived;
			var f = (_systemOutString.ToString() == _currentOutString.ToString());
			UseTime = Convert.ToInt64(p.TotalProcessorTime.TotalMilliseconds);
			UseMemory = p.PeakWorkingSet64 >> 10;
			var systemMemory =10000;
			var systemTime =10000;
			switch (p.ExitCode) {
				case 0:
					if (UseMemory > systemMemory) {//内存消耗太大
						//AnswerType = AnswerType.MemoryLimitExceed;
						break;
					}
					if (UseTime > systemTime)
					{
                        File.WriteAllText(RootPath + "log.txt", "timeout"); // AnswerType = _systemOutString.ToString().StartsWith(_currentOutString.ToString()) ? AnswerType.TimeLimitExceed : AnswerType.WrongAnswer;
					    break;
					}
                    File.WriteAllText(RootPath + "log.txt", "AnswerType.WrongAnswer : AnswerType.Accepted;");
			        //AnswerType = !f ? AnswerType.WrongAnswer : AnswerType.Accepted;
			        break;
				case -1:
					if (UseTime > systemTime)
                    {
                        File.WriteAllText(RootPath + "log.txt", "timeout"); 
					  //  AnswerType = _systemOutString.ToString().StartsWith(_currentOutString.ToString()) ? AnswerType.TimeLimitExceed : AnswerType.WrongAnswer;
					    break;
					}
			        break;
				case -532459699://权限不足或使用不允许代码
				case -1073741676:
				case -1073741819:
				case -1073741571:
				default:
			File.WriteAllText(RootPath+"log.txt","runtime error");
					break;
			}
		}
		Boolean OutputOver;
		private void TestOutputHandler(object sender, DataReceivedEventArgs outLine) {
		    if (String.IsNullOrEmpty(outLine.Data)) return;
		    _currentOutString.AppendLine(outLine.Data);
		    if (((Process) sender).HasExited)
		        OutputOver = true;
		}
		private void ErrorHandler(object sender, DataReceivedEventArgs outLine) {
//            out
		    var x=outLine.Data;
		}
		#endregion

		#region Compiler
		/// <summary>
		/// 编译
		/// </summary>
		/// <returns></returns>
		bool CompileExecutable() {
			
			var provider = GetCurrentProvider();
			var cr = CompileCode(provider);
			if (cr.Errors.Count > 0) {
				foreach (CompilerError ce in cr.Errors)
					Log.AppendLine(ce.ErrorText);
				return false;
			}
			return true;
		}
		/// <summary>
		/// 设置编译代码
		/// </summary>
		/// <param name="provider"></param>

		/// <returns></returns>
		CompilerResults CompileCode(CodeDomProvider provider) {
			String[] referenceAssemblies = { "System.dll" };
			var cp = new CompilerParameters(referenceAssemblies, ExeFile, false)
			             {
			                 GenerateInMemory = true,
			                 GenerateExecutable = true
			             };

		    var a=File.ReadAllText(RootPath + "a.txt");
		    return provider.CompileAssemblyFromSource(cp, a);
		}

		/// <summary>
		/// CodeDomProvider Factory.
		/// </summary>
		/// <returns></returns>
		CodeDomProvider GetCurrentProvider() {
			return CodeDomProvider.CreateProvider("CSharp");
		}
		#endregion
		#region check

		#endregion
	}
}
