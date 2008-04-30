using System;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace ChswordOJ {
	/// <summary>
	/// DoFile �������߱��������
	/// Builder:�޽� 2007 4 28
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
		/// ���캯������DoFile����г�ʼ��
		/// </summary>
		public DoFile() {
			_Memory = 23768;
			_Time = 3;
		}
		/// <summary>
		/// ���б��뼰���Դ��롣
		/// </summary>
		/// <param name="code">Ҫ����Ĵ��롣</param>
		/// <param name="UserName">������û�����</param>
		/// <param name="PassWord">�û����롣</param>
		/// <param name="QNum">���������ID��</param>
		/// <param name="CompilerName">��������</param>
		public void GetResult(String code, String UserName, String PassWord, String QNum, String CompilerName) {
			Option cp = new Option();
			DataSet ds = cp.GetLimit(QNum);
			User u = new User(UserName, CompilerName.Split(',')[0], CompilerName.Split(',')[1]);
			_Memory = int.Parse(ds.Tables[0].Rows[0][0].ToString());//�����ݿ��ȡ��ǰ�ĳ��� Ҫ���Memory
			_Time = int.Parse(ds.Tables[0].Rows[0][1].ToString());//�����ݿ��ȡ��ǰ�ĳ��� Ҫ���Time limit
			_Test = ds.Tables[0].Rows[0]["test"].ToString();//��ȡ�����ļ�
			_CompilerName = CompilerName;//����������
			_Sign = u.Sign;
			_CodePath = u.CodePath;//Դ�����ļ������·��
			_TextPath = u.TextPath;//�����ı��ļ������·��
			_ExePath = u.ExePath;//EXE�ļ������·��
			_myMemory = 0;//���ҵ�ǰ�ķѵ��ڴ���г�ʼ��
			_TestPath = u.GetTestPath(QNum);//�õ���ǰ����·��
			_AnswerId = cp.AddAnswer(UserName, Int64.Parse(QNum), CompilerName);//����ǰ������Ϊһ���ش�������ݿ�(����һ�����ݿ��¼)
			Code cc = new Code(CompilerName, code);//����Codeʵ��
			if (cc.Check()) {//���������ļ��е�������ʽ,���Դ���������Σ�մ���,��,��˻ش�ΪΣ�մ���

				SaveTextFile(u.CodePath, code);//��Դ���뱣��Ϊ��Ӧ��ʽ�ļ�
				_CompilerText.AppendLine(u.CompilerString);//
				DoCmd(u.CompilerString);//��u���ɱ����ַ���,ִ�б������
				IsTempExists(u.TextPath, u.CompilerString);//�Ƿ�������
				if (0 == _AnswerId)
					return;
				cp.SetAnswerStatus(_AnswerId, Option.AnswerStatus.Compiling);
				//�������
				if (IsCompilerSucess(u.TextPath, u.CodePath, u.ExePath, 0)) {//�������EXE�����ɹ�
					//����ɹ�
					cp.SetAnswerStatus(_AnswerId, Option.AnswerStatus.Running);
					ThreadStart thr_start_func = new ThreadStart(Test);//�첽����Test���в���
					Thread fThread = new Thread(thr_start_func);
					fThread.Name = "Test";
					fThread.Start();
					Thread.Sleep(_Time * 2000);//��ʼ�����ʱʱ��(�涨ʱ���2��)
					if (Option.AnswerStatus.Accepted == _TestResult) {
						//cp.SetAnswerStatus(_AnswerId, Compiler.AnswerStatus.����ͨ��);
					}
					else {
						if (_TestResult == 0) {
							try {
							//�Խ��̲鿴�Ƿ����,δ��������в���
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
						if (fThread.IsAlive) fThread.Abort();//���յ�ǿ�ƽ�������
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

			cp.SetAnswerStatus(_AnswerId, _TestResult);//д����Խ��
			cp.SaveAnswerCode(_AnswerId, code);//д���ύ��Դ����
			/*try {
				if (_TestResult == Option.AnswerStatus.����ͨ��) {
					using (StreamReader sr = File.OpenText(_CodePath)) {
						cp.SaveAnswerCode(_AnswerId, sr.ReadToEnd());
					}
				}
			}
			catch { }*/
			DeleteTempFile();//ɾ����ʱ�ļ�
		}

		private void DeleteTempFile() {//ɾ����ʱ�ļ�
			Byte b = 0;
			try {
				Thread.Sleep(1000);//ÿһ����ɾ��һ��
				if (File.Exists(_ExePath)) File.Delete(_ExePath); else b++;
				if (File.Exists(_CodePath)) File.Delete(_CodePath); else b++;
				if (File.Exists(_TextPath)) File.Delete(_TextPath); else b++;
			}
			catch { }
			if (b != 3) DeleteTempFile();//�ݹ����
			return;
		}
		private bool IsCompilerSucess(string TextPath, string CppPath, String ExePath, int count) {
			try {//���Ƿ����ɹ��ĺ���
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
						_output.Insert(0, "�������:\r\n");
						return false;
					}
				}
			}
			catch {
			}
			Thread.Sleep(1000);
			if (count >= 300) {
				_CompilerText.Insert(0, "��������Ӧ��ʱ����ѡ��ı���������ȷ");
				return false;
			}
			return IsCompilerSucess(TextPath, CppPath, ExePath, count + 1);
		}
		private string ReplaceFileName(string input) {
			input = System.Text.RegularExpressions.Regex.Replace(input, @"([A-Z]:[\\|\/][^:\*\?<>\|]+\.(txt|cs|cpp|c|vb|jsl|js|exe))|(\\{2}[^/:\*\?<>\|]+\.(txt|cs|cpp|c|vb|jsl|js|exe))", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			return input;
		}
		private void Process_Exited(object sender, EventArgs e) {//���Գ����Ƿ�ʱ���ж�
			if (_process.TotalProcessorTime.Milliseconds > _Time*1000) {
				if (_TestFile_Output.ToString().StartsWith(_TestOutput.ToString()))
					_TestResult = Option.AnswerStatus.TimeLimitExceed;
				else
					_TestResult = Option.AnswerStatus.WrongAnswer;
			}
		}
		private void Test() {//���в���
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
			_myMemory = (_process.PeakWorkingSet64 >> 10);//��ȡ�ڴ��С
			StreamWriter sortStreamWriter = _process.StandardInput;//�����첽��ȡ��
			try {
				using (StringReader sr = new StringReader(_Test)) {
					while (((input = sr.ReadLine()) != null)) {
						if (input.StartsWith("EOF"))//C/C++����Ľ���(CTRL+Z)��ʽ
							if (_CompilerName.ToLower() == "c" || _CompilerName.ToLower() == "cpp")
								sortStreamWriter.WriteLine(((char)26).ToString());
							else//.net����Ľ���(CTRL+Z)��ʽ
								_process.CloseMainWindow();
						if (input.StartsWith(">"))//���Ե�д����
							sortStreamWriter.WriteLine(input.Substring(1));
						if (input.StartsWith("<"))//���ԵĶ�����
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
			if (_TestEnd && (_myMemory > _Memory))//�ڴ�����̫��
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
		void DoCmd(string cmd) {//ִ��һ��CMD����ĺ���
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
