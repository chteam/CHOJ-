using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ChswordOJ {
	/// <summary>
	/// Compiler �ǽ��б����������ݿ��������
	/// �޽� 2007-05-04
	/// </summary>
	public class Option {
		/// <summary>
		/// �ύ��״̬��
		/// </summary>
		public enum AnswerStatus {
			/// <summary>
			/// �Ŷ��С�
			/// </summary>
			Queuing = 0,
			/// <summary>
			/// ���ύ��
			/// </summary>
			Uploading = 10,
			/// <summary>
			/// ���ڱ��롣
			/// </summary>
			Compiling = 20,
			/// <summary>
			/// �����С�
			/// </summary>
			Running = 30,
			/// <summary>
			/// ��ʱ��
			/// </summary>
			TimeLimitExceed = 40,
			/// <summary>
			/// ����ʧ�ܡ�
			/// </summary>
			WrongAnswer = 50,
			/// <summary>
			/// �ڴ泬�����ơ�
			/// </summary>
			MemoryLimitExceed = 60,
			/// <summary>
			/// ����ʧ�ܡ�
			/// </summary>
			CompileError = 70,
			/// <summary>
			/// Σ�մ��롣
			/// </summary>
			DangerCode = 80,
			/// <summary>
			/// ����ͨ����
			/// </summary>
			Accepted = 99,
		}
		/// <summary>
		/// ���캯��
		/// </summary>
		public Option() { }
		//�������ͷ���
		DataSet SelectBy1id(String Str,Int64 Num,String pname) {
			Dictionary p = new Dictionary();
			p.Add(Str, Num);

			IDataBase dd = new AccessDataBase();
			return dd.DoDataTable(pname, p).DataSet;
		}
		//�������Է���
		/// <summary>
		/// �õ����ơ�
		/// </summary>
		/// <param name="Num">�����id��</param>
		/// <returns></returns>
		public DataSet GetLimit(String Num) {
			return SelectBy1id("@id",Int64.Parse(Num),@"SELECT MemoryLimit, TimeLimit,test
FROM Question
WHERE (id = @id)");
		}
		/// <summary>
		/// �õ�����ʧ�ܻش����Ϣ��
		/// </summary>
		/// <param name="Answerid">�ش�id�š�</param>
		/// <returns>������Ϣ��</returns>
		public DataSet GetAnswerError(String Answerid) {
			Dictionary p = new Dictionary();
			p.Add("@answerid", Int64.Parse(Answerid));
			IDataBase dd = new AccessDataBase();
			return dd.DoDataTable("QuestionSelect", p).DataSet;


			return SelectBy1id("@answerid", Int64.Parse(Answerid), @"
SELECT [Complier], [Questionid], [username], [Addtime] 
FROM [Answer]
WHERE (([id] = @Answerid) AND ([status] = 70))");
		}
		/// <summary>
		/// �õ����⡣
		/// </summary>
		/// <param name="Num">����id��</param>
		/// <returns>�����dataset��</returns>
		public DataSet GetQuestion(String Num) {
			Dictionary p = new Dictionary();
			p.Add("@id", Num);
			IDataBase dd = new AccessDataBase();

			return dd.DoDataTable(@"SELECT Addtime, username, AcceptedCount,Test,
 SubmitCount, MemoryLimit, TimeLimit, Body, 
      title,groupid
FROM Question
WHERE (id = @id)", p).DataSet;
		}
		/// <summary>
		/// ���ûش�״̬��
		/// </summary>
		/// <param name="Answerid">�ش�id��</param>
		/// <param name="Status">�ش�״̬��</param>
		public void SetAnswerStatus(Int64 Answerid, AnswerStatus Status) {
			Dictionary p = new Dictionary();
			p.Add("@id", Answerid);
			p.Add("@status", Status);
			IDataBase dd = new AccessDataBase();
			dd.DoParameterSql("AnswerUpdate", p);
		}
		/// <summary>
		/// ����ش�ı�����Ϣ��
		/// </summary>
		/// <param name="Answerid">�ش�id��</param>
		/// <param name="Text">������Ϣ��</param>
		public void SetAnswerText(Int64 Answerid, String Text) {
			Dictionary p = new Dictionary();
			p.Add("@id", Answerid);
			p.Add("@Text", Text);
			IDataBase dd = new AccessDataBase();
			dd.DoParameterSql(@"UPDATE Answer
SET Complier = @text
WHERE (id = @id)", p);
		}
		/// <summary>
		/// ����ش�Ĵ��롣
		/// </summary>
		/// <param name="Answerid">�ش�id��</param>
		/// <param name="Text">�û��ύ�Ĵ��롣</param>
		public void SaveAnswerCode(Int64 Answerid, String Text) {
			IDataBase dd = new AccessDataBase();
			Dictionary p = new Dictionary();
			p.Add("@id", Answerid);
			p.Add("@Text", Text);
			dd.DoParameterSql(@"UPDATE Answer
SET Code = @text
WHERE (id = @id)", p);
		}
		/// <summary>
		/// �û����ύһ���ش�
		/// </summary>
		/// <param name="UserName">�û�����</param>
		/// <param name="QuestionId">����id</param>
		/// <param name="exe">���ñ��������š�</param>
		/// <returns>�´����Ļش��id��</returns>
		public Int64 AddAnswer(String UserName, Int64 QuestionId, string exe) {
			IDataBase dd = new AccessDataBase();
			Dictionary p = new Dictionary();
			p.Add("@username", UserName);
			p.Add("@questionid", QuestionId);
			p.Add("@exe",  exe);
			dd.DoParameterSql(@"	UPDATE    Question
	SET       SubmitCount = SubmitCount + 1
	WHERE     (id = @QUESTIONID) and  not exists(SELECT     id
FROM         Answer
WHERE		(Questionid = @Questionid)
			AND (username = @username)
			AND (status = 99)
			)", p);
			dd.DoParameterSql(@"UPDATE    [User]
	SET       Submit = Submit + 1
	WHERE     (username = @username) and  not exists(SELECT     id
FROM         Answer
WHERE		(Questionid = @Questionid)
			AND (username = @username)
			AND (status = 99)
			)",new Dictionary());
			dd.DoParameterSql(@"INSERT INTO Answer
		  (Questionid, username, status,exe)
	VALUES (@Questionid, @username, 0,@exe)", new Dictionary());
			return Int64.Parse(dd.DoParameterSql("@@IDENTITY", new Dictionary()));
		}
		/// <summary>
		/// ���Ƽ�ʹ�÷�����ע���û�ʱʹ�á�
		/// </summary>
		/// <param name="username">�û�����</param>
		public void SetUser(string username) {
			IDataBase dd = new AccessDataBase();
			Dictionary p = new Dictionary();
			p.Add("@username", username);
			dd.DoParameterSql(@"INSERT INTO [User]
                      (username, [name], sex, Birthday, Grade, School)
VALUES     (@username,'',1,1985-02-17,2004,'jms')", p);
		}

	}

}
