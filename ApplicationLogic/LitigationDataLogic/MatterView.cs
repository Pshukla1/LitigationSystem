using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace LitigationDataLogic
{
    public class MatterView
    {

        #region *****************************Srarch Grid**********************************************
        public DataTable SearchGrid(string txtSeach)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + " where  m.Description like '%" + txtSeach + "%' or  PA.Company_Name like '%" + txtSeach + "%' ";
            sql = sql + " or m.Matter_Number like '%" + txtSeach + "%' ";


            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_Arabic()
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";

            //string sql = " select M.Matter_Id,m.Matter_Number,(select pty.Company_Name_ar where p.Role_Id='1' ) as Company_Name,Mt.Matter_Type_Desc_ar as Matter_Type_Desc  ,EMP.UserName_ar AS AssignedLawyer, ";
            //sql = sql + "(SELECT EMP.UserName_ar FROM Employess EMP WHERE M.Responsibale_Lawyer_ID = EMP.Employee_Id)";
            //sql = sql + " AS ResponsibileLawyer, st.Staus_Desc_ar as Staus_Desc, sg.stage_type_desc_ar as stage_type_desc,he.Hearing_date from Matters M ";
            //sql = sql + " INNER JOIN Matter_Parties P ON (P.Matter_Id = M.Matter_ID) ";
            //sql = sql + " INNER JOIN Parties PTY ON (PTY.Party_ID = P.Party_Id) ";
            //sql = sql + " inner join Matter_Types MT on (m.Matter_Type_ID = mt.Matter_Type_Id) ";
            //sql = sql + "inner join Employess EMP  on(m.Assigned_Lawyer_ID= emp.Employee_Id) ";
            //sql = sql + "inner join Statuses ST  on(m.Matter_Status_id= st.Satus_id)  ";
            //sql = sql + "left outer join Stages S on (s.Matter_Id = M.Matter_Id) ";
            //sql = sql + "left outer join Cases CS on (cs.stage_id = s.Stage_Id) ";
            //sql = sql + " left outer join Stage_Types SG  on (s.Stage_Type_ID = sg.stage_type_id) ";
            //sql = sql + " left outer join Hearings HE on (he.Case_ID = cs.Case_ID) ";

            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable GetAllMatterView_English()
        {
            //string sql = "select M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName ResponsibileLawyer,mt.Matter_Type_Desc, ";
            //sql = sql + "st.Staus_Desc ,sg.stage_type_desc,pa.Company_Name ";
            //sql = sql + "from Matters M ";

            //sql = sql + " left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1) ";
            //sql = sql + " left join Parties PA on(PA.Party_ID = mp.Matter_ID ) ";
            //sql = sql + " inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id) ";
            //sql = sql + " inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id) ";
            //sql = sql + " inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID) ";
            //sql = sql + " inner join Statuses ST on (st.Satus_id = m.Matter_status_ID) ";
            //sql = sql + " left join Stages S on(s.Matter_Id = m.Matter_ID) ";
            //sql = sql + " left join Stage_Types SG on (sg.stage_type_id = S.Stage_Type_ID) ";

            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";



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

        #region ****************Serach Codeing*******************************
        public DataTable AssignedLawyerSearch(string Assignedlawyer)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + " where   m.Assigned_Lawyer_ID ='" + Assignedlawyer + "'  ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable SupervisiorLawyerSearch(string Supelawyer)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + " where  M.Responsibale_Lawyer_ID ='" + Supelawyer + "'  ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterTypeSearch(string MatterTye)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where  m.Matter_Type_ID='" + MatterTye + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable StageSearch(string Stage)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where s.stage_type_desc like '%" + Stage + "%' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable StatusSearch(string Status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Matter_Status_id='" + Status + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable Assigned_superwiser_Matter_status(string Assigned, string superwiser, string Matter, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Assigned_Lawyer_ID='" + Assigned + "' and M.Responsibale_Lawyer_ID ='"+superwiser+"' and m.Matter_Type_ID='" + Matter + "' and m.Matter_Status_id='" + status + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Assigned_superwiser_Matter(string Assigned, string superwiser, string Matter)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Assigned_Lawyer_ID='" + Assigned + "' and M.Responsibale_Lawyer_ID ='" + superwiser + "' and m.Matter_Type_ID='" + Matter + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Assigned_superwiser(string Assigned, string superwiser)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + " where m.Assigned_Lawyer_ID='" + Assigned + "' and M.Responsibale_Lawyer_ID ='" + superwiser + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }


        public DataTable superwiser_Matter_status(string superwiser, string Matter, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where  M.Responsibale_Lawyer_ID ='" + superwiser + "' and m.Matter_Type_ID='" + Matter + "' and m.Matter_Status_id='" + status + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable superwiser_Matter(string superwiser, string Matter)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where  M.Responsibale_Lawyer_ID ='" + superwiser + "' and m.Matter_Type_ID='" + Matter + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable superwiser_status(string superwiser, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where  M.Responsibale_Lawyer_ID ='" + superwiser + "'  and m.Matter_Status_id='" + status + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable Assigned_Matter_status(string Assigned, string Matter, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Assigned_Lawyer_ID='" + Assigned + "'  and m.Matter_Type_ID='" + Matter + "' and m.Matter_Status_id='" + status + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Assigned_status(string Assigned, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + " where m.Assigned_Lawyer_ID='" + Assigned + "'  and m.Matter_Status_id='" + status + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Assigned_Matter(string Assigned, string Matter)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Assigned_Lawyer_ID='" + Assigned + "'  and m.Matter_Type_ID='" + Matter + "'  ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Matter_status(string matter, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Matter_Type_ID='" + matter + "' and  m.Matter_Status_id='" + status + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        public DataTable Assigned_Matter_stage(string Assigned, string Matter, string stage)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Assigned_Lawyer_ID='" + Assigned + "' and s.Stage_Id='" + stage + "' and m.Matter_Type_ID='" + Matter + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Assigned_Matter_stage_status(string Assigned, string Matter, string stage, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where m.Assigned_Lawyer_ID='" + Assigned + "' and s.stage_type_desc='%" + stage + "%' and m.Matter_Type_ID='" + Matter + "' and m.Matter_Status_id='" + status + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Matter_stage(string Matter, string Stage)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where s.stage_type_desc='%" + Stage + "%' and m.Matter_Type_ID='" + Matter + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Matter_stage_status(string Matter, string Stage, string status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "   where s.stage_type_desc='%" + Stage + "%' and m.Matter_Type_ID='" + Matter + "' and  m.Matter_Status_id='" + status + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable stage_status(string stage, string Status)
        {
            string sql = "select distinct M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer, EMP1.UserName  ";
            sql = sql + "ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,  ";
            sql = sql + "Company_Name =(select PA.Company_Name from Parties PA  where pa.Party_ID = mp.Party_ID and mp.Matter_ID =m.Matter_ID) , ";
            sql = sql + "stage_type_desc = substring((SELECT  ( '| ' + ms2.stage_type_desc ) FROM Stage_Types ms2   ";
            sql = sql + "right join Stages Ho on ms2.stage_type_id = ho.Stage_Type_ID  ";
            sql = sql + "and ho.Matter_Id = m.Matter_ID  ";
            sql = sql + "FOR XML PATH( '' )), 3, 1000)  ";
            sql = sql + "from Matters M    ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)    ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )    ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id)    ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)   ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)   ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID)  ";
            sql = sql + "  where s.stage_type_desc='%" + stage + "%' and  m.Matter_Status_id='" + Status + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region *************************Select Data for like wike**************************************
        public DataTable SelectLikeDataStatus(string Staus)
        {

            string sql = "select Satus_id,Staus_Desc as  Staus_Desc  from Statuses where  Staus_Desc like '" + Staus + "%'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable SelectLikeDataStage(string stage)
        {

            string sql = "select stage_type_id,stage_type_desc as  stage_type_desc from Stage_Types where stage_type_desc like '" + stage + "%'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable SelectLikeDataMatterType(string MatterType)
        {

            string sql = "select Matter_Type_Id, Matter_Type_Desc as Matter_Type_Desc   from  Matter_Types where Matter_Type_Desc like '" + MatterType + "%'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable SelectLikeDataAssignedLawyer(string AssignedLawyer)
        {

            string sql = "select Employee_Id,UserName as UserName from Employess where UserName like '" + AssignedLawyer + "%'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }


        #endregion

        #region *************************Get the MatterNo and MatterDetails**************************************

        public DataTable SelectLikeMatterNumber()
        {

            string sql = "select Matter_number from Matter_Details ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable MatterNumberFromMatter()
        {

            string sql = "select Matter_ID, Matter_number from Matters ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable UniqueMatterNo(string MatterNo)
        {

            string sql = "select Matter_number from Matters where Matter_number='" + MatterNo + "'  ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetMatterDetails(string Matter_Number)
        {

            string sql = "select m.Matter_ID,m.Matter_number,p.Company_Name,emp.UserName as REP,EMP1.UserName as Assigned,mt.Matter_Type_Desc,m.Date_Opend ,M.assigned_ID, m.superviser_ID,m.MatteType_ID,m.Client_Name   from Matter_Details M ";
            sql = sql + "inner join Parties P on (m.Matter_ID = p.Party_ID) ";
            sql = sql + "inner join Matter_Types MT on(mt.Matter_Type_Id = m.MatteType_ID) ";
            sql = sql + "inner join Employess EMP on (emp.Employee_Id = m.superviser_ID) ";
            sql = sql + "inner join Employess EMP1 on (EMP1.Employee_Id = m.assigned_ID) ";
            sql = sql + "where M.Matter_number= '" + Matter_Number + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable CloseMatterDetails(string Matter_Number)
        {

            string sql = "select m.Matter_ID,m.Matter_number,p.Company_Name,emp.UserName as REP,EMP1.UserName as Assigned,mt.Matter_Type_Desc,F.Office_Desc_En ,m.Open_date from Matters M ";
            sql = sql + "inner join Parties P on (m.Matter_ID = p.Party_ID) ";
            sql = sql + "inner join Matter_Types MT on(mt.Matter_Type_Id = m.Matter_Type_ID) ";
            sql = sql + "inner join Employess EMP on (emp.Employee_Id = m.Responsibale_Lawyer_ID) ";
            sql = sql + "inner join Employess EMP1 on (EMP1.Employee_Id = m.Assigned_lawyer_ID) ";
            sql = sql + "inner join Offices F on(F.OFFICE_ID = m.Office_ID)";
            sql = sql + "where M.Matter_number= '" + Matter_Number + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************MatterAction**********************************************

        public int MatterAction(string @Matter_Number, int @Client_ID, int @Responsibile_Lawyer_Id, int @Assigned_Lawyer_ID, int @Matter_Type_ID, DateTime @Open_date, string @Description, int @Office_ID, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[9];
            _p[0] = new SqlParameter("@Matter_Number", @Matter_Number);
            _p[1] = new SqlParameter("@Client_ID", @Client_ID);
            _p[2] = new SqlParameter("@Responsibile_Lawyer_Id", @Responsibile_Lawyer_Id);
            _p[3] = new SqlParameter("@Assigned_Lawyer_ID", @Assigned_Lawyer_ID);
            _p[4] = new SqlParameter("@Matter_Type_ID", @Matter_Type_ID);
            _p[5] = new SqlParameter("@Open_date", @Open_date);
            _p[6] = new SqlParameter("@Description", @Description);
            _p[7] = new SqlParameter("@Office_ID", @Office_ID);
            _p[8] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_MatterOperation", _p));
            return i;

        }
        public int MatterClose(string @Matter_Number, int @Matter_status_ID, string @Mode, out string @parameter2)
        {

            SqlParameter[] _p = new SqlParameter[4];
            _p[0] = new SqlParameter("@Matter_Number", @Matter_Number);
            _p[1] = new SqlParameter("@Matter_status_ID", @Matter_status_ID);
            _p[2] = new SqlParameter("@Mode", @Mode);
            _p[3] = new SqlParameter("@parameter2",SqlDbType.VarChar);
            _p[3].Size = 200;
            _p[3].Direction = ParameterDirection.Output;
            //int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_CloseMatter", _p));
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_CloseMatterwithchk", _p));
             @parameter2 = (string)_p[3].Value;
             return i;

        }

        #endregion

        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=1 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion
    }
}
