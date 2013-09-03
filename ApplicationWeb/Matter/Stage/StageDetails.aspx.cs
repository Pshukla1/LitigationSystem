#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    26.05.13                        Praveen Shukla                                stgae SpecificInformation.

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
using Highchart.Core;
using Highchart.UI;
using Highchart.Core.Data;
using Highchart.Core.PlotOptions;
using System.Web.UI.DataVisualization.Charting;
using Highchart.Core.Data.Chart;
using System.Collections.ObjectModel;
using System.Collections;
#endregion

#region   ********Page Controls *************************

public partial class Matter_Stage_StageDetails : BasePage
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    ViewStageLogic VSL = new ViewStageLogic();
    MatterDetails MDetails = new MatterDetails();
    SaveStage SV = new SaveStage();
    Common_Message commessage = new Common_Message();
    static string M_id;
    static string USERID;
    static int EMPID;

    DataSet dsSeries = new DataSet();
    ArrayList hidValues11 = new ArrayList();
    ArrayList hidXCategories11 = new ArrayList();
    ArrayList hidValues12 = new ArrayList();

    object[] yValues;
    public object hidValues1;
    object[] yValues2;
    public object hidValues2;
    public string hidXCategories1;

    #endregion

    #region   ******** Page Load *************************
    protected void Page_Load(object sender, EventArgs e)
    {

        GetSession();
        if (!IsPostBack)
        {
            LoginCss_load();
            
            if (Session["ID"] != null)
            {
                bindChart();
                M_id = Request.QueryString["Matter_Id"].ToString();
                dt = VSL.GetSpecficSearch(M_id);
                if (dt.Rows.Count > 0)
                {

                    TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
                    Label lblMatterNo = this.Master.FindControl("lblMatterNo") as Label;
                    MatterTreeView.Nodes[0].Text = dt.Rows[0]["Matter_number"].ToString();
                    lblForecastmatterno.Text = dt.Rows[0]["Matter_number"].ToString();
                    txtStageMatterno.Text = dt.Rows[0]["Matter_number"].ToString();
                    txtmatternoclsoe.Text = dt.Rows[0]["Matter_number"].ToString();
                    txtdelmatter.Text = dt.Rows[0]["Matter_number"].ToString();
                    MatterTreeView.Nodes[0].ChildNodes[0].NavigateUrl = "~/Matter/Stage/StageDetails.aspx?Matter_Id=" + M_id;
                    MatterTreeView.Nodes[0].ChildNodes[1].NavigateUrl = "~/Matter/Cases/CasesDetails.aspx?Matter_Id=" + M_id + "&Case_ID=" + 0;
                    MatterTreeView.Nodes[0].ChildNodes[2].NavigateUrl = "~/Matter/Hearings/Hearings.aspx?Matter_Id=" + M_id + "&Hearing_ID=" + 0;
                    MatterTreeView.Nodes[0].ChildNodes[3].NavigateUrl = "~/Matter/ViewMatter/FeeDetailsandPOA.aspx?Matter_Id=" + M_id;
                    MatterTreeView.Nodes[0].ChildNodes[4].NavigateUrl = "~/Matter/ViewMatter/Parties.aspx?Matter_Id=" + M_id;
                    StageView();
                    AllStaus();
                    AllStage();
                    MatterStage(Convert.ToInt32(M_id));
                }
            }


        }
    }
    #endregion

    #region   ********Css Load *************************
    protected void LoginCss_load()
    {
        Panel pnlarebic = this.Master.FindControl("pnlArebic") as Panel;
        Panel pnlEnlish = this.Master.FindControl("pnlEnlish") as Panel;


        Label lblMatterNo = this.Master.FindControl("lblMatterNo") as Label;

        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {

            lnkCSS.Attributes["href"] = "../../css/generalArebic.css";
            pnlarebic.Visible = false;
            pnlEnlish.Visible = true;

        }
        else
        {

            lnkCSS.Attributes["href"] = "../../css/generalEnglish.css";
            pnlarebic.Visible = true;
            pnlEnlish.Visible = false;

        }

       

    }
    #endregion

    #region******************************Bind Chart*****************************************
    private void bindChart()
    {
        dsSeries = SV.Chart_Data(Session["ID"].ToString());

        if (dsSeries == null) return;

        foreach (DataRow dr in dsSeries.Tables[0].Rows)
        {
            hidXCategories11.Add((dr["stage_type_desc"]));
        }

        foreach (DataRow dr1 in dsSeries.Tables[0].Rows)
        {
            hidValues11.Add(Convert.ToInt32(dr1["actual_effort"]));
            yValues = hidValues11.ToArray(typeof(object)) as object[];
            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }
        foreach (DataRow dr2 in dsSeries.Tables[0].Rows)
        {
            hidValues12.Add(Convert.ToInt32(dr2["weighting"]));
            yValues2 = hidValues12.ToArray(typeof(object)) as object[];
            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }
        //Title
        // CaseChart.Title = new Highchart.Core.Title("Consumo de energia");

        //define Axis

        CaseChart.YAxis.Add(new YAxisItem { title = new Highchart.Core.Title("Effort %") });
        CaseChart.XAxis.Add(new XAxisItem { categories = hidXCategories11.ToArray(typeof(string)) as string[] });

        //Data
        var series = new Collection<Serie>();
        series.Add(new Serie { name = "Actual Effort", data = yValues });
        var series1 = new Collection<Serie>();
        series1.Add(new Serie { name = "Effort", data = yValues2 });
        //  series.Add(new Serie { name = "televis�o", data = new object[] { 4, 6, 7, 7, 8, 13, 11 } });

        //Ploting action
        CaseChart.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsScatter { dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true } };

        //Customize tooltip
        CaseChart.Tooltip = new ToolTip("this.x +': '+ this.y");

        //Customize legend
        CaseChart.Legend = new Highchart.Core.Legend
        {
            layout = Layout.vertical,
            borderWidth = 3,
            align = Align.right,
            y = 20,
            x = -20,
            verticalAlign = Highchart.Core.VerticalAlign.top,
            shadow = true,
            backgroundColor = "#e3e6be"
        };

        //bind datacontrol
        CaseChart.DataSource = series;
        CaseChart.DataBind();
        CaseChart.DataSource = series1;
        CaseChart.DataBind();

    }
    #endregion

    #region   ********StageGrid*************************
    public void StageView()
    {
        dt = VSL.ViewStage(Request.QueryString["Matter_Id"].ToString());
        //dt = VSL.ViewStage("1");
        if (dt.Rows.Count > 0)
        {
            DtgViewStage.DataSource = dt;
            DtgViewStage.DataBind();
        }
    }
    protected void gvHover_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
        }

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
        {
            e.Row.CssClass = "normal";
           

        }

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.CssClass = "alternate";
            
        }
       
       
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = DtgViewStage.SelectedIndex;
        lbl.Text = DtgViewStage.DataKeys[index].Value.ToString();
        MatterStage(Convert.ToInt32(lbl.Text));
        Colsestage();
        PreviuosId();
        
    } 
    protected void DtgViewStage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get reference to button field in the gridview.  
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "Select$" + e.Row.RowIndex);
                e.Row.Style["cursor"] = "hand";
                e.Row.Attributes["onclick"] = _jsSingle;
            }
        }  

       //// string alertBox = "alert('";
       // String datakey;
       // string local_idcode;
        
       // if (e.Row.RowType == DataControlRowType.DataRow)
       // {
       //     object objTemp = DtgViewStage.DataKeys[e.Row.RowIndex].Value as object;
       //     if (objTemp != null)
       //     {
       //         string id = objTemp.ToString();
       //         lbl.Text = id;
       //     }

       //     //datakey = DtgViewStage.DataKeys[e.Row.RowIndex].Value.ToString();
       //     //lbl.Text = datakey;
       //     //local_idcode = Convert.ToString(DtgViewStage.DataKeys[e.Row.RowIndex].Values[1].ToString());
       //     //alertBox += e.Row.RowIndex;

       //     //alertBox += "')";

       //     //lbl.Text = e.Row.RowIndex.ToString();
       //     //e.Row.Attributes.Add("onclick", datakey);
       //    // Response.Write(local_idcode);
            

       // }

    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in DtgViewStage.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
    }

    protected void DtgViewStage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DtgViewStage.PageIndex = e.NewPageIndex;
        StageView();
    }
    #endregion

    #region****************Get Privious stage Id**********************************
    protected void PreviuosId()
    {
        string Mode = "GETID";
        string @StageID = "";
        int i = SV.GetStage(Convert.ToInt32(lbl.Text),Convert.ToInt32(M_id), Mode, out @StageID);
        ddlPStage.SelectedValue = @StageID;
       
        
        
    }
    #endregion

    #region   ********OpertaionContract*************************
    protected void btnAddStage_Click(object sender, EventArgs e)
    {
        string Mode = "UPDATE";
        if (lbl.Text.ToString() != "")
        {

            if (ddlStageStage.SelectedIndex != 0)
            {


                int i = SV.StageAction(Convert.ToInt32(lbl.Text), Convert.ToInt32(Request.QueryString["Matter_Id"].ToString()), Convert.ToInt32(ddlStageStage.SelectedValue), 1,
                    //int i = SV.StageAction(Convert.ToInt32(lbl.Text),1, Convert.ToInt32(ddlStageStage.SelectedValue), 1,
                txtstageDiscription.Text, Convert.ToDateTime(txtstageopebdate.Text), Convert.ToDateTime(txtstagecloseDate.Text), Convert.ToInt32(ddlPStage.SelectedValue), Mode);
                if (i > 0)
                {

                    StageView();
                    int j = SV.AuditStage(Convert.ToInt32(lbl.Text), Mode, USERID);
                    lbl.Text = "";
                    ddlStageStage.SelectedIndex = 0;
                    txtstageDiscription.Text = "";
                    txtstagecloseDate.Text = "";
                    txtstageopebdate.Text = "";
                    ddlPStage.SelectedIndex = 0;
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                }

            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select  Stage.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,"Please Select the Record.", 125, 300);
        }
    }
    protected void btnAddForecast_Click(object sender, EventArgs e)
    {
        string Mode = "INSERT";
        if (ddlForcastStage.SelectedIndex != 0)
        {

            int i = SV.ForeCastAction(3,Convert.ToInt32(M_id), Convert.ToInt32(ddlForcastStage.SelectedValue), Convert.ToInt32(txtActualEffort.Text),
            Convert.ToInt32(txtcompleted.Text), Convert.ToDateTime(txtForecastStart.Text), Convert.ToDateTime(txtForecastStart.Text), Mode);
            if (i > 0)
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
                StageView();
                int j = SV.AuditStage(1, Mode, USERID);
                ddlForcastStage.SelectedIndex = 0;
                txtActualEffort.Text = "";
                txtcompleted.Text = "";
                txtForecastEnd.Text = "";
                txtForecastEnd.Text = "";
                lbl.Text = "";

            }
        }

        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,"Please Select Stage", 125, 300);
        }
    
    }
    protected void btnCloseStage_Click(object sender, EventArgs e)
    {
        if (txtmatternoclsoe.Text != "" && lbl.Text != "")
        {

            string Mode = "UPDATE";
            if (ddlStageStatus.SelectedIndex != 0)
            {
                int i = SV.ClosStageAction(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlStageStatus.SelectedValue), Mode);
                if (i > 0)
                {

                    StageView();
                    int j = SV.AuditStage(Convert.ToInt32(lbl.Text), Mode, USERID);
                    ddlStageStage.SelectedIndex = 0;
                    txtActualEffort.Text = "";
                    txtcompleted.Text = "";
                    txtForecastEnd.Text = "";
                    txtForecastEnd.Text = "";
                    lbl.Text = "";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,"Stage is used by Case.", 125, 300);
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select stage.", 125, 300);
            }
        }
    }
      
    protected void btndeleteStage_Click(object sender, EventArgs e)
    {
        if (txtmatternoclsoe.Text != "" && lbl.Text != "")
        {

            string Mode = "DELETE";
            int i = SV.ClosStageAction(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlStageStatus.SelectedValue), Mode);
            if (i > 0)
            {

                StageView();
                int j = SV.AuditStage(Convert.ToInt32(lbl.Text), Mode, USERID);
                ddlStageStage.SelectedIndex = 0;
                txtActualEffort.Text = "";
                txtcompleted.Text = "";
                txtForecastEnd.Text = "";
                txtForecastEnd.Text = "";
                lbl.Text = "";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.DeletedRecord, 125, 300);
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Stage is used by Case.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Stage.", 125, 300);
        }
    }
        
    #endregion

    #region   ********Stage Dropdown*************************
    private void AllStage()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = SV.GetAllStagesArabic();
        }
        else
        {
            dt = SV.GetAllStagesEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlPStage.DataSource = dt;
            ddlPStage.DataBind();
            ddlstageprevious.DataSource = dt;
            ddlstageprevious.DataBind();
            delddlstgae.DataSource = dt;
            delddlstgae.DataBind();
            delddlstgae.Items.Insert(0, new ListItem(""));
            delddlstgae.Items.Insert(0, new ListItem(""));
            ddlStageStage.Items.Insert(0, new ListItem(""));
            ddlStageStage.DataSource = dt;
            ddlStageStage.DataBind();
            ddlForcastStage.DataSource = dt;
            ddlForcastStage.DataBind();
            ddlPStage.Items.Insert(0, new ListItem(""));
            ddlForcastStage.Items.Insert(0, new ListItem(""));
        }
    }

    private void MatterStage(int Matter_id)
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = SV.MatterStagesArabic(Convert.ToInt32(Matter_id));
        }
        else
        {
            dt = SV.MatterStagesEnglish(Convert.ToInt32(Matter_id));
        }
        if (dt.Rows.Count > 0)
        {
            //ddlPStage.DataSource = dt;
            //ddlPStage.DataBind();
            //ddlstageprevious.DataSource = dt;
            //ddlstageprevious.DataBind();
            //delddlstgae.DataSource = dt;
            //delddlstgae.DataBind();
            //delddlstgae.Items.Insert(0, new ListItem(""));
            //delddlstgae.Items.Insert(0, new ListItem(""));
            //ddlStageStage.Items.Insert(0, new ListItem(""));
        }
    }
    private void AllStaus()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = SV.GetAllStatusArabic();
        }
        else
        {
            dt = SV.GetAllStatusEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlStageStatus.DataSource = dt;
            ddlStageStatus.DataBind();
            ddlStageStatus.Items.Insert(0, new ListItem(""));

        }
    }
    #endregion

    #region   ********Comman Data*************************
    protected void Colsestage()
    {
        if (M_id != "")
        {
            dt = SV.Closestagedata(Convert.ToInt32(lbl.Text));
            if (dt.Rows[0]["Open_date"].ToString() != "" && dt.Rows[0]["Close_date"].ToString() != "")
            {

                ddlstageprevious.SelectedValue = dt.Rows[0]["Stage_Type_ID"].ToString();
                txtopendatestage.Text = Convert.ToDateTime(dt.Rows[0]["Open_date"]).ToString("dd-MMM-yyyy");
                txtclosedatestage.Text = Convert.ToDateTime(dt.Rows[0]["Close_date"]).ToString("dd-MMM-yyyy");
                txtdicrptionClose.Text = dt.Rows[0]["Description"].ToString();

                //Delstage Bind
                
                delddlstgae.SelectedValue = dt.Rows[0]["Stage_Type_ID"].ToString();
                txtdelopendate.Text = Convert.ToDateTime(dt.Rows[0]["Open_date"]).ToString("dd-MMM-yyyy");
                txtdelclosedate.Text = Convert.ToDateTime(dt.Rows[0]["Close_date"]).ToString("dd-MMM-yyyy");
                txtdeldicription.Text = dt.Rows[0]["Description"].ToString();

                //add Stage data

                ddlStageStage.SelectedValue = dt.Rows[0]["Stage_Type_ID"].ToString();
                txtstageopebdate.Text = Convert.ToDateTime(dt.Rows[0]["Open_date"]).ToString("dd-MMM-yyyy");
                txtstagecloseDate.Text = Convert.ToDateTime(dt.Rows[0]["Close_date"]).ToString("dd-MMM-yyyy");
                txtstageDiscription.Text = dt.Rows[0]["Description"].ToString();
            }
            else
            {
                ddlstageprevious.SelectedIndex =0;
                txtopendatestage.Text ="";
                txtclosedatestage.Text ="";
                txtdicrptionClose.Text = "";
                delddlstgae.SelectedIndex = 0;
                ddlPStage.SelectedIndex = 0;
                txtdelopendate.Text = "";
                txtdelclosedate.Text = "";
                txtdeldicription.Text = "";
                ddlStageStage.SelectedIndex = 0;
                txtstageopebdate.Text = "";
                txtstagecloseDate.Text = "";
                txtstageDiscription.Text = "";
                //MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.NoRecordFound, 125, 300);
            }
        }
    }
    #endregion

    #region   ********GET SESSION VARIBALE FROM LOGIN PAGE************************
    protected void GetSession()
    {
        if (Session["Employee_Id"] != null && Session["NAME"] != null)
        {
            EMPID = Convert.ToInt32(Session["Employee_Id"]);
            USERID = Session["NAME"].ToString();
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }
    #endregion
}
  

   


#endregion