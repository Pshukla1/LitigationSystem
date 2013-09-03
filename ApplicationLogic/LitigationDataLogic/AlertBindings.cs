using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationDataLogic
{
    public class AlertBindings
    {
        #region   *******Get Alerts*************************
        public DataTable GetAllAlertsEnglish()
        {
            string sql = "select M.Matter_number,A.Due_date,At.Alert_Type_En as  Alert_Type_En from alerts A ";
            sql = sql + "inner join Alert_Types AT on (a.Alert_type_ID = AT.Alert_Type_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = A.Matter_ID) ";
            sql = sql + "order by Due_date asc ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllAlertsArabic()
        {
            string sql = "select M.Matter_number,A.Due_date,At.Alert_Type_Ar as  Alert_Type_En from alerts A ";
            sql = sql + "inner join Alert_Types AT on (a.Alert_type_ID = AT.Alert_Type_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = A.Matter_ID) ";
            sql = sql + "order by Due_date asc ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Get Alerts on date Click*************************
        public DataTable GetAllAlertsEnglish_Calclick(string date)
        {
            string sql = "select M.Matter_number,A.Due_date,At.Alert_Type_En as  Alert_Type_En from alerts A ";
            sql = sql + "inner join Alert_Types AT on (a.Alert_type_ID = AT.Alert_Type_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = A.Matter_ID) ";
            sql = sql + "where Due_date ='" + date + "' ";
            sql = sql + "order by Due_date asc ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllAlertsArabic_Calclick(string date)
        {
            string sql = "select M.Matter_number,A.Due_date,At.Alert_Type_Ar as  Alert_Type_En from alerts A ";
            sql = sql + "inner join Alert_Types AT on (a.Alert_type_ID = AT.Alert_Type_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = A.Matter_ID) ";
            sql = sql + "where Due_date ='"+date+"' ";
            sql = sql + "order by Due_date asc ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion
    }
}
