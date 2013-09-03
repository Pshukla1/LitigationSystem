using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LitigationDataLogic
{
    public class HearingLogic
    {
        #region**************************Gird Binding***********************
        public DataTable HearingGridEnglish()
        {
            string sql = "select H.Hearing_ID,c.Case_number,h.Hearing_date,ho.Hearing_Outcome_Desc_EN as Hearing_Outcome_Desc_EN , ";
            sql = sql + " ps.Pleading_status_desc_en,hs.staus_desc as staus_desc from  Cases C ";
            sql = sql + "left  join Hearings H on (C.Case_ID = h.Case_ID) ";
            sql = sql + "left join Hearings_outcome HO on(ho.Hearing_Outcome_ID=h.Hearing_outcome_ID) ";
            sql = sql + "left join Hearing_status HS on (hs.status_id = h.Hearing_Staus_Id) ";
            sql = sql + "left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + "left join Pleading_Status PS on (ps.Pleadings_Status_ID = p.Pleading_status_id) ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable HearingGridArabic()
        {
            string sql = "select H.Hearing_ID,c.Case_number,h.Hearing_date,ho.Hearing_Outcome_Desc_AR as Hearing_Outcome_Desc_EN , ";
            sql = sql + " ps.Pleading_status_desc_ar as Pleading_status_desc_en,hs.staus_desc_ar as staus_desc from Hearings H ";
            sql = sql + "inner join Hearing_status HS on (HS.status_id = H.Hearing_Staus_Id) ";
            sql = sql + "inner join Cases C on (C.Case_ID = h.Case_ID)";
            sql = sql + "inner join Hearings_outcome HO on (Ho.Hearing_Outcome_ID = H.Hearing_outcome_ID) ";
            sql = sql + "inner join Pleadings P on (h.Hearing_ID = p.Hearing_ID) ";
            sql = sql + "inner join Pleading_Status PS on (p.Pleading_status_id =PS.Pleadings_Status_ID) ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetSpecficSearch(string Matter_ID)
        {
            string sql = "select Matter_Id,Matter_Number from Matters ";
            sql = sql + "where Matter_Id = '" + Matter_ID + "'";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region**************************Gird Binding***********************
        public DataTable GetAllEmployeeEnlish()
        {
            string sql = "select Employee_Id,UserName as UserName from Employess";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllEmployeeArabic()
        {
            string sql = "select Employee_Id,UserName_ar as UserName  from Employess";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable HearingStatusEnlish()
        {
            string sql = "select status_id, staus_desc as staus_desc from Hearing_status";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable HearingStatusArabic()
        {
            string sql = "select status_id, staus_desc_ar as staus_desc from Hearing_status";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable HearingOutcomeEnlish()
        {
            string sql = "select Hearing_Outcome_ID, Hearing_Outcome_Desc_EN as Hearing_Outcome_Desc_EN from Hearings_outcome";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable HearingOutcomeArabic()
        {
            string sql = "select Hearing_Outcome_ID, Hearing_Outcome_Desc_AR as Hearing_Outcome_Desc_EN from Hearings_outcome";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable PleadingEnlish()
        {
            string sql = "select Pleadings_Status_ID,Pleading_status_desc_en as Pleading_status_desc_en  from Pleading_Status";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable PleadingArabic()
        {
            string sql = "select Pleadings_Status_ID,Pleading_status_desc_ar as Pleading_status_desc_en  from Pleading_Status";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable JudgementEnlish()
        {
            string sql = "select Outcome_ID, OutCome_Desc_En as OutCome_Desc_En from Judgement_Outcome";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable JudgementArabic()
        {
            string sql = "select Outcome_ID, OutCome_Desc_Ar as OutCome_Desc_En from Judgement_Outcome";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region**************************Hearing Details***********************
        public DataTable HearingDetails(int HearingID)
        {
            string sql = "select H.Hearing_ID,h.Case_ID,c.Case_number, h.Hearing_date,h.Hearing_outcome_ID,h.Hearing_Staus_Id, ";
            sql = sql + "h.Attend_Empl_Id,h.Hearings_Notes,p.Pleading_status_id,p.Reviewed_Date,p.Reviewed_by,p.Created_date, ";
            sql = sql + "h.Hearing_outcome_ID,h.Decision_Details,j.Judgement_OutCome_ID,j.Date_Judgement,  ";
            sql = sql + "h.Client_Docket,h.oppenet_Docket,j.Judgement_doc,p.Pleading_document ";
            sql = sql + "from Hearings H   ";
            sql = sql + "left join Cases C on (C.Case_ID = h.Case_ID)  ";
            sql = sql + "left outer join Pleadings P on (h.Hearing_ID = p.Hearing_ID)  ";
            sql = sql + "left outer join Judgement J on(j.Heraings_ID = h.Hearing_ID)  ";
            sql = sql + "where h.Hearing_ID='" + HearingID + "'  ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion
        
        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=5 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion
    }
}
