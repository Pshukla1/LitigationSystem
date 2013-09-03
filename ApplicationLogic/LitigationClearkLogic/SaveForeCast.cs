using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationClearkLogic
{
    public class SaveForeCast
    {
        #region *******************************Bind Dropdown List**********************************************
        public DataTable MatterStagesArebic(int Matter_ID)
        {
            string sql = "select s.Stage_Id,CAST(st.stage_type_desc_ar VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Stage_Id = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterStagesEnglish(int Matter_ID)
        {
            string sql = "select s.Stage_Id,CAST(st.stage_type_desc  as VARCHAR(50)) +' - ' +  CAST(convert(varchar, s.exp_start_date, 105) as VARCHAR(50))  as  stage_type_desc from Stages S, Stage_Types ST where s.Stage_Id = st.stage_type_id and s.Matter_Id='" + Matter_ID + "'";
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
    }
}
