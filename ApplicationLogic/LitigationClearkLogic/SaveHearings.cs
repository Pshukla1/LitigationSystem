using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationClearkLogic
{
    public class SaveHearings
    {

        #region *******************************Bind Dropdown List**********************************************

        public DataTable HeraingsStaus_English()
        {
            string sql = "select status_id,staus_desc as staus_desc from Hearing_status";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable HeraingsStaus_Arebic()
        {
            string sql = "select status_id,staus_desc_ar as staus_desc from Hearing_status";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterCase(int Matter_ID)
        {
            string sql = "select c.Case_ID,c.Case_Number from Stages S inner join Cases C on (s.Stage_Id = c.stage_id) and s.Matter_Id ='" + Matter_ID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable HeraingsOutcome_Arebic()
        {
            string sql = "select Hearing_Outcome_ID,Hearing_Outcome_Desc_AR as Hearing_Outcome_Desc from Hearings_outcome";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable HeraingsOutcome_English()
        {
            string sql = "select Hearing_Outcome_ID,Hearing_Outcome_Desc_EN as Hearing_Outcome_Desc from Hearings_outcome";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }


        #endregion

        #region *******************************Save Hearings Data**********************************************

        public int HearingsAction(string @Case_ID, DateTime @Hearing_date, int @Attend_Empl_Id, int @Hearing_Staus_Id, string @Hearings_Notes,string @mode)
        {
            SqlParameter[] _p = new SqlParameter[6];
            _p[0] = new SqlParameter("@Case_ID",@Case_ID);
            _p[1] = new SqlParameter("@Hearing_date",@Hearing_date);
            _p[2] = new SqlParameter("@Attend_Empl_Id",@Attend_Empl_Id);
            _p[3] = new SqlParameter("@Hearing_Staus_Id",@Hearing_Staus_Id);
            _p[4] = new SqlParameter("@Hearings_Notes",@Hearings_Notes);
            _p[5] = new SqlParameter("@mode",@mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_HearingOpertaion", _p));
            return i;

        }

        #endregion

        #region *******************************Save Pleading Data**********************************************

        public int PleadingAction(int @Hearing_ID, int @Pleading_status_id, int @Prepared_By, DateTime @Reviewed_Date, int @Reviewed_by, string @mode)
        {
            SqlParameter[] _p = new SqlParameter[6];
            _p[0] = new SqlParameter("@Hearing_ID", @Hearing_ID);
            _p[1] = new SqlParameter("@Pleading_status_id", @Pleading_status_id);
            _p[2] = new SqlParameter("@Prepared_By", @Prepared_By);
            _p[3] = new SqlParameter("@Reviewed_Date", @Reviewed_Date);
            _p[4] = new SqlParameter("@Reviewed_by", @Reviewed_by);
            _p[5] = new SqlParameter("@mode", @mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_PleadingOpertaion", _p));
            return i;

        }

        #endregion

        #region *******************************Add Judgements Data**********************************************

        public int JudgementAction(int @Judgement_OutCome_ID, string @Judgement_doc, int @Heraings_ID, DateTime @Date_Judgement, string @Decision_Details, string @mode)
        {
            SqlParameter[] _p = new SqlParameter[6];
            _p[0] = new SqlParameter("@Judgement_OutCome_ID", @Judgement_OutCome_ID);
            _p[1] = new SqlParameter("@Judgement_doc", @Judgement_doc);
            _p[2] = new SqlParameter("@Heraings_ID", @Heraings_ID);
            _p[3] = new SqlParameter("@Date_Judgement", @Date_Judgement);
            _p[4] = new SqlParameter("@Decision_Details", @Decision_Details);
            _p[5] = new SqlParameter("@mode", @mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AddJudgements", _p));
            return i;

        }

        #endregion

        #region *******************************Add Decision Data**********************************************

        public int DecisionAction(int @Hearing_ID, int @Hearing_outcome_ID, string @Decision_Details,string @mode)
        {
            SqlParameter[] _p = new SqlParameter[4];
            _p[0] = new SqlParameter("@Hearing_ID", @Hearing_ID);
            _p[1] = new SqlParameter("@Hearing_outcome_ID", @Hearing_outcome_ID);
            _p[2] = new SqlParameter("@Decision_Details", @Decision_Details);
            _p[3] = new SqlParameter("@mode", @mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AddDecision", _p));
            return i;

        }

        #endregion

        #region *******************************CheckDecisiom before Judgment**********************************************
        public DataTable ChkDecision(int Hearing_ID)
        {
            string sql = "select Hearing_outcome_ID  from Hearings  where Hearing_ID='" + Hearing_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Delete Hearings**********************************************

        public int DeleteHearings(int @Hearing_ID, string @mode)
        {
            SqlParameter[] _p = new SqlParameter[2];
            _p[0] = new SqlParameter("@Hearing_ID", @Hearing_ID);
            _p[1] = new SqlParameter("@mode", @mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_Deletehearings", _p));
            return i;

        }

        #endregion

        #region *******************************Add Document**********************************************

        public int AddHearingDocument(int @Hearing_ID, string @Client_Docket,string @oppenet_Docket,string @Pleading_document, string @mode,out string @Hearingerror)
        {
            SqlParameter[] _p = new SqlParameter[6];
            _p[0] = new SqlParameter("@Hearing_ID", @Hearing_ID);
            _p[1] = new SqlParameter("@Client_Docket",@Client_Docket);
            _p[2] = new SqlParameter("@oppenet_Docket",@oppenet_Docket);
            _p[3] = new SqlParameter("@Pleading_document",@Pleading_document);
            _p[4] = new SqlParameter("@mode", @mode);
            _p[5] = new SqlParameter("@Hearingerror", SqlDbType.VarChar);
            _p[5].Size = 200;
            _p[5].Direction = ParameterDirection.Output;
            
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_HearingDocument", _p));
            @Hearingerror  = (string)_p[5].Value;
            return i;

           

        }

        #endregion

        #region *******************************Audit Data for Hearings*********************************************

        public int AuditHearings(int @Hearing_ID, string @Mode, string @userID)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Hearing_ID", @Hearing_ID);
            _p[1] = new SqlParameter("@Mode", @Mode);
            _p[2] = new SqlParameter("@userID", @userID);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AuditHearings", _p));
            return i;

        }



        #endregion

        #region *******************************Audit Data for Pleadings*********************************************

        public int AuditPleadings(int @Pleadding_id, string @Mode, string @userID)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Pleadding_id", @Pleadding_id);
            _p[1] = new SqlParameter("@Mode", @Mode);
            _p[2] = new SqlParameter("@userID", @userID);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_Auditpleadings", _p));
            return i;

        }



        #endregion

        #region *******************************Audit Data for Judgement*********************************************

        public int AuditJudgement(int @Judgement_ID, string @Mode, string @userID)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Judgement_ID", @Judgement_ID);
            _p[1] = new SqlParameter("@Mode", @Mode);
            _p[2] = new SqlParameter("@userID", @userID);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AuditJudgement", _p));
            return i;

        }



        #endregion

        #region *******************************GET MATTER NUMBER FROM CASE*********************************************

        public int MATTERNOFROMCASE(int @Hearing_ID, out string @Matter_number)
        {
            SqlParameter[] _p = new SqlParameter[2];
            _p[0] = new SqlParameter("@Hearing_ID", @Hearing_ID);
            _p[1] = new SqlParameter("@Matter_number", SqlDbType.VarChar);
            _p[1].Size = 200;
            _p[1].Direction = ParameterDirection.Output;

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_GetMatterNObyhearingID", _p));
            @Matter_number = (string)_p[1].Value;
            return i;



        }

        #endregion
        
    }
}
