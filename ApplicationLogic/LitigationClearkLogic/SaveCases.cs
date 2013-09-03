using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace LitigationClearkLogic
{
    public class SaveCases
    {
        #region *******************************Bind Dropdown List**********************************************
        public DataTable Client_oppnent_Capcity_Arebic()
        {
            string sql = "select Capacity_id, capacity_desc_ar as  capcitiy  from Capacities";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Client_opponent_Capcity_English()
        {
            string sql = "select Capacity_id, capacity_desc as  capcitiy  from Capacities";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable outcome_English()
        {
            string sql = "select Outcome_Id, Outcome_Desc as  outcome  from Outcomes";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable outcome_Arebic()
        {
            string sql = "select Outcome_Id, Outcome_Desc_ar as  outcome  from Outcomes";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CaseType_English()
        {
            string sql = "select Case_Type_ID,Case_Type_desc as CaseType    from Case_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CaseType_Arebic()
        {
            string sql = "select Case_Type_ID,Case_Type_Desc_ar as CaseType    from Case_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable JudgeName_English()
        {
            string sql = "select judge_id,judge_name as  JudgeName  from Judges";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable JudgeName_Arebic()
        {
            string sql = "select judge_id,judge_name_ar as  JudgeName  from Judges";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CourtName_English()
        {
            string sql = "select court_id, court_name as  court  from Courts";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CourtName_Arebic()
        {
            string sql = "select court_id, court_name_ar as  court  from Courts";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterStagesArabic(int Matter_ID)
        {
            string sql = "select s.Stage_Id,CAST(st.stage_type_desc_ar VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Stage_Type_ID = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterStagesEnglish(int Matter_ID)
        {
            string sql = "select s.Stage_Id,CAST(st.stage_type_desc  as VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Stage_Type_ID = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Department_English()
        {
            string sql = "select Department_ID,Department_Name_EN as Department_Name from Departments";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Department_Arebic()
        {
            string sql = "select Department_ID,Department_name_AR as Department_Name from Departments";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region *******************************Save Cases Data**********************************************

        public int CaseAction(string @Case_Number, int @Court_Id, int @Judge_Id, int @Client_Capcity_Id, int @Opponent_Capcity_Id, string @Description, DateTime @Filling_Date, DateTime @End_date, int @stage_id,int @Court_Clerk_Id,int @Case_Tyep_ID,int @Case_ID,string @Hall_number,int @Department_Id, string @Mode)
        {
             SqlParameter[] _p = new SqlParameter[15];
            _p[0] = new SqlParameter("@Case_Number", @Case_Number);
            _p[1] = new SqlParameter("@Court_Id", @Court_Id);
            _p[2] = new SqlParameter("@Judge_Id", @Judge_Id);
            _p[3] = new SqlParameter("@Client_Capcity_Id", @Client_Capcity_Id);
            _p[4] = new SqlParameter("@Opponent_Capcity_Id", @Opponent_Capcity_Id);
            _p[5] = new SqlParameter("@Description", @Description);
            _p[6] = new SqlParameter("@Filling_Date", @Filling_Date);
            _p[7] = new SqlParameter("@End_date", @End_date);
            _p[8] = new SqlParameter("@stage_id", @stage_id);
            _p[9] = new SqlParameter("@Court_Clerk_Id", @Court_Clerk_Id);
            _p[10] = new SqlParameter("@Case_Tyep_ID", @Case_Tyep_ID);
            _p[11] = new SqlParameter("@Case_ID", @Case_ID);
            _p[12] = new SqlParameter("@Hall_number", @Hall_number);
            _p[13] = new SqlParameter("@Department_Id", @Department_Id);
            _p[14] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_CasesOpertaion", _p));
            return i;

        }

        #endregion

        #region *******************************Close Cases Data**********************************************

        public int CloseCaseAction(int @Case_ID, int @Status_ID,string @Mode)
        {
            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Case_ID", @Case_ID);
            _p[1] = new SqlParameter("@Status_ID", @Status_ID);
            _p[2] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_CloseCasesOpertaion", _p));
            return i;

        }

        #endregion

        #region *******************************Case Check**********************************************
        public DataTable CaseChk( int CASEID)
        {
            string sql = "select Case_ID  from Hearings where Case_ID ='" + CASEID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Audit Data for Case*********************************************

        public int AuditCase(int @Case_ID, string @Mode, string @userID)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Case_ID", @Case_ID);
            _p[1] = new SqlParameter("@Mode", @Mode);
            _p[2] = new SqlParameter("@userID", @userID);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AuditCase", _p));
            return i;

        }



        #endregion

        #region *******************************GET MATTER NUMBER FROM CASE*********************************************

        public int MATTERNOFROMCASE(int @Case_ID,out string @Matter_number)
        {
            SqlParameter[] _p = new SqlParameter[2];
            _p[0] = new SqlParameter("@Case_ID", @Case_ID);
            _p[1] = new SqlParameter("@Matter_number", SqlDbType.VarChar);
            _p[1].Size = 200;
            _p[1].Direction = ParameterDirection.Output;

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_GetMatterNO", _p));
            @Matter_number = (string)_p[1].Value;
            return i;



        }

        #endregion
    }
}
