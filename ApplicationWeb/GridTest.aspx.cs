using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LitigationClearkLogic;
using LitigationDataLogic;

public partial class GridTest : System.Web.UI.Page
{
    CaseDetails SV = new CaseDetails();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = Filldt();
            GridView1.DataBind();
        }
    }

    #region VIEW STATE
    private DataTable Filldt()
    {

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Case_number", typeof(string)));
        dt.Columns.Add(new DataColumn("Case_Type_desc", typeof(string)));
        dt.Columns.Add(new DataColumn("Staus_Desc", typeof(string)));
        dt.Columns.Add(new DataColumn("stage_type_desc", typeof(string)));
        dt.Columns.Add(new DataColumn("Registration_Date", typeof(string)));
        dt.Columns.Add(new DataColumn("End_date", typeof(string)));
        dt.Columns.Add(new DataColumn("GroupNumber", typeof(string)));
        DataTable td = new DataTable();
        td = SV.CaseGridEnglish();

        if (td.Rows.Count > 0)
        {
            for (int i = 0; i < td.Rows.Count; i++)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr[0] = td.Rows[i]["Case_number"];
                dr[1] = td.Rows[i]["Case_Type_desc"];
                dr[2] = td.Rows[i]["Staus_Desc"];
                dr[3] = td.Rows[i]["stage_type_desc"];
                dr[4] = td.Rows[i]["Registration_Date"];
                dr[5] = td.Rows[i]["End_date"];
                dr[6] = td.Rows[i]["GroupNumber"];
                dt.Rows.Add(dr);

            }

        }
        return dt;

    }
    #endregion
}