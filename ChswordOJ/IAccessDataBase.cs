using System;
namespace ChswordOJ
{
	interface IDataBase
	{
		System.Data.DataTable DoDataTable(string StoredProcedureName, Dictionary p);
		string DoParameterSql(string StoredProcedureName, Dictionary p);
	}
}
