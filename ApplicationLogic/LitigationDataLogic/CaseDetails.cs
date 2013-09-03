using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationDataLogic
{
    public class CaseDetails
    {

        #region**************************Gird Binding***********************
        public DataTable CaseGridEnglish()
        {
            string sql = "select c.Case_ID ,c.Case_number, ct.Case_Type_desc,sta.Staus_Desc,  ";
            sql = sql + "st.stage_type_desc,c.Registration_Date,c.End_date, ";
            sql = sql + "Hearing_Outcome_Desc_EN = substring((SELECT ( ' |  ' + ho.Hearing_Outcome_Desc_EN ) FROM Hearings ms2 ";
            sql = sql + "left outer join Hearings_outcome Ho on ms2.Hearing_Outcome_ID = ho.Hearing_outcome_ID ";
            sql = sql + "and c.Case_ID= ms2.Case_ID ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "from  Cases C ";
            sql = sql + "left join  Case_Types CT on ct.Case_Type_ID = c.Case_Type_ID ";
            sql = sql + "left join Stage_Types ST on st.stage_type_id = c.Stage_ID ";
            sql = sql + "left join Statuses STA on sta.Satus_id = c.Status_ID ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CaseGridArabic()
        {
            string sql = "select c.Case_ID ,c.Case_number, ct.Case_Type_desc,sta.Staus_Desc,  ";
            sql = sql + "st.stage_type_desc,c.Registration_Date,c.End_date, ";
            sql = sql + "Hearing_Outcome_Desc_EN = substring((SELECT ( ' |  ' + ho.Hearing_Outcome_Desc_EN ) FROM Hearings ms2 ";
            sql = sql + "left outer join Hearings_outcome Ho on ms2.Hearing_Outcome_ID = ho.Hearing_outcome_ID ";
            sql = sql + "and c.Case_ID= ms2.Case_ID ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "from  Cases C ";
            sql = sql + "left join  Case_Types CT on ct.Case_Type_ID = c.Case_Type_ID ";
            sql = sql + "left join Stage_Types ST on st.stage_type_id = c.Stage_ID ";
            sql = sql + "left join Statuses STA on sta.Satus_id = c.Status_ID ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region**************************DropDown Binding***********************
        public DataTable GetSpecficSearch(string Matter_ID)
        {
            string sql = "select Matter_Id,Matter_Number from Matters ";
            sql = sql + "where Matter_Id = '" + Matter_ID + "'";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
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

        public DataTable CasetypeArabic()
        {
            string sql = " select Case_Type_ID,Case_Type_Desc_ar as  Case_Type_desc from Case_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CasetypeEnglish()
        {
            string sql = " select Case_Type_ID, Case_Type_desc from Case_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable DepartmentArabic()
        {
            string sql = "select Department_ID, Department_name_AR as  Department_Name_EN from Departments";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable DepartmentEnglish()
        {
            string sql = " select Department_ID, Department_Name_EN from Departments";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable JudgeName_English()
        {
            string sql = "select judge_id,judge_name as  JudgeName  from Judges";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable JudgeName_Arabic()
        {
            string sql = "select judge_id,judge_name_ar as  JudgeName  from Judges";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CourtName_English()
        {
            string sql = "select court_id, court_name as  court  from Courts";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable CourtName_Arabic()
        {
            string sql = "select court_id, court_name_ar as  court  from Courts";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

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

        public DataTable GetAllEmployeeEnlish()
        {
            string sql = "select Employee_Id,UserName as UserName from Employess";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllEmployeeArebic()
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
        #endregion

        #region**************************Bind Case Details***********************
        public DataTable ClickCaseGrid(int Case_Id)
        {
            string sql = "select case_id, Case_number,Case_Type_ID,C.Status_ID,S.Stage_Type_ID,Registration_Date, ";
            sql = sql + "End_date, Court_Id,Court_Cleark_ID,Client_Capcity_ID,Opponents_Capcity_ID,Judge_Id, ";
            sql = sql + "Department_Id,Hall_number from Cases C ";
            sql = sql + "inner join Stages S on (s.Stage_ID =c.Stage_ID) ";
            sql = sql + "where Case_ID ='"+Case_Id+"' AND c.isdelete = 0 ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=4 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

    }
}
