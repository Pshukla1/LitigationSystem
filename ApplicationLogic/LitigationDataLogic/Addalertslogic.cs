using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationDataLogic
{
    public class Addalertslogic
    {
        #region**************************Gird Binding***********************
        public DataTable AlertGridEnglish()
        {
            string sql = "select  a.Alert_ID, m.Matter_ID,m.Matter_number,AT.Alert_Type_En,A.Due_date,EMP.UserName as ConcernEmp, EMP1.UserName createdby,a.Date_Created,A.Discription  from Alerts A ";
            sql = sql + "right join Matters M on (m.Matter_ID = A.Matter_ID) ";
            sql = sql + "left join alert_types AT on (AT.Alert_type_ID = A.Alert_Type_ID) ";
            sql = sql + "left join Employess EMP on (emp.Employee_Id =a.Concern_emp_ID) ";
            sql = sql + "left join Employess EMP1 on (EMP1.Employee_Id = A.Created_Emp_ID) ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable AlertGridArabic()
        {
            string sql = "select  a.Alert_ID, m.Matter_ID,m.Matter_number,AT.Alert_Type_En,A.Due_date,EMP.UserName as ConcernEmp, EMP1.UserName createdby,a.Date_Created,A.Discription  from Alerts A ";
            sql = sql + "right join Matters M on (m.Matter_ID = A.Matter_ID) ";
            sql = sql + "left join alert_types AT on (AT.Alert_type_ID = A.Alert_Type_ID) ";
            sql = sql + "left join Employess EMP on (emp.Employee_Id =a.Concern_emp_ID) ";
            sql = sql + "left join Employess EMP1 on (EMP1.Employee_Id = A.Created_Emp_ID) ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region**************************Dropdown Binding***********************
        public DataTable GetAlert_type_Enlish()
        {
            string sql = "select Alert_Type_ID, Alert_Type_En as Alert_Type_En from Alert_Types ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAlert_type_Arebic()
        {
            string sql = "select Alert_Type_ID, Alert_Type_Ar as Alert_Type_En from Alert_Types ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region**************************Alert Details***********************
        public DataTable GetAlertDetails(int AlertID)
        {
            string sql = "select A.Alert_ID,A.Concern_emp_ID,A.Alert_type_ID,A.Created_Emp_ID,A.Due_date,A.Date_Created,a.Discription from Alerts A where Alert_ID ='" + AlertID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region *******************************Save Alert Data**********************************************

        public int SaveAlert(int @Alert_type_ID, int @Concern_emp_ID, int @Created_Emp_ID, DateTime @Date_Created, string @Discription, DateTime @Due_date, int @Matter_ID, string @Mode)
        {
            SqlParameter[] _p = new SqlParameter[8];
            _p[0] = new SqlParameter("@Alert_type_ID", @Alert_type_ID);
            _p[1] = new SqlParameter("@Concern_emp_ID", @Concern_emp_ID);
            _p[2] = new SqlParameter("@Created_Emp_ID", @Created_Emp_ID);
            _p[3] = new SqlParameter("@Date_Created", @Date_Created);
            _p[4] = new SqlParameter("@Discription", @Discription);
            _p[5] = new SqlParameter("@Due_date", @Due_date);
            _p[6] = new SqlParameter("@Matter_ID", @Matter_ID);
            _p[7] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AddAlert", _p));
            return i;

        }

        #endregion

        #region**************************GetMailID**********************
        public DataTable GetAlertMailToFallower(int MatterID)
        {
            string sql = "select distinct emp.Mail_ID from Fallowers F inner join Employess emp on (emp.Employee_Id = f.Employee_Id) ";
            sql = sql + "where f.Matter_Id= '" + MatterID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetAlertMailtoAssigned_Responsiable(int MatterID)
        {
            string sql = "select  emp.Mail_ID ,emp1.Mail_ID from Matters M ";
            sql = sql + "inner join Employess emp on (emp.Employee_Id = m.Assigned_lawyer_ID) ";
            sql = sql + "inner join Employess emp1 on (emp1.Employee_Id = m.Responsibale_Lawyer_ID) ";
            sql = sql + "where M.Matter_Id='" + MatterID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=8 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region**************************Alert MatterId***********************
        public DataTable GetMatterID(string matterid)
        {
            string sql = "select Matter_ID from Matters where Matter_number='" + matterid + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion
    }
}
