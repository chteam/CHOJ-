//using System;
//using System.Data.SqlClient;
//using System.Data;
//using System.Configuration;

//namespace ChswordOJ {
//    /// <summary>
//    /// 成幻互联ADO.net数据操作类。
//    /// </summary>
//    public class DoDataBase : ChswordOJ.IDoDataBase {
//        private SqlConnection _SqlConnection;
//        private SqlCommand _SqlCommand;
//        /// <summary>
//        /// 构造函数，对DoDataBase对象进行初始化。
//        /// </summary>
//        public DoDataBase() {
//            _SqlConnection = new SqlConnection();
//            _SqlCommand = new SqlCommand();
//        }
//        /// <summary>
//        /// 打开数据库。
//        /// </summary>
//        /// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
//        void OpenSQL(String StoredProcedureName) {
//            _SqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            _SqlCommand.Connection = _SqlConnection;
//            _SqlCommand.CommandType = CommandType.StoredProcedure;
//            _SqlCommand.CommandText = StoredProcedureName;
//            _SqlConnection.Open();
//        }
//        /// <summary>
//        /// 关闭与数据库的连接。
//        /// </summary>
//        void CloseSql() {
//            _SqlConnection.Close();
//        }
//        /// <summary>
//        /// 进行查询或数据操作。
//        /// </summary>
//        /// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
//        /// <param name="SqlParameter">存储过程参数。</param>
//        /// <returns>包含查询结果的</returns>
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
//        /// 进行查询或数据操作。
//        /// </summary>
//        /// <param name="StoredProcedureName">设置要对数据源执行的存储过程。</param>
//        /// <param name="SqlParameter">存储过程参数。</param>
//        /// <returns>返回查询得到的数据集。</returns>
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
