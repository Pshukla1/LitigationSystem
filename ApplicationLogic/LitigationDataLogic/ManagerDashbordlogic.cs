using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LitigationDataLogic
{
    public class ManagerDashboardlogic
    {

        #region   *********************************Manager Stats*************************************************
        public DataSet GetStats_English(int EMP_ID)
        {
            string sql = "select  MATTER# =(select COUNT(*) as TOTAL_ACTIVE_MATTER ";
            sql = sql + "from Matters M where m.Matter_status_ID=1 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL ACTIVE MATTER' ";
            sql = sql + "union ";
            sql = sql + "select MATTER# = (select COUNT(*) as TOTAL_WON from Matters M where m.Matter_status_ID=1  ";
            sql = sql + "and m.Final_Judgement_ID = 1 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL WON' ";
            sql = sql + "union ";
            sql = sql + "select MATTER#   =(select COUNT(*) as TOTAL_LOST from Matters M where m.Matter_status_ID=1 ";
            sql = sql + "and m.Final_Judgement_ID = 2 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL LOST' ";
            sql = sql + "union ";
            sql = sql + "select MATTER#  =(select COUNT(*) as TOTAL_LOST from Matters M where m.Matter_status_ID=1 ";
            sql = sql + "and m.Final_Judgement_ID != 0 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL JUDGEMENT' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        public DataSet GetStats_Arabic(int EMP_ID)
        {
            string sql = "select  MATTER# =(select COUNT(*) as TOTAL_ACTIVE_MATTER ";
            sql = sql + "from Matters M where m.Matter_status_ID=1 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL ACTIVE MATTER' ";
            sql = sql + "union ";
            sql = sql + "select MATTER# = (select COUNT(*) as TOTAL_WON from Matters M where m.Matter_status_ID=1  ";
            sql = sql + "and m.Final_Judgement_ID = 1 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL WON' ";
            sql = sql + "union ";
            sql = sql + "select MATTER#   =(select COUNT(*) as TOTAL_LOST from Matters M where m.Matter_status_ID=1 ";
            sql = sql + "and m.Final_Judgement_ID = 2 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL LOST' ";
            sql = sql + "union ";
            sql = sql + "select MATTER#  =(select COUNT(*) as TOTAL_LOST from Matters M where m.Matter_status_ID=1 ";
            sql = sql + "and m.Final_Judgement_ID != 0 and m.Responsibale_Lawyer_ID = 1),TOTAL='TOTAL JUDGEMENT' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        #endregion

        #region   *********************************CAse Vs Courts*************************************************
        public DataSet GetCasebyCourt_English(int EMP_ID)
        {
            string sql = "select COUNT(Court_Id) as TOT ,court_name='Ajman penalty' from Cases C ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =1 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Alasitnavah' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =2 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Rethink' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =3 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Appellate unions' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =4 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Dubai primary' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =5 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        public DataSet GetCasebyCourt_Arabic(int EMP_ID)
        {
            string sql = "select COUNT(Court_Id) as TOT ,court_name='Ajman penalty' from Cases C ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =1 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Alasitnavah' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =2 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Rethink' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =3 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Appellate unions' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID)  ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =4 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            sql = sql + "union ";
            sql = sql + "select COUNT(Court_Id) as TOT ,court_name='Dubai primary' from Cases C  ";
            sql = sql + "inner join Stages S on (c.Stage_ID = S.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id)  ";
            sql = sql + "where C.Court_Id =5 and M.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        #endregion

        #region   *********************************Lawyer Vs Matter*************************************************
        public DataSet GetMatterbyLawyer_English(int EMP_ID)
        {
            string sql = "select  distinct TotActiveMatter =(select COUNT (m.Matter_ID) from Matters M  where EMP.Employee_Id = M.Assigned_lawyer_ID  group by Assigned_lawyer_ID), EMP.UserName from Matters M  ";
            sql = sql + "inner join Employess EMP on (EMP.Employee_Id = M.Assigned_lawyer_ID) ";
            sql = sql + "where m.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        public DataSet GetMatterbyLawyer_Arabic(int EMP_ID)
        {
            string sql = "select  distinct TotActiveMatter =(select COUNT (m.Matter_ID) from Matters M  where EMP.Employee_Id = M.Assigned_lawyer_ID  group by Assigned_lawyer_ID), EMP.UserName_ar as  UserName from Matters M  ";
            sql = sql + "inner join Employess EMP on (EMP.Employee_Id = M.Assigned_lawyer_ID) ";
            sql = sql + "where m.Responsibale_Lawyer_ID = '" + EMP_ID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql);
        }
        #endregion

        #region   *********************************UPCOMING HEARINGS *************************************************
        public DataTable GetupcomingHearings_English(int EMP_ID)
        {
            string sql = "SELECT distinct H.Hearing_ID , c.Case_ID, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ,";
            sql = sql + " Matter_number = ((SELECT M.Matter_number  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) , ";
            sql = sql + " Matter_ID = ((SELECT M.Matter_ID  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) ";
            sql = sql + " FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " H.Hearing_Staus_Id = 1 ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";


            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetupcomingHearings_Arabic(int EMP_ID)
        {
            string sql = "SELECT distinct H.Hearing_ID , c.Case_ID, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ,";
            sql = sql + " Matter_number = ((SELECT M.Matter_number  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) , ";
            sql = sql + " Matter_ID = ((SELECT M.Matter_ID  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) ";
            sql = sql + " FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " H.Hearing_Staus_Id = 1 ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *********************************UPCOMING HEARINGS BY MATTER ID *************************************************
        public DataTable GetupcomingHearings_English_Matter(int EMP_ID, int MATTER_ID)
        {
            string sql = "SELECT distinct H.Hearing_ID , c.Case_ID, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ,";
            sql = sql + " Matter_number = ((SELECT M.Matter_number  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) , ";
            sql = sql + " Matter_ID = ((SELECT M.Matter_ID  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) ";
            sql = sql + " FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " H.Hearing_Staus_Id = 1 ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            sql = sql + "and m.Matter_ID ='" + MATTER_ID + "' ";


            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetupcomingHearings_Arabic_Matter(int EMP_ID, int MATTER_ID)
        {
            string sql = "SELECT distinct H.Hearing_ID , c.Case_ID, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ,";
            sql = sql + " Matter_number = ((SELECT M.Matter_number  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) , ";
            sql = sql + " Matter_ID = ((SELECT M.Matter_ID  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) ";
            sql = sql + " FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " H.Hearing_Staus_Id = 1 ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            sql = sql + "and m.Matter_ID ='" + MATTER_ID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *********************************Unprepared Pleadings*************************************************
        public DataTable GetUnpreparedPleadings_English(int EMP_ID)
        {
            string sql = "(SELECT distinct c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "')AND P.Pleading_status_id ='2' )";

            //sql = sql + "  EXCEPT  ";

            //sql = sql + " (SELECT distinct c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            //sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            //sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            //sql = sql + " inner join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            //sql = sql + " inner join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            //sql = sql + " inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            //sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            //sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            //sql = sql + " WHERE ";
            //sql = sql + " Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            //sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') )";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetUnpreparedPleadings_Arabic(int EMP_ID)
        {
            string sql = "(SELECT distinct c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "')AND P.Pleading_status_id ='2' )";

            //sql = sql + "  EXCEPT  ";

            //sql = sql + " (SELECT distinct c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            //sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            //sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            //sql = sql + " inner join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            //sql = sql + " inner join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            //sql = sql + " inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            //sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            //sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            //sql = sql + " WHERE ";
            //sql = sql + " Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            //sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') )";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *********************************Unprepared Pleadings FOR MATTER ID*************************************************
        public DataTable GetUnpreparedPleading_English(int Matter_ID)
        {
            string sql = "(SELECT distinct m.Matter_ID,c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " WHERE ";
            sql = sql + "  m.Matter_ID ='" + Matter_ID + "' AND P.Pleading_status_id ='2' ) ";

            //sql = sql + "  EXCEPT  ";

            //sql = sql + " (SELECT distinct m.Matter_ID, c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            //sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            //sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            //sql = sql + " inner join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            //sql = sql + " inner join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            //sql = sql + " inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            //sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            //sql = sql + " WHERE ";
            //sql = sql + " Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            //sql = sql + " AND m.Matter_ID ='" + Matter_ID + "' ) ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetUnpreparedPleading_Arabic(int Matter_ID)
        {
            string sql = "(SELECT distinct m.Matter_ID,c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " WHERE ";
            sql = sql + "  m.Matter_ID ='" + Matter_ID + "' AND P.Pleading_status_id ='2' ) ";
            //sql = sql + "  EXCEPT  ";

            //sql = sql + " (SELECT distinct m.Matter_ID, c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            //sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            //sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            //sql = sql + " inner join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            //sql = sql + " inner join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            //sql = sql + " inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            //sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            //sql = sql + " WHERE ";
            //sql = sql + " Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            //sql = sql + " AND m.Matter_ID ='" + Matter_ID + "' )";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *********************************Unprepared Pleadings FOR CASE ID*************************************************
        public DataTable GetUnpreparedPleading_Case_English(int CASE_ID)
        {
            string sql = "(SELECT distinct m.Matter_ID,c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " WHERE ";
            sql = sql + " c.Case_ID ='" + CASE_ID + "' AND P.Pleading_status_id ='2' )";

            //sql = sql + "  EXCEPT  ";

            //sql = sql + " (SELECT distinct m.Matter_ID, c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            //sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            //sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            //sql = sql + " inner join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            //sql = sql + " inner join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            //sql = sql + " inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            //sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            //sql = sql + " WHERE ";
            //sql = sql + " Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            //sql = sql + " AND c.Case_ID ='" + CASE_ID + "' ) ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetUnpreparedPleadings_Case_Arabic(int CASE_ID)
        {
            string sql = "(SELECT distinct m.Matter_ID,c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " WHERE ";
            sql = sql + " c.Case_ID ='" + CASE_ID + "' AND P.Pleading_status_id ='2' )";

            //sql = sql + "  EXCEPT  ";

            //sql = sql + " (SELECT distinct m.Matter_ID, c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ";
            //sql = sql + " ,DATEADD(day, -2, Hearing_date) as Last_date FROM   Hearings H ";
            //sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            //sql = sql + " inner join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            //sql = sql + " inner join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            //sql = sql + " inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            //sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            //sql = sql + " WHERE ";
            //sql = sql + " Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            //sql = sql + " AND c.Case_ID ='" + CASE_ID + "' )";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *********************************DropdownListBind*************************************************
        public DataTable MatterNumber()
        {

            string sql = "select  Matter_ID, Matter_number from Matters ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable CaseNumber()
        {

            string sql = "select  Case_ID, Case_number from Cases ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable StausEnglish()
        {

            string sql = "select Satus_id,Staus_Desc as  Staus_Desc from Statuses ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable StausArabic()
        {

            string sql = "select Satus_id,Staus_Desc_ar as  Staus_Desc from Statuses";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable PartyArabic()
        {

            string sql = "select Party_ID,Company_Name_ar  as Company_Name from Parties";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable PartyEnglish()
        {

            string sql = "select Party_ID,Company_Name  as Company_Name from Parties";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *********************************Search FOr MatterGrid BY MATTERID,CASEID AND CLIENTID************************


        public DataTable GetAllMatterView_MatterID_English(int MatterID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID, H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "'  ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_MatterID_Arabic(int MatterID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "'  ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_MatterID_Caseid_English(int MatterID, int CaseID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "' AND C.Case_ID='" + CaseID + "'   ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];

        }
        public DataTable GetAllMatterView_MatterID_Caseid_Arabic(int MatterID, int CaseID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "' AND C.Case_ID='" + CaseID + "'   ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_MatterID_Caseid_PartyID_English(int MatterID, int CaseID, int PID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + "inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "' AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_MatterID_Caseid_PartyID_Arabic(int MatterID, int CaseID, int PID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "' AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_MatterID_Caseid_PartyID_Status_English(int MatterID, int CaseID, int PID, int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "' AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_MatterID_Caseid_PartyID_Status_Arabic(int MatterID, int CaseID, int PID, int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID, H.Hearing_ID,c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "and M.Matter_ID ='" + MatterID + "' AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetAllMatterView_Status_English(int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID, H.Hearing_ID,c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_Status_Arabic(int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_PartyID_Status_English(int PID, int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_PartyID_Status_Arabic(int PID, int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_Caseid_PartyID_Status_English(int CaseID, int PID, int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID, H.Hearing_ID,c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_Caseid_PartyID_Status_Arabic(int CaseID, int PID, int SID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID, H.Hearing_ID,c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "AND c.Status_ID='" + SID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetAllMatterView_PartyID_English(int PID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_PartyID_Arabic(int PID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_Caseid_PartyID_English(int CaseID, int PID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_Caseid_PartyID_Arabic(int CaseID, int PID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND C.Case_ID='" + CaseID + "' AND Mp.Party_ID ='" + PID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetAllMatterView_Caseid_English(int CaseID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND C.Case_ID='" + CaseID + "'   ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_Caseid_Arabic(int CaseID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number,h.Decision_Details,st.stage_type_desc,PA.Company_Name ";
            sql = sql + " ,Hearing_Date =  substring((SELECT top 2 ( '| ' +CONVERT(VARCHAR(10),ms2.Hearing_date,105)) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000), ";
            sql = sql + "Hearing_Notes = substring((SELECT  top 2  ( '| ' + ms2.Hearings_Notes) FROM Hearings ms2 ";
            sql = sql + "where C.Case_ID = ms2.Case_ID order by ms2.Hearing_ID desc ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000) ";
            sql = sql + "FROM   Hearings H ";
            sql = sql + "inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + "inner join Stages S on (c.Stage_ID = c.Stage_ID ) ";
            sql = sql + "inner join Stage_Types ST on (st.stage_type_id = c.Stage_ID) ";
            sql = sql + "inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + "WHERE ";
            sql = sql + "Hearing_date = (SELECT MAX(Hearing_date) FROM Hearings WHERE Case_ID = H.Case_ID) ";
            sql = sql + "AND C.Case_ID='" + CaseID + "'   ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetupcomingHearing_Case_English(int Matter_ID, int CaseID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ,";
            sql = sql + " Matter_number = ((SELECT M.Matter_number  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) , ";
            sql = sql + " Matter_ID = ((SELECT M.Matter_ID  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) ";
            sql = sql + " FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " H.Hearing_Staus_Id = 1 ";
            sql = sql + " AND m.Matter_ID ='" + Matter_ID + "' AND C.Case_ID ='" + CaseID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetupcomingHearing_Case_Arabic(int Matter_ID, int CaseID, int EMP_ID)
        {
            string sql = "SELECT distinct m.Matter_ID,H.Hearing_ID, c.Case_ID,m.Matter_number, c.Case_number, Hearing_date,Hearings_Notes,ps.Pleading_status_desc_en ,";
            sql = sql + " Matter_number = ((SELECT M.Matter_number  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) , ";
            sql = sql + " Matter_ID = ((SELECT M.Matter_ID  FROM Matters M WHERE M.Matter_ID = S.Matter_Id AND  s.Stage_ID = c.Stage_ID AND(C.Case_ID = H.Case_ID))) ";
            sql = sql + " FROM   Hearings H ";
            sql = sql + " inner join Cases C on (C.Case_ID = H.Case_ID) ";
            sql = sql + " left join Pleadings P on (p.Hearing_ID = h.Hearing_ID) ";
            sql = sql + " left join Pleading_Status PS on(ps.Pleadings_Status_ID = p.Pleading_status_id) ";
            sql = sql + " inner join Stages S on (c.Stage_ID = S.Stage_ID ) ";
            sql = sql + " inner join Matters M on (m.Matter_ID = s.Matter_Id) ";
            sql = sql + " inner join Fallowers F on (f.Matter_Id = m.Matter_ID) ";
            sql = sql + " WHERE ";
            sql = sql + " H.Hearing_Staus_Id = 1 ";
            sql = sql + " AND m.Matter_ID ='" + Matter_ID + "' AND C.Case_ID ='" + CaseID + "' ";
            sql = sql + "and (M.Assigned_lawyer_ID ='" + EMP_ID + "' or m.Responsibale_Lawyer_ID='" + EMP_ID + "' or f.Employee_Id='" + EMP_ID + "') ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=9 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Get Matter ID*************************
        public DataTable MatterIDbyMatterNUmber(string MatterNo)
        {
            string sql = "select Matter_ID from matters where Matter_number='" + MatterNo + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************GET MATTER NUMBER FROM CASE*********************************************

        public int GetCaseID(int @Hearing_ID, out string @CaseID)
        {
            SqlParameter[] _p = new SqlParameter[2];
            _p[0] = new SqlParameter("@Hearing_ID", @Hearing_ID);
            _p[1] = new SqlParameter("@CaseID", SqlDbType.VarChar);
            _p[1].Size = 200;
            _p[1].Direction = ParameterDirection.Output;

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_GetCaseIDbyhearingID", _p));
            @CaseID = (string)_p[1].Value;
            return i;



        }

        #endregion
    }
}

