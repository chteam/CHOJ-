using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace ChswordOJ {
	/// <summary>
	/// �ɻû���ADO.net���ݲ����ࡣ
	/// </summary>
	public class AccessDataBase : ChswordOJ.IDataBase  {
		private OleDbConnection _Conn;
		private OleDbCommand _Cmd;
		/// <summary>
		/// ���캯������DoDataBase������г�ʼ����
		/// </summary>
		public AccessDataBase() {
			_Conn = new OleDbConnection();
			_Cmd = new OleDbCommand();
		}
		/// <summary>
		/// �����ݿ⡣
		/// </summary>
		/// <param name="StoredProcedureName">����Ҫ������Դִ�еĴ洢���̡�</param>
		void OpenSQL(String StoredProcedureName) {
			_Conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			_Cmd.Connection = _Conn;
			_Cmd.CommandType = CommandType.Text;
			_Cmd.CommandText = StoredProcedureName;
			_Conn.Open();
		}
		/// <summary>
		/// �ر������ݿ�����ӡ�
		/// </summary>
		void CloseSql() {
			_Conn.Close();
		}
		/// <summary>
		/// ���в�ѯ�����ݲ�����
		/// </summary>
		/// <param name="StoredProcedureName">����Ҫ������Դִ�еĴ洢���̡�</param>
		/// <param name="SqlParameter">�洢���̲�����</param>
		/// <returns>������ѯ�����</returns>
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
		/// ���в�ѯ�����ݲ�����
		/// </summary>
		/// <param name="StoredProcedureName">����Ҫ������Դִ�еĴ洢���̡�</param>
		/// <param name="SqlParameter">�洢���̲�����</param>
		/// <returns>���ز�ѯ�õ������ݼ���</returns>
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
