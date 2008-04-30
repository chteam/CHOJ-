using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ChswordOJ {
	/// <summary>
	/// Compiler 是进行编译器对数据库操作的类
	/// 邹健 2007-05-04
	/// </summary>
	public class Option {
		/// <summary>
		/// 提交答案状态。
		/// </summary>
		public enum AnswerStatus {
			/// <summary>
			/// 排队中。
			/// </summary>
			Queuing = 0,
			/// <summary>
			/// 已提交。
			/// </summary>
			Uploading = 10,
			/// <summary>
			/// 正在编译。
			/// </summary>
			Compiling = 20,
			/// <summary>
			/// 测试中。
			/// </summary>
			Running = 30,
			/// <summary>
			/// 超时。
			/// </summary>
			TimeLimitExceed = 40,
			/// <summary>
			/// 测试失败。
			/// </summary>
			WrongAnswer = 50,
			/// <summary>
			/// 内存超出限制。
			/// </summary>
			MemoryLimitExceed = 60,
			/// <summary>
			/// 编译失败。
			/// </summary>
			CompileError = 70,
			/// <summary>
			/// 危险代码。
			/// </summary>
			DangerCode = 80,
			/// <summary>
			/// 测试通过。
			/// </summary>
			Accepted = 99,
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		public Option() { }
		//物理隐型方法
		DataSet SelectBy1id(String Str,Int64 Num,String pname) {
			Dictionary p = new Dictionary();
			p.Add(Str, Num);

			IDataBase dd = new AccessDataBase();
			return dd.DoDataTable(pname, p).DataSet;
		}
		//表义显性方法
		/// <summary>
		/// 得到限制。
		/// </summary>
		/// <param name="Num">问题的id。</param>
		/// <returns></returns>
		public DataSet GetLimit(String Num) {
			return SelectBy1id("@id",Int64.Parse(Num),@"SELECT MemoryLimit, TimeLimit,test
FROM Question
WHERE (id = @id)");
		}
		/// <summary>
		/// 得到编译失败回答的信息。
		/// </summary>
		/// <param name="Answerid">回答id号。</param>
		/// <returns>编译信息。</returns>
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
		/// 得到问题。
		/// </summary>
		/// <param name="Num">问题id。</param>
		/// <returns>问题的dataset。</returns>
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
		/// 设置回答状态。
		/// </summary>
		/// <param name="Answerid">回答id。</param>
		/// <param name="Status">回答状态。</param>
		public void SetAnswerStatus(Int64 Answerid, AnswerStatus Status) {
			Dictionary p = new Dictionary();
			p.Add("@id", Answerid);
			p.Add("@status", Status);
			IDataBase dd = new AccessDataBase();
			dd.DoParameterSql("AnswerUpdate", p);
		}
		/// <summary>
		/// 保存回答的编译信息。
		/// </summary>
		/// <param name="Answerid">回答id。</param>
		/// <param name="Text">编译信息。</param>
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
		/// 保存回答的代码。
		/// </summary>
		/// <param name="Answerid">回答id。</param>
		/// <param name="Text">用户提交的代码。</param>
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
		/// 用户新提交一个回答。
		/// </summary>
		/// <param name="UserName">用户名。</param>
		/// <param name="QuestionId">问题id</param>
		/// <param name="exe">所用编译器代号。</param>
		/// <returns>新创建的回答的id。</returns>
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
		/// 不推荐使用方法，注册用户时使用。
		/// </summary>
		/// <param name="username">用户名。</param>
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
