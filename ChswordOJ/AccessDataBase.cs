using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace ChswordOJ {
	/// <summary>
	/// 成幻互联ADO.net数据操作类。
	/// </summary>
	public class AccessDataBase : ChswordOJ.IDataBase  {
		private OleDbConnection _Conn;
		private OleDbCommand _Cmd;
		/// <summary>
		/// 构造函数，对DoDataBase对象进行初始化。
		/// </summary>
		public AccessDataBase() {
			_Conn = new OleDbConnection();
			_Cmd = new OleDbCommand();
		}
		/// <summary>
		/// 打开数据库。
		/// </summary>
		/// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
		void OpenSQL(String StoredProcedureName) {
			_Conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			_Cmd.Connection = _Conn;
			_Cmd.CommandType = CommandType.Text;
			_Cmd.CommandText = StoredProcedureName;
			_Conn.Open();
		}
		/// <summary>
		/// 关闭与数据库的连接。
		/// </summary>
		void CloseSql() {
			_Conn.Close();
		}
		/// <summary>
		/// 进行查询或数据操作。
		/// </summary>
		/// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
		/// <param name="SqlParameter">存储过程参数。</param>
		/// <returns>包含查询结果的</returns>
		public String DoParameterSql(String StoredProcedureName, Dictionary p) {
			string ret = "";
			OpenSQL(StoredProcedureName);
			foreach (string key in p.Keys) {
				_Cmd.Parameters.Add(new OleDbParameter(key, p[key]));
			}
			//for (int i = p.GetLowerBound(0); i <= p.GetUpperBound(0); i++) {
			//	_Cmd.Parameters.Add(p[i]);
			//}

			ConnectionState previousConnectionState = _Conn.State;
			try {
				if (_Conn.State == ConnectionState.Closed) _Conn.Open();
				ret = _Cmd.ExecuteScalar().ToString();

			} catch {
				if (previousConnectionState == ConnectionState.Closed)
					_Conn.Close();
			}
			CloseSql();
			return ret;
		}

		/// <summary>
		/// 进行查询或数据操作。
		/// </summary>
		/// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
		/// <param name="SqlParameter">存储过程参数。</param>
		/// <returns>返回查询得到的数据集。</returns>
		public DataTable DoDataTable(String StoredProcedureName, Dictionary p) {
			OpenSQL(StoredProcedureName);
			foreach (string key in p.Keys) {
				_Cmd.Parameters.Add(new OleDbParameter(key, p[key]));
			}
			DataTable dt = new DataTable();
			OleDbDataAdapter MySqlDataAdapter = new OleDbDataAdapter(_Cmd);
			MySqlDataAdapter.Fill(dt);
			CloseSql();
			return dt;
		}

	}

}
