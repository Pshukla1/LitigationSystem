using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LitigationDataLogic
{
    public class ReportsLogic
    {
        public DataTable PrintMaterListEnglish()
        {
            string sql = "select M.Matter_number,emp.UserName AS Assigned, EMP1.UserName Supervier,mt.Matter_Type_Desc, ";
            sql = sql + "st.Staus_Desc ,sg.stage_type_desc ";
            sql = sql + "from Matters M ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id) ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id) ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID) ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID) ";
            sql = sql + "left join Stages S on(s.Matter_Id = m.Matter_ID) ";
            sql = sql + "left join Stage_Types SG on (sg.stage_type_id = S.Stage_Type_ID)  ";
            sql = sql + "order by s.stage_type_id ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }

        public DataTable PrintMaterListArabic()
        {
            string sql = "select M.Matter_Id,M.Matter_number,emp.UserName_ar AS Assigned, EMP1.UserName_ar Supervier,mt.Matter_Type_Desc_ar as Matter_Type_Desc, ";
            sql = sql + "st.Staus_Desc_ar as Staus_Desc  ,sg.stage_type_desc_ar as stage_type_desc ";
            sql = sql + "from Matters M ";
            sql = sql + "inner join Employess EMP on(M.Assigned_lawyer_ID=emp.Employee_Id) ";
            sql = sql + "inner join Employess EMP1 on(m.Responsibale_Lawyer_ID = EMP1.Employee_Id) ";
            sql = sql + "inner join Matter_Types MT on (mt.Matter_Type_Id = m.Matter_Type_ID) ";
            sql = sql + "inner join Statuses ST on (st.Satus_id = m.Matter_status_ID) ";
            sql = sql + "left join Stages S on(s.Matter_Id = m.Matter_ID) ";
            sql = sql + "left join Stage_Types SG on (sg.stage_type_id = S.Stage_Type_ID)  ";
            sql = sql + "order by s.stage_type_id ";
            return SqlDataAccess.ExecuteDataset(SqlDataAccess.ConnectionString, CommandType.Text, sql).Tables[0];
        }
    }
}
