//using System;
//using System.Data.SqlClient;
//using System.Data;
//using System.Configuration;

//namespace ChswordOJ {
//    /// <summary>
//    /// �ɻû���ADO.net���ݲ����ࡣ
//    /// </summary>
//    public class DoDataBase : ChswordOJ.IDoDataBase {
//        private SqlConnection _SqlConnection;
//        private SqlCommand _SqlCommand;
//        /// <summary>
//        /// ���캯������DoDataBase������г�ʼ����
//        /// </summary>
//        public DoDataBase() {
//            _SqlConnection = new SqlConnection();
//            _SqlCommand = new SqlCommand();
//        }
//        /// <summary>
//        /// �����ݿ⡣
//        /// </summary>
//        /// <param name="StoredProcedureName">����Ҫ������Դִ�еĴ洢���̡�</param>
//        void OpenSQL(String StoredProcedureName) {
//            _SqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            _SqlCommand.Connection = _SqlConnection;
//            _SqlCommand.CommandType = CommandType.StoredProcedure;
//            _SqlCommand.CommandText = StoredProcedureName;
//            _SqlConnection.Open();
//        }
//        /// <summary>
//        /// �ر������ݿ�����ӡ�
//        /// </summary>
//        void CloseSql() {
//            _SqlConnection.Close();
//        }
//        /// <summary>
//        /// ���в�ѯ�����ݲ�����
//        /// </summary>
//        /// <param name="StoredProcedureName">����Ҫ������Դִ�еĴ洢���̡�</param>
//        /// <param name="SqlParameter">�洢���̲�����</param>
//        /// <returns>������ѯ�����</returns>
//        public String DoParameterSql(String StoredProcedureName, SqlParameter[] SqlParameter) {
//            String Result = "";
//            SqlDataReader reader;
//            OpenSQL(StoredProcedureName);
//            for (int i = SqlParameter.GetLowerBound(0); i <= SqlParameter.GetUpperBound(0); i++) {
//                _SqlCommand.Parameters.Add(SqlParameter[i]);
//            }
//            _SqlCommand.Parameters.Add("@RETURN_VALUE", SqlDbType.BigInt);
//            _SqlCommand.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
//            ConnectionState previousConnectionState = _SqlConnection.State;
//            try {
//                if (_SqlConnection.State == ConnectionState.Closed) _SqlConnection.Open();
//                reader = _SqlCommand.ExecuteReader();
//                Result = _SqlCommand.Parameters["@RETURN_VALUE"].Value.ToString();
//            }
//            catch {
//                if (previousConnectionState == ConnectionState.Closed)
//                    _SqlConnection.Close();
//            }
//            CloseSql();
//            return Result;
//        }

//        /// <summary>
//        /// ���в�ѯ�����ݲ�����
//        /// </summary>
//        /// <param name="StoredProcedureName">����Ҫ������Դִ�еĴ洢���̡�</param>
//        /// <param name="SqlParameter">�洢���̲�����</param>
//        /// <returns>���ز�ѯ�õ������ݼ���</returns>
//        public DataSet DoDataSet(String StoredProcedureName, SqlParameter[] SqlParameter) {
//            OpenSQL(StoredProcedureName);
//            for (int i = SqlParameter.GetLowerBound(0); i <= SqlParameter.GetUpperBound(0); i++) {
//                _SqlCommand.Parameters.Add(SqlParameter[i]);
//            }
//            DataSet ds = new DataSet();
//            SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(_SqlCommand);
//            MySqlDataAdapter.Fill(ds, "table_1");
//            CloseSql();
//            return ds;
//        }
//    }

//}
