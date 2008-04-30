using System;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace ChswordOJ {
	/// <summary>
	/// DoFile 进行在线编译与测试
	/// Builder:邹健 2007 4 28
	/// V1.0 2007 6 12
	/// </summary>
	public class DoFile {
		StringBuilder _output = new StringBuilder();
		StringBuilder _TestOutput = new StringBuilder();
		StringBuilder _TestFile_Output = new StringBuilder();
		String _Test;
		String _CompilerName;
		StringBuilder _CompilerText = new StringBuilder();
		private Int64 _Memory, _myMemory;
		private Int32 _Time;//, _myTime;
		private Option.AnswerStatus _TestResult;
		private String _ExePath;
		private String _CodePath;
		private String _TextPath;
		private String _TestPath;
		private Int64 _AnswerId;
		private String _Sign;
		private Boolean _TestEnd;
		Process _process;
		/// <summary>
		/// 构造函数，对DoFile类进行初始化
		/// </summary>
		public DoFile() {
			_Memory = 23768;
			_Time = 3;
		}
		/// <summary>
		/// 进行编译及测试代码。
		/// </summary>
		/// <param name="code">要编译的代码。</param>
		/// <param name="UserName">编译的用户名。</param>
		/// <param name="PassWord">用户密码。</param>
		/// <param name="QNum">代码的问题ID。</param>
		/// <param name="CompilerName">编译器。</param>
		public void GetResult(String code, String UserName, String PassWord, String QNum, String CompilerName) {
			Option cp = new Option();
			DataSet ds = cp.GetLimit(QNum);
			User u = new User(UserName, CompilerName.Split(',')[0], CompilerName.Split(',')[1]);
			_Memory = int.Parse(ds.Tables[0].Rows[0][0].ToString());//从数据库读取当前的程序 要求的Memory
			_Time = int.Parse(ds.Tables[0].Rows[0][1].ToString());//从数据库读取当前的程序 要求的Time limit
			_Test = ds.Tables[0].Rows[0]["test"].ToString();//读取测试文件
			_CompilerName = CompilerName;//编译器名称
			_Sign = u.Sign;
			_CodePath = u.CodePath;//源代码文件保存的路径
			_TextPath = u.TextPath;//生成文本文件保存的路径
			_ExePath = u.ExePath;//EXE文件保存的路径
			_myMemory = 0;//对我当前耗费的内存进行初始化
			_TestPath = u.GetTestPath(QNum);//得到当前测试路径
			_AnswerId = cp.AddAnswer(UserName, Int64.Parse(QNum), CompilerName);//将当前数据作为一条回答存入数据库(创建一条数据库记录)
			Code cc = new Code(CompilerName, code);//创建Code实例
			if (cc.Check()) {//调用配置文件中的正则表达式,测试代码中有无危险代码,有,则此回答为危险代码

				SaveTextFile(u.CodePath, code);//将源代码保存为相应格式文件
				_CompilerText.AppendLine(u.CompilerString);//
				DoCmd(u.CompilerString);//用u生成编译字符串,执行编译操作
				IsTempExists(u.TextPath, u.CompilerString);//是否编译完成
				if (0 == _AnswerId)
					return;
				cp.SetAnswerStatus(_AnswerId, Option.AnswerStatus.Compiling);
				//编译完成
				if (IsCompilerSucess(u.TextPath, u.CodePath, u.ExePath, 0)) {//编译产生EXE则编译成功
					//编译成功
					cp.SetAnswerStatus(_AnswerId, Option.AnswerStatus.Running);
					ThreadStart thr_start_func = new ThreadStart(Test);//异步调用Test进行测试
					Thread fThread = new Thread(thr_start_func);
					fThread.Name = "Test";
					fThread.Start();
					Thread.Sleep(_Time * 2000);//初始化最大超时时间(规定时间的2倍)
					if (Option.AnswerStatus.Accepted == _TestResult) {
						//cp.SetAnswerStatus(_AnswerId, Compiler.AnswerStatus.测试通过);
					}
					else {
						if (_TestResult == 0) {
							try {
							//对进程查看是否结束,未结束则进行操作
								if (!_process.HasExited) {
									if (!_process.CloseMainWindow())
										_process.Kill();
									if (_TestFile_Output.ToString().StartsWith(_TestOutput.ToString()))
										_TestResult = Option.AnswerStatus.TimeLimitExceed;
									else
										_TestResult = Option.AnswerStatus.WrongAnswer;
								}
							}
							catch {
								_TestResult = Option.AnswerStatus.WrongAnswer;
							}

						}
						if (fThread.IsAlive) fThread.Abort();//最终的强制结束进程
					}
				}
				else {
					_TestResult = Option.AnswerStatus.CompileError;
					cp.SetAnswerText(_AnswerId, ReplaceFileName(_CompilerText.ToString()));
				}

				try {
					if (_TestResult == Option.AnswerStatus.Running || _TestResult == Option.AnswerStatus.WrongAnswer) {
						Process[] p = Process.GetProcessesByName(_Sign);
						if (p.Length > 0) {
							if (!p[0].HasExited) {
								if (p[0].Responding) {
									p[0].CloseMainWindow();
									p[0].Kill();
								}
								else {
									p[0].Kill();
								}
							}
							if (_TestFile_Output.ToString().StartsWith(_TestOutput.ToString()))
								_TestResult = Option.AnswerStatus.TimeLimitExceed;
							else
								_TestResult = Option.AnswerStatus.WrongAnswer;
						}
					}
				}
				catch { }
			}
			else {
				_TestResult = Option.AnswerStatus.DangerCode;
			}

			cp.SetAnswerStatus(_AnswerId, _TestResult);//写入测试结果
			cp.SaveAnswerCode(_AnswerId, code);//写入提交的源代码
			/*try {
				if (_TestResult == Option.AnswerStatus.测试通过) {
					using (StreamReader sr = File.OpenText(_CodePath)) {
						cp.SaveAnswerCode(_AnswerId, sr.ReadToEnd());
					}
				}
			}
			catch { }*/
			DeleteTempFile();//删除临时文件
		}

		private void DeleteTempFile() {//删除临时文件
			Byte b = 0;
			try {
				Thread.Sleep(1000);//每一秒试删除一次
				if (File.Exists(_ExePath)) File.Delete(_ExePath); else b++;
				if (File.Exists(_CodePath)) File.Delete(_CodePath); else b++;
				if (File.Exists(_TextPath)) File.Delete(_TextPath); else b++;
			}
			catch { }
			if (b != 3) DeleteTempFile();//递归调用
			return;
		}
		private bool IsCompilerSucess(string TextPath, string CppPath, String ExePath, int count) {
			try {//看是否编译成功的函数
				using (StreamReader sr = new StreamReader(TextPath, Encoding.Default)) {
					String input;
					bool f = true;
					while ((input = sr.ReadLine()) != null) {
						_CompilerText.AppendLine(input);
						if (input.Contains(": error:")) {

							_output.AppendLine(input);
						}
						else {
							if (f && !input.StartsWith(CppPath))
								_output.AppendLine(input);
							f = false;
						}
					}
					sr.Close();
					if (File.Exists(ExePath)) {
						return true;
					}
					else {
						_output.Insert(0, "编译出错:\r\n");
						return false;
					}
				}
			}
			catch {
			}
			Thread.Sleep(1000);
			if (count >= 300) {
				_CompilerText.Insert(0, "服务器响应超时或您选择的编译器不正确");
				return false;
			}
			return IsCompilerSucess(TextPath, CppPath, ExePath, count + 1);
		}
		private string ReplaceFileName(string input) {
			input = System.Text.RegularExpressions.Regex.Replace(input, @"([A-Z]:[\\|\/][^:\*\?<>\|]+\.(txt|cs|cpp|c|vb|jsl|js|exe))|(\\{2}[^/:\*\?<>\|]+\.(txt|cs|cpp|c|vb|jsl|js|exe))", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			return input;
		}
		private void Process_Exited(object sender, EventArgs e) {//测试程序是否超时的判断
			if (_process.TotalProcessorTime.Milliseconds > _Time*1000) {
				if (_TestFile_Output.ToString().StartsWith(_TestOutput.ToString()))
					_TestResult = Option.AnswerStatus.TimeLimitExceed;
				else
					_TestResult = Option.AnswerStatus.WrongAnswer;
			}
		}
		private void Test() {//进行测试
			string ExePath = _ExePath;
			string TestPath = _TestPath;
			String input;
			bool f = true;
			_TestEnd = false;
			_process = new Process();
			_process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			_process.StartInfo.UseShellExecute = false;
			_process.StartInfo.CreateNoWindow = true;
			_process.StartInfo.RedirectStandardInput = true;
			_process.StartInfo.RedirectStandardOutput = true;
			_process.StartInfo.RedirectStandardError = true;
			_process.StartInfo.FileName = ExePath;
			_process.Exited += new EventHandler(Process_Exited);
			_process.OutputDataReceived += new DataReceivedEventHandler(TestOutputHandler);
			_process.Start();
			_process.BeginOutputReadLine();
			_myMemory = (_process.PeakWorkingSet64 >> 10);//获取内存大小
			StreamWriter sortStreamWriter = _process.StandardInput;//设置异步读取流
			try {
				using (StringReader sr = new StringReader(_Test)) {
					while (((input = sr.ReadLine()) != null)) {
						if (input.StartsWith("EOF"))//C/C++程序的结束(CTRL+Z)方式
							if (_CompilerName.ToLower() == "c" || _CompilerName.ToLower() == "cpp")
								sortStreamWriter.WriteLine(((char)26).ToString());
							else//.net程序的结束(CTRL+Z)方式
								_process.CloseMainWindow();
						if (input.StartsWith(">"))//测试的写操作
							sortStreamWriter.WriteLine(input.Substring(1));
						if (input.StartsWith("<"))//测试的读操作
							_TestFile_Output.AppendLine(input.Substring(1));
					}
				}
				sortStreamWriter.Close();
				_process.WaitForExit();
				_TestEnd = true;
			}
			catch {
				_TestEnd = true;
			}

			if (_TestOutput.ToString() == _TestFile_Output.ToString())
				f = true;
			else
				f = false;
			if (_TestEnd && f)
				_TestResult = Option.AnswerStatus.Accepted;
			else {

			}
			if (_TestEnd && (_myMemory > _Memory))//内存消耗太大
			{
				_TestResult = Option.AnswerStatus.MemoryLimitExceed;
			}
			_process.Close();
			_process.Dispose();
			if (f && _TestEnd) {
				_TestResult = Option.AnswerStatus.Accepted;
			}
			return;

		}
		void SaveTextFile(string Path, string text) {
			using (StreamWriter sw = new StreamWriter(Path)) { sw.Write(text); }
		}
		void DoCmd(string cmd) {//执行一条CMD命令的函数
			Process process = new Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.FileName = "cmd.exe";
			process.Start();
			process.StandardInput.WriteLine(cmd);
			process.StandardInput.WriteLine("\r\nexit");
			process.Close();
			process.Dispose();
		}
		bool IsTempExists(String TextPath, String CompilerString) {
			int i = 0;
			while (!File.Exists(TextPath)) {
				Thread.Sleep(1000);
				i++;
				if (i > 178) return false;
				if (i % 30 == 0 && i > 10) {
					DoCmd(CompilerString);
				}
			}
			return true;
		}
		private void TestOutputHandler(object sendingProcess,
			DataReceivedEventArgs outLine) {
			int numOutputLines = 0;
			if (!String.IsNullOrEmpty(outLine.Data)) {
				numOutputLines++;
				//Environment.NewLine +"[" + numOutputLines.ToString() + "] - " + 
				_TestOutput.AppendLine(outLine.Data);
			}
		}
	}

}
