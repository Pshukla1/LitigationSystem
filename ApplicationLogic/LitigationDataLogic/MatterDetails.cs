using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace LitigationDataLogic
{
    public class MatterDetails
    {

        #region   *******DropdownList Bindings*************************
        public DataTable GetAllMatterView(string Matter_ID)
        {
            string sql = "SELECT O.Matter_Id,O.Matter_number,PS.Company_Name,PS.Fisrt_Name ,ES.UserName As   RLAWYER,stage_type_desc,HE.Hearing_Date,HE.Hearing_Notes,(SELECT ES.UserName FROM Employess ES WHERE O.Responsiable_Lawyer_Id = ES.Employee_Id) AS EMP2 ";
            sql = sql + "FROM Matters as O ";
            sql = sql + " INNER JOIN Persons PS ON (O.Client_Id = PS.Person_Id)";
            sql = sql + "INNER JOIN Employess ES ON(O.Assigned_Lawyer_Id = ES.Employee_Id)";
            sql = sql + "INNER JOIN Stages S ON (s.Matter_Id = o.Matter_Id)";
            sql = sql + "INNER JOIN Stage_Types ST ON (ST.stage_type_id = s.Stage_ID)";
            sql = sql + "INNER JOIN Cases CS ON(CS.Stage_ID = S.Stage_Id)";
            sql = sql + "INNER JOIN Hearings HE ON (CS.Case_Id = HE.Case_Id)";
            sql = sql + "WHERE o.Matter_Id= '" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetSpecficSearch(string Matter_ID)
        {
            string sql = "select M.Matter_Id,m.Matter_Number,(select pty.Company_Name where p.Role_Id='1' ) as Company_Name,Mt.Matter_Type_Desc ,EMP.UserName AS AssignedLawyer,M.open_date, ";
            sql = sql + "m.Description,(select pty.Company_Name where p.Role_Id='2' ) as Oppnents, OFFC.Office_Desc_En as offc_desc , ";
            sql = sql + "(SELECT EMP.UserName FROM Employess EMP WHERE M.Responsibale_Lawyer_ID = EMP.Employee_Id) AS ResponsibileLawyer,st.Staus_Desc from Matters M ";
            sql = sql + "inner join Matter_Types MT on (m.Matter_Type_ID = mt.Matter_Type_Id) ";
            sql = sql + "inner join Employess EMP  on(m.Assigned_Lawyer_ID= emp.Employee_Id) ";
            sql = sql + "inner join Statuses ST  on(m.Matter_Status_id= st.Satus_id) ";
            sql = sql + "INNER JOIN Offices OFFC ON(M.office_id = OFFC.Office_ID) ";
            sql = sql + "INNER JOIN Matter_Parties P ON (P.Matter_Id = M.Matter_ID) ";
            sql = sql + " INNER JOIN Parties PTY ON (PTY.Party_ID = P.Party_Id)  ";
            sql = sql + "where M.Matter_Id = '" + Matter_ID + "' order by company_name desc";


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

        public DataTable GetAllStagesArebic()
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
        public DataTable GetAllOfficArebic()
        {
            string sql = "select Office_ID, Office_Desc_AR as offc_desc   from Offices";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetMTYPEEnglish()
        {
            string sql = "select Matter_Type_Id, Matter_Type_Desc as Matter_Type_Desc   from  Matter_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetMTYPEArebic()
        {
            string sql = "select Matter_Type_Id, Matter_Type_Desc_ar as Matter_Type_Desc   from  Matter_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Case Mattes*************************
        public DataTable Case_MatterView(string Matter_ID)
        {
            string sql = " SELECT o.Matter_Id,o.Matter_number, stage_type_desc as CURRENT_STAGE, CS.case_number as NUMBER,STA.Staus_Desc AS STATUS,CONVERT(VARCHAR(10),HE.Hearing_Date,110)AS NEXT_HEARING,HE.Hearings_Notes AS HERAING_DESP ";
            sql = sql + " , cs.Case_ID,He.Hearing_ID,HS.staus_desc FROM Matters as O ";
            sql = sql + "INNER JOIN Stages S ON (s.Matter_Id = o.Matter_Id) ";
            sql = sql + "INNER JOIN Stage_Types ST ON (ST.stage_type_id = s.Stage_Type_ID) ";
            sql = sql + "INNER JOIN Cases CS ON(CS.Stage_ID = S.Stage_Id) ";
            sql = sql + "INNER JOIN Hearings HE ON (CS.Case_Id = HE.Case_Id) ";
            sql = sql + "INNER join Hearing_status HS on(hs.status_id =he.Hearing_Staus_Id)";
            sql = sql + "INNER JOIN Statuses STA ON (S.Status_Id = STA.Satus_id) ";
            sql = sql + "WHERE o.Matter_Id= '" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Chart Data*************************
        public DataSet Chart_Data(string Matter_ID)
        {
            string sql = "select COUNT(*) as count ,stagetype='First Instance' from Cases C ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "where S.Stage_Type_ID =1 and M.Matter_ID ='" + Matter_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(*) as count ,stagetype='Appeal' from Cases C ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "where  S.Stage_Type_ID =2 and M.Matter_ID ='" + Matter_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(*) as count ,stagetype='Cassation' from Cases C ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "where  S.Stage_Type_ID =3 and M.Matter_ID = '" + Matter_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(*) as count ,stagetype='Execution' from Cases C ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "where  S.Stage_Type_ID =4 and M.Matter_ID ='" + Matter_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(*) as count ,stagetype='Preliminary' from Cases C ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "where S.Stage_Type_ID =5 and M.Matter_ID ='" + Matter_ID + "' ";
            //string sql = "SELECT st.stage_type_desc , s.actual_effort,s.weighting,s.exp_start_date,s.exp_end_date,s.Open_Date,s.Close_Date from Stages S ";
            //sql = sql + "inner join Stage_Types ST on ( st.stage_type_id = S.Stage_Id)";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        #endregion

        #region   *******Rights Information*************************
        public DataTable RightsDetails()
        {
            string sql = "select Page_action from  Page_action where Page_Id='1' and EMP_id='1'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Opponent Details*************************

        public DataTable OpponentDetails(string Matter_id)
        {
            string sql = "SELECT P.Company_Name  FROM  Parties P INNER JOIN Matter_Parties MP ON (MP.Party_Id = P.Party_ID) ";
            sql = sql + " WHERE MP.Role_Id = 2 and mp.Matter_Id ='" + Matter_id + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region   *******Fallower Grid*************************

        public DataTable FallowerGrid(int Matter_id)
        {
            string sql = "select F.FallowerID, M.Matter_number as Matter_ID ,E.UserName  as Employee_Id from Fallowers F ";
            sql = sql + "inner join Matters M on (m.Matter_ID= F.Matter_Id) ";
            sql = sql + "inner join Employess E on(E.Employee_Id= f.Employee_Id) where F.Matter_Id ='" + Matter_id + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region   *******Add Fallower Details*************************

        public int AddFallower(int @Employee_Id, int @Matter_Id, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[3];
            _p[0] = new SqlParameter("@Employee_Id", @Employee_Id);
            _p[1] = new SqlParameter("@Matter_Id", @Matter_Id);
            _p[2] = new SqlParameter("@Mode", @Mode);

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AddFallowerOpertaion", _p));
            return i;

        }

        #endregion

        #region   *******Delete Fallower Details*************************

        public int DeleteFallower(int @FallowerID, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[2];
            _p[0] = new SqlParameter("@FallowerID", @FallowerID);
            _p[1] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_DeleteFallowerOpertaion", _p));
            return i;

        }

        #endregion

        #region   *******Close Mattes Check*************************
        public DataTable ChkMatter(string Matter_ID)
        {
            string sql = "select * from Stages where Status_ID = 1 and Matter_Id= '" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=2 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

    }
}
