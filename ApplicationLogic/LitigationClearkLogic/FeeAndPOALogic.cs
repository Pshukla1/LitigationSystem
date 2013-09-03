using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationClearkLogic
{
    public class FeeAndPOALogic
    {
        #region *******************************Matter Gird FOR POAS**********************************************
        public DataTable MatterView()
        {
            string sql = " select M.Matter_Id,M.Matter_number,emp.UserName AS AssignedLawyer,m.Open_date, ";
            sql = sql + "EMP1.UserName ResponsibileLawyer,mt.Matter_Type_Desc, st.Staus_Desc ,pa.Company_Name as Clientname ";
            sql = sql + "from Matters M  ";
            sql = sql + "left join Matter_Parties MP on(mp.Matter_ID =m.Matter_ID and mp.Role_ID=1)  ";
            sql = sql + "left join Parties PA on(PA.Party_ID = mp.Matter_ID )  ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id) ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id)";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID)  ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID) ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Add POAs**********************************************

        public int AddPoas(int @Party_ID, int @POA_Type_ID, int @POA_Issue_Location, string @Notes, DateTime @Issue_date, string @Mode)
        {
            SqlParameter[] _p = new SqlParameter[6];
            _p[0] = new SqlParameter("@Party_ID", @Party_ID);
            _p[1] = new SqlParameter("@POA_Type_ID", @POA_Type_ID);
            _p[2] = new SqlParameter("@POA_Issue_Location", @POA_Issue_Location);
            _p[3] = new SqlParameter("@Notes", @Notes);
            _p[4] = new SqlParameter("@Issue_date", @Issue_date);
            _p[5] = new SqlParameter("@Mode", @Mode);

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AddPOAs", _p));
            return i;

        }

        #endregion

        #region *******************************Add Fee Details**********************************************

        public int AddFeedetails(int @Matter_ID, int @ClaimAmount, int @Sucess_Fees, string @Fee_details, string @Fees_Estimate, string @Fees_Document, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[7];
            _p[0] = new SqlParameter("@Matter_ID", @Matter_ID);
            _p[1] = new SqlParameter("@ClaimAmount", @ClaimAmount);
            _p[2] = new SqlParameter("@Sucess_Fees", @Sucess_Fees);
            _p[3] = new SqlParameter("@Fee_details", @Fee_details);
            _p[4] = new SqlParameter("@Fees_Estimate", @Fees_Estimate);
            _p[5] = new SqlParameter("@Fees_Document", @Fees_Document);
            _p[6] = new SqlParameter("@Mode", @Mode);

            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AddFeeDetails", _p));
            return i;

        }

        #endregion

        #region *******************************Bind POA LOCATION AND POAS TYPE**********************************************

        public DataTable Location_English()
        {
            string sql = "select Location_id, Location_desc as Location_desc  from POA_Issue_Location";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Location_Arebic()
        {
            string sql = "select Location_id, Location_desc_ar as Location_desc  from POA_Issue_Location";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable POATYPE_English()
        {
            string sql = "select Poa_Type_Id,Poa_Types_desc as Poa_Types_desc from POA_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable POATYPE_Arebic()
        {
            string sql = "select Poa_Type_Id,Poa_Types_desc_ar AS Poa_Types_desc from POA_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion

        #region *******************************GetPartyID**********************************************
        public DataTable PartyID( int MatterID)
        {
            string sql = "select Party_ID from Matter_Parties where Role_ID=1 and Matter_ID='" + MatterID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Bind POA GRID**********************************************

        public DataTable POAGRID_English(int Matter_ID)
        {
            string sql = "select p.POA_id, pt.Poa_Types_desc as Poa_Types_desc,p.Issue_date,pil.Location_desc as Location_desc,p.Notes from POAs P ";
            sql = sql + "inner join POA_Types PT on (p.POA_Type_ID = pt.Poa_Type_Id) ";
            sql = sql + "inner join POA_Issue_Location PIL on (pil.Location_id = p.POA_Issue_Location) ";
            sql = sql + "inner join Parties PA on(pa.Party_ID = p.Party_ID) ";
            sql = sql + "inner join Matter_Parties MP on(mp.Party_ID = Pa.Party_ID) ";
            sql = sql + "and mp.Matter_ID ='" + Matter_ID + "' and mp.Role_ID=1 ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable POAGRID_Arebic(int Matter_ID)
        {
            string sql = "select p.POA_id, pt.Poa_Types_desc_ar as Poa_Types_desc,p.Issue_date,pil.Location_desc_ar as Location_desc,p.Notes from POAs P";
            sql = sql + "inner join POA_Types PT on (p.POA_Type_ID = pt.Poa_Type_Id) ";
            sql = sql + "inner join POA_Issue_Location PIL on (pil.Location_id = p.POA_Issue_Location) ";
            sql = sql + "inner join Parties PA on(pa.Party_ID = p.Party_ID) ";
            sql = sql + "inner join Matter_Parties MP on(mp.Party_ID = Pa.Party_ID) ";
            sql = sql + "and mp.Matter_ID ='" + Matter_ID + "' and mp.Role_ID=1 ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable GetFeeDetails(int Matter_ID)
        {
            string sql = "select Sucess_Fees,ClaimAmount,Fees_Estimate,Fee_details,Fees_Document from Matters where Matter_ID='" + Matter_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=6 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion
    }
}
