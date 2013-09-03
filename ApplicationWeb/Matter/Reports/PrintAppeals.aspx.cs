#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    20.06.13                        Praveen Shukla                                print Matter Report

#endregion

#region   ********  NameSpace  *************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Udev.MasterPageWithLocalization.Classes;
using LitigationDataLogic;
using LitigationClearkLogic;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.IO;

#endregion

#region   ********Page Controls *************************
public partial class PrintMatter : System.Web.UI.Page
{
    ReportsLogic RL = new ReportsLogic();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {


        bindReport();
        
    }

    private void bindReport()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = RL.PrintMaterListEnglish();
        }
        else
        {
            dt = RL.PrintMaterListEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("..//..//Reports//PrintAllMatter.rpt"));
            report.SetDataSource(dt);
            // report.Refresh();
            //CrystalReportViewer1.ReportSource = report;
            MemoryStream oStream = new MemoryStream(); // using System.IO 
            oStream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear(); Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(oStream.ToArray());
            Response.End();
        }
    }
}
#endregion