using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationClearkLogic
{
    public class SaveMatter
    {

        #region *******************************Bind Dropdown List**********************************************
        public DataTable Get_Client_Opponent()
        {
            string sql = "select Person_Id,Company_Name from Persons";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllStagesEnglish()
        {
            string sql = "select stage_type_id,stage_type_desc as  stage_type_desc from Stage_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetAllStatusEnglish()
        {
            string sql = "select Satus_id,Staus_Desc as  Staus_Desc  from Statuses";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllStatusArebic()
        {
            string sql = "select Satus_id,Staus_Desc_ar as  Staus_Desc from Statuses";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetAllOfficEnglish()
        {
            string sql = "select Office_ID, Office_Desc_En as offc_desc   from Offices";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllOfficArabic()
        {
            string sql = "select Office_ID, Office_Desc_AR as offc_desc   from Offices";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }



        #endregion

        #region *******************************MatterAction**********************************************

        public int MatteAction(string @Matter_Number, int @Client_ID, int @Matter_Type_ID, DateTime @Open_date, int @Responsibile_Lawyer_Id, int @Assigned_Lawyer_ID, string @Description, int @Matter_Status_id,DateTime @Created_Date, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[10];
            _p[0] = new SqlParameter("@Matter_Number", @Matter_Number);
            _p[1] = new SqlParameter("@Client_ID", @Client_ID);
            _p[2] = new SqlParameter("@Matter_Type_ID", @Matter_Type_ID);
            _p[3] = new SqlParameter("@Open_Date", @Open_date);
            _p[4] = new SqlParameter("@Responsibile_Lawyer_Id", @Responsibile_Lawyer_Id);
            _p[5] = new SqlParameter("@Assigned_Lawyer_ID", @Assigned_Lawyer_ID);
            _p[6] = new SqlParameter("@Description", @Description);
            _p[7] = new SqlParameter("@Created_Date", @Created_Date);
            _p[8] = new SqlParameter("@Matter_Status_id", @Matter_Status_id);
            _p[9] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_MatterOperation", _p));
            return i;

        }

        #endregion

        #region *************************Select Data for like wike**************************************
        public DataTable SelectLikeDataGetMatter(string MatterNumber)
        {

            string sql = "select matter_number from matter_details where  matter_number like '" + MatterNumber + "%'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable SelectLikeDataClient(string ClientName)
        {

            string sql = "select Company_Name from Persons where Company_Name like '" + ClientName + "%'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Audit Data for Matters*********************************************

        public int AuditMatter(int @Matter_ID, string @Mode, string @userID)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Matter_ID", @Matter_ID);
            _p[1] = new SqlParameter("@Mode", @Mode);
            _p[2] = new SqlParameter("@userID", @userID);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AuditMatters", _p));
            return i;

        }



        #endregion
    }
}
