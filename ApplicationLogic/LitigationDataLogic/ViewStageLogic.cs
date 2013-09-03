using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationDataLogic
{
    public class ViewStageLogic
    {
        public DataTable ViewStage(string MatterID)
        {
            string sql = "select s.Stage_ID,s.Matter_Id, st.stage_type_desc,sta.Staus_Desc,s.Description,s.Open_date,s.Close_date,s.Exp_Start_Date,s.Exp_End_date,s.weighting,s.Actual_Effort ";
            sql = sql + "from  Stages S ";
            sql = sql + " inner join Stage_Types ST on (s.Stage_Type_ID = st.stage_type_id) ";
            sql = sql + " inner join Statuses STA  on (s.Status_ID = sta.Satus_id) ";
            sql = sql + " where  ";
            sql = sql + "s.Matter_Id = '" + MatterID + "'  and isdelete = 0 order by s.stage_type_id ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetSpecficSearch(string Matter_ID)
        {
            string sql = "select Matter_Id,Matter_Number from Matters ";
            sql = sql + "where Matter_Id = '" + Matter_ID + "'";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
       
    }
}
