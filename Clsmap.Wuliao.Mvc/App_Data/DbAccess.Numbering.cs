using System;
using Dapper;

using Clsmap.Wuliao.Mvc.Utilities;

namespace Clsmap.Wuliao.Mvc.App_Data
{
    public partial class DbAccess
    {
        public Int32 GetNewId(String tableName)
        {
            var sql = @"
select n.last_no
  from `master.numbering` as n
 where n.table_name = @tableName;";

            try
            {
                connection.Open();
                var dbResult = connection.ExecuteScalar(sql, new {tableName = tableName});
                return Converters.Parse(dbResult, Convert.ToInt32, 0);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

