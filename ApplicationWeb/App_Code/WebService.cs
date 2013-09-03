using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using System.Data.SqlClient;
using LitigationDataLogic;
/// <summary>
/// Summary description for WebService
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]


public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    #region ***********************WebServices*******************

    [WebMethod]
    public string[] GetStaus(string prefixText, int count)
    {
        MatterView BEL = new MatterView();
        DataTable dt = BEL.SelectLikeDataStatus(prefixText.ToUpper());

        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            //String From DataBase(dbValues)
            dbValues = row["Staus_Desc"].ToString().ToUpper();
            dbValues = dbValues.ToUpper();
            txtItems.Add(dbValues);
            if (txtItems.Count > count)
            {
                return txtItems.ToArray();
            }
        }

        return txtItems.ToArray();


    }

    [WebMethod]
    public string[] GetStage(string prefixText, int count)
    {
        MatterView BEL = new MatterView();
        DataTable dt = BEL.SelectLikeDataStage(prefixText.ToUpper());

        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            //String From DataBase(dbValues)
            dbValues = row["stage_type_desc"].ToString().ToUpper();
            dbValues = dbValues.ToUpper();
            txtItems.Add(dbValues);
            if (txtItems.Count > count)
            {
                return txtItems.ToArray();
            }
        }

        return txtItems.ToArray();


    }

    [WebMethod]
    public string[] GetMatterType(string prefixText, int count)
    {
        MatterView BEL = new MatterView();
        DataTable dt = BEL.SelectLikeDataMatterType(prefixText.ToUpper());

        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            //String From DataBase(dbValues)
            dbValues = row["Matter_Type_Desc"].ToString().ToUpper();
            dbValues = dbValues.ToUpper();
            txtItems.Add(dbValues);
            if (txtItems.Count > count)
            {
                return txtItems.ToArray();
            }
        }

        return txtItems.ToArray();


    }

    [WebMethod]
    public string[] GetEmployee(string prefixText, int count)
    {
        MatterView BEL = new MatterView();
        DataTable dt = BEL.SelectLikeDataAssignedLawyer(prefixText.ToUpper());

        List<string> txtItems = new List<string>();
        String dbValues;
        String dbValues1;

        foreach (DataRow row in dt.Rows)
        {
            //String From DataBase(dbValues)
            dbValues1 = row["Employee_Id"].ToString().ToUpper();
            dbValues = row["UserName"].ToString().ToUpper();
            dbValues = dbValues.ToUpper();
            txtItems.Add(string.Format("{0} {1}", dbValues1, dbValues));
            // txtItems.Add(dbValues,);
           
            if (txtItems.Count > count)
            {
                return txtItems.ToArray();
            }
        }

        return txtItems.ToArray();


    }

    

    #endregion***************************************************
     

}

   



 



