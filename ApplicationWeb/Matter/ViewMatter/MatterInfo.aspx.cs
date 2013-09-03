#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    08.05.13                        Praveen Shukla                                Matter SpecificInformation.

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

public partial class Matter_ViewMatter_MatterInfo : BasePage
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    MatterDetails MDetails = new MatterDetails();
    Common_Message commessage = new Common_Message();
    MatterView MV = new MatterView();
    SaveMatter SV = new SaveMatter();
    static int EMPID;
    static string USERID;


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
            
            string M_id = Request.QueryString["Matter_Id"].ToString();
            dt = MDetails.GetSpecficSearch(M_id);
            if (dt.Rows.Count > 0)
            {
               
                 TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
                 Label lblMatterNo = this.Master.FindControl("lblMatterNo") as Label;
                 MatterTreeView.Nodes[0].Text = dt.Rows[0]["Matter_number"].ToString();
                 //MatterTreeView.Nodes[0].ChildNodes[0].Text = "Stage("+(5)+")";
                 //MatterTreeView.Nodes[0].ChildNodes[1].Text = "Cases(" + (3) + ")";
                 //MatterTreeView.Nodes[0].ChildNodes[2].Text = "Hearings(" + (4) + ")";
                 //MatterTreeView.Nodes[0].ChildNodes[3].Text = "POA & Fee Details(" + (1) + ")";
                 lblFallowerMatterno.Text = dt.Rows[0]["Matter_number"].ToString();
                 lblCloseMatterNo.Text = dt.Rows[0]["Matter_number"].ToString();
                 MatterTreeView.Nodes[0].ChildNodes[0].NavigateUrl = "~/Matter/Stage/StageDetails.aspx?Matter_Id=" + M_id;
                 MatterTreeView.Nodes[0].ChildNodes[1].NavigateUrl = "~/Matter/Cases/CasesDetails.aspx?Matter_Id=" + M_id + "&Case_ID=" + 0;
                 MatterTreeView.Nodes[0].ChildNodes[2].NavigateUrl = "~/Matter/Hearings/Hearings.aspx?Matter_Id=" + M_id + "&Hearing_ID=" + 0;
                 MatterTreeView.Nodes[0].ChildNodes[3].NavigateUrl = "~/Matter/ViewMatter/FeeDetailsandPOA.aspx?Matter_Id=" + M_id;
                 MatterTreeView.Nodes[0].ChildNodes[4].NavigateUrl = "~/Matter/ViewMatter/Parties.aspx?Matter_Id=" + M_id;
                 lblcientdata.Text = dt.Rows[0]["Company_Name"].ToString();
                 LblMatterData.Text = dt.Rows[0]["Matter_number"].ToString();
                 lblStatusText.Text = dt.Rows[0]["Staus_Desc"].ToString();
                 lblOpendateText.Text = Convert.ToDateTime(dt.Rows[0]["Open_Date"].ToString()).ToString("dd-MMM-yyyy ");
                 ddlAssignedLawyer.Text = dt.Rows[0]["AssignedLawyer"].ToString();
                 ddlResponsiblelawyer.Text = dt.Rows[0]["ResponsibileLawyer"].ToString();
                 ddlMatterType.Text = dt.Rows[0]["Matter_Type_Desc"].ToString();
                 ddlOffice.Text = dt.Rows[0]["offc_desc"].ToString();
                 txtMatterDiscription.Text = dt.Rows[0]["Description"].ToString();
                 //txtoppnents1.Text = dt.Rows[0]["Oppnents"].ToString();
                 //txtoppnents2.Text = dt.Rows[1]["Oppnents"].ToString();
                 //txtoppnents3.Text = dt.Rows[2]["Oppnents"].ToString();
                     
                      
                 


            }
            bindCaseGrid();
            bindStatic();
            OpponentGrid();
            BindAllEmployee();
            BindAlloffice();
            BindAllStatus();
            BindFallowerGrid();
            AllMatterNumber();
            GetMatterDetailsClose();
        }
    }
    #endregion

    #region   ********Css Load *************************
    protected void LoginCss_load()
    {
        Panel pnlarebic = this.Master.FindControl("pnlArebic") as Panel;
        Panel pnlEnlish = this.Master.FindControl("pnlEnlish") as Panel;
        Menu MainMenuArebic = this.Master.FindControl("MainMenuArebic") as Menu;
        Menu ManinMenu = this.Master.FindControl("ManinMenu") as Menu;

        Label Matter = this.Master.FindControl("lblMainMenuMatterEN") as Label;
        Label Hearing = this.Master.FindControl("lblMainMenuHeraingEN") as Label;
        Label DashBoard = this.Master.FindControl("lblMainMenuDashBrdEN") as Label;
        Label Cleint = this.Master.FindControl("lblMainMenuClientEN") as Label;
        Label Reports = this.Master.FindControl("lblMainMenuReportEN") as Label;
        Label Settings = this.Master.FindControl("lblMainMenuSettingsEN") as Label;
        Label Alert = this.Master.FindControl("lblMainMenuAlertEN") as Label;
        Label MatterAR = this.Master.FindControl("lblMainMenuMatterAR") as Label;
        Label HearingAR = this.Master.FindControl("lblMainMenuHeraingAR") as Label;
        Label DashBoardAR = this.Master.FindControl("lblMainMenuDashBrdAR") as Label;
        Label CleintAR = this.Master.FindControl("lblMainMenuClientAR") as Label;
        Label ReportsAR = this.Master.FindControl("lblMainMenuReportAR") as Label;
        Label SettingsAR = this.Master.FindControl("lblMainMenuSettingsAR") as Label;
        Label AlertAR = this.Master.FindControl("lblMainMenuAlertAR") as Label;

        Label SubMatter = this.Master.FindControl("lblsubmenuMatterEN") as Label;
        Label SubHearing = this.Master.FindControl("lblsubmenuHearingsEN") as Label;
        Label SubDashBoard = this.Master.FindControl("lblsubmenuDashBoardEN") as Label;
        Label SubCleint = this.Master.FindControl("lblsubmenuClientEN") as Label;
        Label SubReports = this.Master.FindControl("lblsubmenuReportEN") as Label;
        Label SubSettings = this.Master.FindControl("lblsubmenusettingEN") as Label;
        Label SubAlert = this.Master.FindControl("lblsubmenuAlertEN") as Label;

        Label SubMatterAR = this.Master.FindControl("lblsubmenuMatterAR") as Label;
        Label SubHearingAR = this.Master.FindControl("lblsubmenuHearingsAR") as Label;
        Label SubDashBoardAR = this.Master.FindControl("lblsubmenuDashBoardAR") as Label;
        Label SubCleintAR = this.Master.FindControl("lblsubmenuClientAR") as Label;
        Label SubReportsAR = this.Master.FindControl("lblsubmenuReportAR") as Label;
        Label SubSettingsAR = this.Master.FindControl("lblsubmenusettingAR") as Label;
        Label SubAlertAR = this.Master.FindControl("lblsubmenuAlertAR") as Label;


        Label Actions = this.Master.FindControl("lblActionEN") as Label;
        Label Alerts = this.Master.FindControl("lblalertsEN") as Label;
        Label ActionAR = this.Master.FindControl("lblActionAR") as Label;
        Label AlertsAR = this.Master.FindControl("lblalertsAR") as Label;
        Label lblMatterViewEN = this.Master.FindControl("lblMatterViewEN") as Label;
        Label lblMatterViewAR = this.Master.FindControl("lblMatterViewAR") as Label;

        //Label lblHclintEN = this.Master.FindControl("lblHclintEN") as Label;
        //Label lblHclintAR = this.Master.FindControl("lblHclintAR") as Label;
        //Label lblHMatterEN = this.Master.FindControl("lblHMatterEN") as Label;
        //Label lblHMatterAR = this.Master.FindControl("lblHMatterAR") as Label;
        //Label lblClientName = this.Master.FindControl("lblClientName") as Label;
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

        BindAlloffice();
        BindAllEmployee();
        BindMatterType();
        getRightInformation();
    }
    #endregion

    #region   *******PublicFunction*************************

    private void AllMatterNumber()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MV.SelectLikeMatterNumber();
        }
        else
        {
            dt = MV.SelectLikeMatterNumber();
        }
        if (dt.Rows.Count > 0)
        {
            ddlMatterNumber.DataSource = dt;
            ddlMatterNumber.DataBind();
            ddlMatterNumber.Items.Insert(0, new ListItem(""));


        }
    }
    private void BindAllEmployee()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MDetails.GetAllEmployeeArebic();
        }
        else
        {
            dt = MDetails.GetAllEmployeeEnlish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlemp.DataSource = dt;
            ddlemp.DataBind();
            ddlemp.Items.Insert(0, new ListItem(""));
            //ddlResponsiblelawyer.DataSource = dt;
            //ddlResponsiblelawyer.DataBind();
            //ddlAssignedLawyer.DataSource = dt;
            //ddlAssignedLawyer.DataBind();
        }
    }
    private void BindAlloffice()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MDetails.GetAllOfficArebic();
        }
        else
        {
            dt = MDetails.GetAllOfficEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlOfficeName.DataSource = dt;
            ddlOfficeName.DataBind();
            //ddlOffice.DataSource = dt;
            //ddlOffice.DataBind();
            ddlOfficeName.Items.Insert(0, new ListItem(""));
            //ddlOffice.Items.Insert(0, new ListItem(""));
        }
    }
    private void BindMatterType()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MDetails.GetMTYPEArebic();
        }
        else
        {
            dt = MDetails.GetMTYPEEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            //ddlMatterType.DataSource = dt;
            //ddlMatterType.DataBind();
        }
    }
    private void bindCaseGrid()
    {
        dt = MDetails.Case_MatterView(Request.QueryString["Matter_Id"].ToString());
        if (dt.Rows.Count > 0)
        {
            GridMatterCases.DataSource = dt;
            GridMatterCases.DataBind();
        }
    }
    private void OpponentGrid()
    {
        dt = MDetails.OpponentDetails(Request.QueryString["Matter_Id"].ToString());
        if (dt.Rows.Count > 0)
        {
            Dtgopponent.DataSource = dt;
            Dtgopponent.DataBind();
        }
    }
    private void BindAllStatus()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {

            dt = MDetails.GetAllStatusArebic();
        }
        else
        {
            dt = MDetails.GetAllStatusEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlcMatterStatusdata.DataSource = dt;
            ddlcMatterStatusdata.DataBind();
            ddlcMatterStatusdata.Items.Insert(0, new ListItem(""));
        }
    }
    #endregion

    #region   *******Operation Contract*************************
    protected void btnAddMatter_Click(object sender, EventArgs e)
    {
        string Mode = "INSERT";
        if (ddlMatterNumber.SelectedIndex != 0)
        {
            if (ddlOfficeName.SelectedIndex != 0)
            {
                int Client_Name = 0;
                int Assigened_ID = 0;
                int superviser_ID = 0;
                int MatteType_ID = 0;

                dt = MV.GetMatterDetails(ddlMatterNumber.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Client_Name = Convert.ToInt32(dt.Rows[0]["Client_Name"]);
                    Assigened_ID = Convert.ToInt32(dt.Rows[0]["assigned_ID"]);
                    superviser_ID = Convert.ToInt32(dt.Rows[0]["superviser_ID"]);
                    MatteType_ID = Convert.ToInt32(dt.Rows[0]["MatteType_ID"]);

                }
                try
                {
                    dt = MV.UniqueMatterNo(ddlMatterNumber.SelectedValue);
                    if (dt.Rows.Count > 0)
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Matter Number Already Exist.", 125, 300);

                    }
                    else
                    {
                        int i = MV.MatterAction(ddlMatterNumber.SelectedValue, Client_Name, superviser_ID, Assigened_ID, MatteType_ID, Convert.ToDateTime(txtOpenDate.Text), txtMatterDiscription.Text, Convert.ToInt32(ddlOfficeName.SelectedValue), Mode);
                        if (i > 0)
                        {
                            int j = SV.AuditMatter(Convert.ToInt32(ddlMatterNumber.SelectedItem.ToString()), Mode, USERID);
                            ddlOfficeName.SelectedIndex = 0;
                            ddlMatterNumber.SelectedIndex = 0;
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Error, ex.Message.ToString(), 125, 300);
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please Select office.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please Select Matter number.", 125, 300);
        }
    }
    protected void AddFallower_Click(object sender, EventArgs e)
    {
        if (ddlemp.SelectedIndex != 0)
        {
            string Mode = "INSERT";
            int i = MDetails.AddFallower(Convert.ToInt32(ddlemp.SelectedValue), 1,Mode);
            if (i > 0)
            {
                ddlemp.SelectedIndex = 0;
                BindFallowerGrid();
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,commessage.RecordSaved, 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning,"Please Select Employee Name.", 125, 300);
        }

    }
    protected void Delete_Fallower(object sender, GridViewDeleteEventArgs e)
    {
        int FallowerID=(int)DtgFallower.DataKeys[e.RowIndex].Value;
        string Mode = "DELETE";
        int i = MDetails.DeleteFallower(FallowerID,Mode);
        if (i > 0)
        {
            BindFallowerGrid();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning, commessage.DeletedRecord, 125, 300);
        }
    }
    #endregion

    #region   *******BindGrid Falllower*************************
    protected void BindFallowerGrid()
    {
        dt = MDetails.FallowerGrid(1);
        if(dt.Rows.Count > 0)
        {
            DtgFallower.DataSource = dt;
            DtgFallower.DataBind();
        }
    }

    
    #endregion

    #region ******************************GetMatterDetailsOnselect******************************
    protected void GetMatterDetails(object sender, EventArgs e)
    {
        dt = MV.GetMatterDetails(ddlMatterNumber.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            lblcleintdata.Text = dt.Rows[0]["Company_Name"].ToString();
            lblResponsibalelawyerdata.Text = dt.Rows[0]["REP"].ToString();
            lblAssignedLawyerdata.Text = dt.Rows[0]["Assigned"].ToString();
            lblmattertypedata.Text = dt.Rows[0]["Matter_Type_Desc"].ToString();
            txtOpenDate.Text = Convert.ToDateTime(dt.Rows[0]["Date_Opend"]).ToString("dd-MMM-yyyy");


        }
        else
        {
            lblcleintdata.Text = "";
            lblResponsibalelawyerdata.Text = "";
            lblAssignedLawyerdata.Text = "";
            lblmattertypedata.Text = "";
            txtOpenDate.Text = "";
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.NoRecordFound, 125, 300);
        }
    }
    #endregion

    #region ******************************GetCloseMatterDetailsOnselect******************************
    protected void GetMatterDetailsClose()
    {
        dt = MV.CloseMatterDetails(lblCloseMatterNo.Text);
        if (dt.Rows.Count > 0)
        {
            lblcclientdata.Text = dt.Rows[0]["Company_Name"].ToString();
            lblCresonsiabledata.Text = dt.Rows[0]["REP"].ToString();
            lblCAssignneddata.Text = dt.Rows[0]["Assigned"].ToString();
            lblCMattertypedata.Text = dt.Rows[0]["Matter_Type_Desc"].ToString();
            lblCdateopendata.Text = Convert.ToDateTime(dt.Rows[0]["Open_date"]).ToString("dd-MMM-yyyy");
            lblCofficedata.Text = dt.Rows[0]["Office_Desc_En"].ToString();
        }
        else
        {
            
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.NoRecordFound, 125, 300);
        }
    }
    #endregion

    #region   ********OpertaionContract*************************

    protected void btnCloseMatter_Click(object sender, EventArgs e)
    {
        string Mode = "UPDATE";

        if (ddlcMatterStatusdata.SelectedIndex != 0)
        {
            string Warning ="";
            int i = MV.MatterClose(lblCloseMatterNo.Text, Convert.ToInt32(ddlcMatterStatusdata.SelectedValue), Mode,out Warning );
            if (i > 0)
            {
                int j = SV.AuditMatter(Convert.ToInt32(lblCloseMatterNo.Text), Mode, USERID);
                ddlcMatterStatusdata.SelectedIndex = 0;
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning,Warning, 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Status.", 125, 300);
        }

    }
    #endregion

    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = MDetails.RightsDetails(EMPID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "Print Matter List")
                {
                    PrintMatter.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Add Matter")
                {
                    AddMatter.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Close Matter")
                {
                    CloseMatter.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Manage Fallower")
                {
                    ManageFallower.Visible = true;
                }

            }
        }
    }
    #endregion

    #region   *********************************Grid Operation *************************************************
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

        int index = GridMatterCases.SelectedIndex;
        Session["ID"] = GridMatterCases.DataKeys[index].Value.ToString();
        lbl.Text = GridMatterCases.DataKeys[index].Value.ToString();
        //Response.Redirect("~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id=" + MatterGrid.DataKeys[index].Value.ToString());
      
    }
    protected void GridMatterCases_RowDataBound(object sender, GridViewRowEventArgs e)
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



    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in GridMatterCases.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
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

    #region******************************Bind Chart*****************************************
    private void bindStatic()
    {
        dsSeries = MDetails.Chart_Data(Request.QueryString["Matter_Id"].ToString()); 

        if (dsSeries == null) return;

        foreach (DataRow dr in dsSeries.Tables[0].Rows)
        {
            hidXCategories11.Add((dr["stagetype"]));
        }

        foreach (DataRow dr1 in dsSeries.Tables[0].Rows)
        {
            hidValues11.Add(Convert.ToInt32(dr1["count"]));
            yValues = hidValues11.ToArray(typeof(object)) as object[];
            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }
        
        //Title
        // CaseChart.Title = new Highchart.Core.Title("Consumo de energia");

        //define Axis
       
        CaseChart.YAxis.Add(new YAxisItem { title = new Highchart.Core.Title("Matter#") });
        CaseChart.XAxis.Add(new XAxisItem { categories = hidXCategories11.ToArray(typeof(string)) as string[] });

        //Data
        var series = new Collection<Serie>();
        series.Add(new Serie { name = "Case Summary", data = yValues });
       
        //  series.Add(new Serie { name = "televis�o", data = new object[] { 4, 6, 7, 7, 8, 13, 11 } });

        //Ploting action
        CaseChart.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsScatter{ dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true } };

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
        
    }
    #endregion

#endregion

}