using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LitigationClearkLogic
{
    public class SaveStage
    {
        #region *******************************Bind Dropdown List**********************************************
        public DataTable GetAllStagesArabic()
        {
            string sql = " select stage_type_id,stage_type_desc_ar as  stage_type_desc from Stage_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllStagesEnglish()
        {
            string sql = "select stage_type_id,stage_type_desc as  stage_type_desc from Stage_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable MatterPreviousStagesAreabic(int Matter_ID)
        {
            string sql = "select st.stage_type_id,CAST(st.stage_type_desc_ar VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Previous_Stage_ID = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterPreviousStagesEnglish(int Matter_ID)
        {
            string sql = "select st.stage_type_id,CAST(st.stage_type_desc  as VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Previous_Stage_ID = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetAllStatusEnglish()
        {
            string sql = "select Satus_id,Staus_Desc as  Staus_Desc  from Statuses";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllStatusArabic()
        {
            string sql = "select Satus_id,Staus_Desc_ar as  Staus_Desc from Statuses";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable MatterStagesArabic(int Matter_ID)
        {
            string sql = "select s.Stage_Id,CAST(st.stage_type_desc_ar VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Stage_Id = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterStagesEnglish(int Matter_ID)
        {
            string sql = "select s.Stage_Id,CAST(st.stage_type_desc  as VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Stage_Type_ID = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Save Stage Data**********************************************

        public int StageAction(int @Stage_Id, int @Matter_Id, int @Stage_Type_Id, int @Status_Id, string @Discription, DateTime @Open_Date, DateTime @Close_Date, int @Preivious_Stage_Id, string @Mode)
        {     

            SqlParameter[] _p = new SqlParameter[9];
            _p[0] = new SqlParameter("@Stage_Id", @Stage_Id);
            _p[1] = new SqlParameter("@Matter_Id", @Matter_Id);
            _p[2] = new SqlParameter("@Stage_Type_Id", @Stage_Type_Id);
            _p[3] = new SqlParameter("@Status_Id", @Status_Id);
            _p[4] = new SqlParameter("@Discription", @Discription);
            _p[5] = new SqlParameter("@Open_Date", @Open_Date);
            _p[6] = new SqlParameter("@Close_Date", @Close_Date);
            _p[7] = new SqlParameter("@Preivious_Stage_Id", @Preivious_Stage_Id);
            _p[8] = new SqlParameter("@Mode", @Mode);
            
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_StageOperation", _p));
            return i;

        }

        #endregion

        #region *******************************Save Forecast Data**********************************************

        public int ForeCastAction(int @Stage_Id, int @Matter_Id, int @Stage_Type_Id, int @actual_effort, int @weighting, DateTime @exp_start_date, DateTime @exp_end_date, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[8];
            _p[0] = new SqlParameter("@Stage_Id", @Stage_Id);
            _p[1] = new SqlParameter("@Matter_Id", @Matter_Id);
            _p[2] = new SqlParameter("@Stage_Type_Id", @Stage_Type_Id);
            _p[3] = new SqlParameter("@actual_effort", @actual_effort);
            _p[4] = new SqlParameter("@weighting", @weighting);
            _p[5] = new SqlParameter("@exp_start_date", @exp_start_date);
            _p[6] = new SqlParameter("@exp_end_date", @exp_end_date);
            _p[7] = new SqlParameter("@Mode", @Mode);

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_ForecastOpertaion", _p));
            return i;

        }

        #endregion

         #region *******************************CloseStage data**********************************************
        public DataTable Closestagedata(int stage_ID)
        {
            string sql = "select Stage_Type_ID,Open_date,Close_date,Description from Stages where  Stage_ID='" + stage_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
         #endregion

        #region *******************************Close Stgage Data**********************************************

        public int ClosStageAction(int @Stage_ID, int @Status_ID, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Stage_ID", @Stage_ID);
            _p[1] = new SqlParameter("@Status_ID",@Status_ID);
            _p[2] = new SqlParameter("@Mode", @Mode);

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_CloseStageOpertaion", _p));
            return i;

        }

        #endregion

        #region *******************************Check Before CloseStage data**********************************************
        public DataTable chkClose(int stage_ID)
        {
            string sql = "select * from Cases where Status_ID=1 and Stage_ID='" + stage_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Audit Data for Stage*********************************************

        public int AuditStage(int @Stage_ID,string @Mode, string @userID)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Stage_ID", @Stage_ID);
            _p[1] = new SqlParameter("@Mode", @Mode);
            _p[2] = new SqlParameter("@userID", @userID);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AuditStage", _p));
            return i;

        }

       

        #endregion

        #region   *******Chart Data*************************
        public DataSet Chart_Data(string Matter_ID)
        {

            string sql = "SELECT st.stage_type_desc , s.actual_effort,s.weighting,s.exp_start_date,s.exp_end_date,s.Open_Date,s.Close_Date from Stages S ";
            sql = sql + "inner join Stage_Types ST on ( st.stage_type_id = S.Stage_Type_ID) and s.Matter_Id='"+Matter_ID+"'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        #endregion

        #region *******************************Get Priviuious satge ID*********************************************

        public int GetStage(int @Stage,int @Matter_Id, string @mode, out string @StageID)
        {
            SqlParameter[] _p = new SqlParameter[4];
            _p[0] = new SqlParameter("@Stage", @Stage);
            _p[1] = new SqlParameter("@Matter_Id",@Matter_Id);
            _p[2] = new SqlParameter("@mode", @mode);
            _p[3] = new SqlParameter("@StageID", SqlDbType.VarChar);
            _p[3].Size = 200;
            _p[3].Direction = ParameterDirection.Output;

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_GetPrevousStageID", _p));
            @StageID = (string)_p[3].Value;
            return i;



        }

        #endregion
    }
}
