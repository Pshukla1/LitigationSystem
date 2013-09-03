using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationDataLogic
{
    public class LoginLogic
    {
        #region   *******Get User Details*************************
        public DataTable GetUserDetailsEnglish(string Accountname)
        {
            string sql = "select Employee_Id , UserName as NAME,GROUPNAME,SAMNAME from Employess where SAMNAME ='" + Accountname + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetUserDetailsArabic(string Accountname)
        {
            string sql = "select Employee_Id , UserName_ar as NAME,GROUPNAME,SAMNAME from Employess where SAMNAME ='" + Accountname + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion
    }
}
