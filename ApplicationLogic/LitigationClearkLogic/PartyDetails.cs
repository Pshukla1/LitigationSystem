using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace LitigationClearkLogic
{
    public class PartyDetails
    {
        #region *******************************Matter Gird FOR party**********************************************
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
       
        public DataTable PartyDetails_English(int Matter_ID)
        {
            string sql = "select MP.P_ID,MP.Ranking, m.Matter_number,p.Company_Name,pt.Party_Type_Desc_En,rt.Role_Type_En from Matters M ";
            sql = sql + "inner join Matter_Parties MP on(m.Matter_ID= mp.Matter_Id) ";
            sql = sql + "inner join Party_Types PT on(pt.Party_Type_Id= mp.party_Type_Id) ";
            sql = sql + "inner join Roles_Party RT on(rt.Role_Id = mp.Role_Id)";
            sql = sql + "inner join Parties P on(p.Party_ID = mp.Party_Id)";
            sql = sql + " WHERE M.Matter_id= '" + Matter_ID + "' order by Ranking ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable PartyDetails_Arabic(int Matter_ID)
        {
            string sql = "select MP.P_ID ,MP.Ranking,m.Matter_number,p.Company_Name_ar as Company_Name,pt.Party_Type_Desc_Ar as Party_Type_Desc_En,rt.Role_Type_ar as Role_Type_En from Matters M ";
            sql = sql + "inner join Matter_Parties MP on(m.Matter_ID= mp.Matter_Id) ";
            sql = sql + "inner join Party_Types PT on(pt.Party_Type_Id= mp.party_Type_Id) ";
            sql = sql + "inner join Roles_Party RT on(rt.Role_Id = mp.Role_Id)";
            sql = sql + "inner join Parties P on(p.Party_ID = mp.Party_Id)";
            sql = sql + " WHERE M.Matter_id= '" + Matter_ID + "' order by Ranking ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion

        #region *******************************Dropdown**********************************************
        public DataTable Party_English()
        {
            string sql = "select Party_ID,Company_Name as Company_Name from Parties ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Party_Arabic()
        {
            string sql = "select Party_ID,Company_Name_ar as Company_Name from Parties";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable PartyType_English()
        {
            string sql = "select Party_Type_Id,Party_Type_Desc_En as Party_Type_Desc_En from Party_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable Partytype_Arabic()
        {
            string sql = "select Party_Type_Id,Party_Type_Desc_Ar AS Party_Type_Desc_En from Party_Types";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable PartyRole_English()
        {
            string sql = "select Role_Id,Role_Type_En as Role_Type_En from Roles_Party";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        public DataTable PartyRole_Arabic()
        {
            string sql = "select Role_Id,Role_Type_ar as Role_Type_En from Roles_Party";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
          #endregion

        #region *******************************Add Parties**********************************************

        public int AddParty(int @Matter_id, int @Party_ID, int @party_Type_Id, int @Role_Id,  int @Ranking,string @Mode)
        {
            SqlParameter[] _p = new SqlParameter[6];
            _p[0] = new SqlParameter("@Matter_id", @Matter_id);
            _p[1] = new SqlParameter("@Party_ID", @Party_ID);
            _p[2] = new SqlParameter("@party_Type_Id", @party_Type_Id);
            _p[3] = new SqlParameter("@Role_Id", @Role_Id);
            _p[4] = new SqlParameter("@Ranking", @Ranking);
            _p[5] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_AddParties", _p));
            return i;

        }

        #endregion

        #region   *******Delete Parties Details*************************

        public int DeleteParty(int @p_id, string @Mode)
        {

            SqlParameter[] _p = new SqlParameter[2];
            _p[0] = new SqlParameter("@p_id", @p_id);
            _p[1] = new SqlParameter("@Mode", @Mode);
            int i = Convert.ToInt32(SqlDataAccess.ExecuteNonQuery(SqlDataAccess.ConnectionString, CommandType.StoredProcedure, "Usp_DeletePartyOpertaion", _p));
            return i;

        }

        #endregion

        #region *******************************MAX RAnking**********************************************
        public DataTable OPPonentRank(int Matter_ID)
        {
            string sql = "select MAX(Ranking)+ 1 as RANK from Matter_Parties where Matter_Id='" + Matter_ID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
     
        #endregion

        #region *******************************ChkClient**********************************************
        public DataTable ChkClient(int Matter_ID,int Role)
        {
            string sql = "select Matter_Id from Matter_Parties where Role_Id ='" + Role + "'  and ranking =0 and Matter_Id='" + Matter_ID + "' ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        #endregion


        #region   *******Rights Information*************************
        public DataTable RightsDetails(int EMP_ID)
        {
            string sql = "SELECT ACTION FROM ACTIONS WHERE PAGEID=7 AND EMPID='" + EMP_ID + "'";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
        #endregion
    }
      

    

        
  
}
