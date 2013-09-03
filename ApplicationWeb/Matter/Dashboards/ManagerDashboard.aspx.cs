#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    07.07.13                        Praveen Shukla                                Manger Dashboard.

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
public partial class Matter_Dashboards_ManagerDashboard : BasePage
{

    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    ManagerDashboardlogic LDBL = new ManagerDashboardlogic();
    Common_Message commessage = new Common_Message();
    SaveHearings SH = new SaveHearings();
    HearingLogic HD = new HearingLogic();
    MatterDetails MD = new MatterDetails();
    static int EMP_ID;
    static string USERID;

    DataSet dsSeries = new DataSet();
    ArrayList hidValues11 = new ArrayList();
    ArrayList hidXCategories11 = new ArrayList();

    object[] yValues;
    public object hidValues1;
    public string hidXCategories1;

    DataSet dsSeries2 = new DataSet();
    ArrayList hidValues12 = new ArrayList();
    ArrayList hidXCategories12 = new ArrayList();

    object[] yValues2;
    public object hidValues2;
    public string hidXCategories2;

    DataSet dsSeries3 = new DataSet();
    ArrayList hidValues13 = new ArrayList();
    ArrayList hidXCategories13 = new ArrayList();

    object[] yValues3;
    public object hidValues3;
    public string hidXCategories3;

    #endregion

    #region   ******** Page Load *************************
    protected void Page_Load(object sender, EventArgs e)
    {
        GetSession();
        
       
        if (!IsPostBack)
        {
            LoginCss_load();
            bindStatic();
            bindChartbyCourt();
            bindChartbyMatter();
        }
    }
    #endregion

    #region   ********Css Load *************************
    protected void LoginCss_load()
    {
        TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
        Panel pnlarebic = this.Master.FindControl("pnlArebic") as Panel;
        Panel pnlEnlish = this.Master.FindControl("pnlEnlish") as Panel;
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {

            lnkCSS.Attributes["href"] = "../../css/generalArebic.css";
            MatterTreeView.Attributes["ImageSet"] = "rtl";
            pnlarebic.Visible = false;
            pnlEnlish.Visible = true;


        }
        else
        {
            lnkCSS.Attributes["href"] = "../../css/generalEnglish.css";
            MatterTreeView.Attributes["ImageSet"] = "ltr";
            pnlarebic.Visible = true;
            pnlEnlish.Visible = false;

        }


       


        BindHearings();
        BindPleadings();
        AllMatter();
        AllCases();
        AllStatus();
        AllClient();
        getRightInformation();
        

    }
    #endregion
    
    #region   *********************************Hearing Grid Operation *************************************************
    private void BindHearings()
    {


        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.GetupcomingHearings_Arabic(EMP_ID);
        }
        else
        {
            dt = LDBL.GetupcomingHearings_English(EMP_ID);
        }
        if (dt.Rows.Count > 0)
        {
            DtgUpcomingHearings.DataSource = dt;
            DtgUpcomingHearings.DataBind();
        }
        else
        {
            DtgUpcomingHearings.DataSource = null;
            DtgUpcomingHearings.DataBind();
        }




    }

    protected void DtgUpcomingHearings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DtgUpcomingHearings.PageIndex = e.NewPageIndex;
        BindHearings();
    }
    protected void DtgUpcomingHearings_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void DtgUpcomingHearings_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = DtgUpcomingHearings.SelectedIndex;
        GridViewRow selectedRow = DtgUpcomingHearings.SelectedRow;
        lbl.Text = selectedRow.Cells[2].Text.ToString();
        lblcase.Text = DtgUpcomingHearings.DataKeys[index].Value.ToString();
        //Session["ID"] = DtgUpcomingHearings.DataKeys[index].Value.ToString();
        string @CaseID = "";
        int i = LDBL.GetCaseID(Convert.ToInt32(lblcase.Text), out @CaseID);
        Session["ID"] = @CaseID;
        lbl.Text = Session["ID"].ToString();
        BindPleadings();
        TreeNodePopulate();
        
    }
    private void TreeNodePopulate()
    {
        dt = MD.GetSpecficSearch(lbl.Text);
        if (dt.Rows.Count > 0)
        {
            TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
            MatterTreeView.Nodes[0].Text = dt.Rows[0]["Matter_number"].ToString();
            MatterTreeView.Nodes[0].ChildNodes[0].NavigateUrl = "~/Matter/Stage/StageDetails.aspx?Matter_Id=" + lbl.Text;
            MatterTreeView.Nodes[0].ChildNodes[1].NavigateUrl = "~/Matter/Cases/CasesDetails.aspx?Matter_Id=" + lbl.Text + "&Case_ID=" + 0;
            MatterTreeView.Nodes[0].ChildNodes[2].NavigateUrl = "~/Matter/Hearings/Hearings.aspx?Matter_Id=" + lbl.Text + "&Hearing_ID=" + 0;
            MatterTreeView.Nodes[0].ChildNodes[3].NavigateUrl = "~/Matter/ViewMatter/FeeDetailsandPOA.aspx?Matter_Id=" + lbl.Text;
            MatterTreeView.Nodes[0].ChildNodes[4].NavigateUrl = "~/Matter/ViewMatter/Parties.aspx?Matter_Id=" + lbl.Text;
        }

    }
    protected void DtgUpcomingHearings_RowDataBound(object sender, GridViewRowEventArgs e)
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

    #endregion

    #region   *********************************Pleadings Grid Operation *************************************************
    private void BindPleadings()
    {
        
          
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetUnpreparedPleadings_English(EMP_ID);
            }
            else
            {
                dt = LDBL.GetUnpreparedPleadings_English(EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {
                dtgUnpreparedPleadings.DataSource = dt;
                dtgUnpreparedPleadings.DataBind();
            }
            else
            {
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
            }



            if (lblcase.Text != "")
            {
                if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                {
                    dt = LDBL.GetUnpreparedPleadings_Case_Arabic(Convert.ToInt32(lblcase.Text));
                }
                else
                {
                    dt = LDBL.GetUnpreparedPleading_Case_English(Convert.ToInt32(lblcase.Text));
                }
                if (dt.Rows.Count > 0)
                {
                    dtgUnpreparedPleadings.DataSource = dt;
                    dtgUnpreparedPleadings.DataBind();
                    lblcase.Text = "";
                }
                else
                {
                    dtgUnpreparedPleadings.DataSource = null;
                    dtgUnpreparedPleadings.DataBind();
                }
            }
           
    }
    protected void dtgUnpreparedPleadings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgUnpreparedPleadings.PageIndex = e.NewPageIndex;
        BindPleadings();
    }
    protected void dtgUnpreparedPleadings_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void dtgUnpreparedPleadings_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = dtgUnpreparedPleadings.SelectedIndex;
        //Response.Redirect("~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id=" + MatterGrid.DataKeys[index].Value.ToString());
    }
    protected void dtgUnpreparedPleadings_RowDataBound(object sender, GridViewRowEventArgs e)
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
    #endregion

    #region   **********************Render Function**********************************************
    protected override void Render(HtmlTextWriter writer)
    {
       
        foreach (GridViewRow row in DtgUpcomingHearings.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
    }
    #endregion

    #region   *********************************Click On Show All Button *************************************************
    protected void lnlshowAllMatter_Click(object sender, EventArgs e)
    {

        ddlcase.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        ddlMatter.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
    }
    protected void lnlHearingShowAll_Click(object sender, EventArgs e)
    {
        BindHearings();
        ddlcase.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        ddlMatter.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
    }
    protected void lnkUnprepared_Click(object sender, EventArgs e)
    {
        //BindPleadings();
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.GetUnpreparedPleadings_English(EMP_ID);
        }
        else
        {
            dt = LDBL.GetUnpreparedPleadings_English(EMP_ID);
        }
        if (dt.Rows.Count > 0)
        {
            dtgUnpreparedPleadings.DataSource = dt;
            dtgUnpreparedPleadings.DataBind();
        }
        else
        {
            dtgUnpreparedPleadings.DataSource = null;
            dtgUnpreparedPleadings.DataBind();
        }

        ddlcase.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        ddlMatter.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
    }
    protected void lnkupcomingAppeals_Click(object sender, EventArgs e)
    {

        ddlcase.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        ddlMatter.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
    }

    #endregion

    #region   ********Print Reports *************************
    protected void lnlprintCaseMatter_Click(object sender, EventArgs e)
    {
        LinkButton lnlprintCaseMatter = new LinkButton();
        lnlprintCaseMatter.Attributes.Add("target", "_blank");
        Response.Redirect("~/Matter/Reports/PrintCaseList.aspx");
    }
    #endregion

    #region   ********Search Button Click *************************

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        SearchData();

    }
    #endregion

    #region   ********Dropdown List Data Bind *************************
    protected void AllMatter()
    {
        dt = LDBL.MatterNumber();
        if (dt.Rows.Count > 0)
        {
            ddlMatter.DataSource = dt;
            ddlMatter.DataBind();
            ddlMatter.Items.Insert(0, new ListItem(""));
        }

    }
    protected void AllCases()
    {
        dt = LDBL.CaseNumber();
        if (dt.Rows.Count > 0)
        {
            ddlcase.DataSource = dt;
            ddlcase.DataBind();
            ddlcase.Items.Insert(0, new ListItem(""));
        }

    }
    protected void AllClient()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.PartyArabic();
        }
        else
        {
            dt = LDBL.PartyEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlclient.DataSource = dt;
            ddlclient.DataBind();
            ddlclient.Items.Insert(0, new ListItem(""));
        }

    }
    protected void AllStatus()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.StausArabic();
        }
        else
        {
            dt = LDBL.StausEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlStatus.DataSource = dt;
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem(""));
        }

    }
    #endregion

    #region   ********Search Logic*************************
    protected void SearchData()
    {
        GetExactMatter();
    }
    #endregion

    #region   ********Search For MatterGrid *************************

    protected void GetExactMatter()
    {

        if (ddlMatter.SelectedIndex != 0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_MatterID_Arabic(Convert.ToInt32(ddlMatter.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_MatterID_English(Convert.ToInt32(ddlMatter.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {
               
                
                if (ddlMatter.SelectedIndex != 0)
                {
                    if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                    {
                        dt = LDBL.GetUnpreparedPleading_English(Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    else
                    {
                        dt = LDBL.GetUnpreparedPleading_English(Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        dtgUnpreparedPleadings.DataSource = dt;
                        dtgUnpreparedPleadings.DataBind();
                        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                        {
                            dt = LDBL.GetupcomingHearings_Arabic_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }
                        else
                        {
                            dt = LDBL.GetupcomingHearings_English_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }
                        
                        if (dt.Rows.Count > 0)
                        {

                            DtgUpcomingHearings.DataSource = dt;
                            DtgUpcomingHearings.DataBind();
                        }
                    }
                    else
                    {
                        dtgUnpreparedPleadings.DataSource = null;
                        dtgUnpreparedPleadings.DataBind();
                        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                        {
                            dt = LDBL.GetupcomingHearings_Arabic_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }
                        else
                        {
                            dt = LDBL.GetupcomingHearings_English_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }

                        if (dt.Rows.Count > 0)
                        {

                            DtgUpcomingHearings.DataSource = dt;
                            DtgUpcomingHearings.DataBind();
                        }
                    }
                }

            }
            else
            {
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }
        if (ddlMatter.SelectedIndex != 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex ==0 && ddlStatus.SelectedIndex ==0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_MatterID_Caseid_Arabic(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_MatterID_Caseid_English(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {

                if (ddlMatter.SelectedIndex != 0 && ddlcase.SelectedIndex != 0)
                {
                    if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                    {
                        dt = LDBL.GetupcomingHearing_Case_Arabic(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
                    }
                    else
                    {
                        dt = LDBL.GetupcomingHearing_Case_English(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        DtgUpcomingHearings.DataSource = dt;
                        DtgUpcomingHearings.DataBind();
                    }
                    else
                    {
                        DtgUpcomingHearings.DataSource = null;
                        DtgUpcomingHearings.DataBind();
                    }
                }


                if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
                {
                    if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                    {
                        dt = LDBL.GetUnpreparedPleadings_Case_Arabic(Convert.ToInt32(ddlcase.SelectedValue));
                    }
                    else
                    {
                        dt = LDBL.GetUnpreparedPleading_Case_English(Convert.ToInt32(ddlcase.SelectedValue));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        dtgUnpreparedPleadings.DataSource = dt;
                        dtgUnpreparedPleadings.DataBind();
                    }
                    else
                    {
                        dtgUnpreparedPleadings.DataSource = null;
                        dtgUnpreparedPleadings.DataBind();
                    }
                }

            }
            else
            {
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }

        if (ddlMatter.SelectedIndex != 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex != 0 && ddlStatus.SelectedIndex ==0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_MatterID_Caseid_PartyID_Arabic(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), Convert.ToInt32(ddlclient.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_MatterID_Caseid_PartyID_English(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), Convert.ToInt32(ddlclient.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {
            }
            else
            {

                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }
        if (ddlMatter.SelectedIndex != 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_MatterID_Caseid_PartyID_Status_Arabic(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), Convert.ToInt32(ddlclient.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_MatterID_Caseid_PartyID_Status_English(Convert.ToInt32(ddlMatter.SelectedValue), Convert.ToInt32(ddlcase.SelectedValue), Convert.ToInt32(ddlclient.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {
            }
            else
            {

                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }


        if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex == 0 && ddlStatus.SelectedIndex != 0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_Status_Arabic(Convert.ToInt32(ddlStatus.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_Status_English(Convert.ToInt32(ddlStatus.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {

            }
            else
            {

                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }
        if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex == 0 && ddlclient.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_PartyID_Status_Arabic(Convert.ToInt32(ddlclient.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_PartyID_Status_English(Convert.ToInt32(ddlclient.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {

            }
            else
            {

                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }
        if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_PartyID_Arabic(Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_PartyID_English(Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {

            }
            else
            {

                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }

        if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex != 0 && ddlStatus.SelectedIndex == 0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_Caseid_PartyID_Arabic(Convert.ToInt32(ddlcase.SelectedValue), Convert.ToInt32(ddlclient.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_Caseid_PartyID_English(Convert.ToInt32(ddlcase.SelectedValue), Convert.ToInt32(ddlclient.SelectedValue), EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {

            }
            else
            {

                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }

        if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
        {

            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetAllMatterView_Caseid_Arabic(Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
            }
            else
            {
                dt = LDBL.GetAllMatterView_Caseid_English(Convert.ToInt32(ddlcase.SelectedValue), EMP_ID);
            }

            if (dt.Rows.Count > 0)
            {

            }
            else
            {

                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();

            }
        }

    }

    #endregion
    
    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = LDBL.RightsDetails(EMP_ID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i][0].ToString() == "Create Pleadings")
                {
                    //CreatePleadings.Visible = true;
                }

            }
        }
    }
    #endregion
            
    #region   ********GET SESSION VARIBALE FROM LOGIN PAGE************************
    protected void GetSession()
    {
        if (Session["Employee_Id"] != null && Session["NAME"] != null)
        {
            EMP_ID = Convert.ToInt32(Session["Employee_Id"]);
            USERID = Session["NAME"].ToString();
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }
    #endregion

    #region*****************Bind Chart********************************
    private void bindStatic()
    {
        dsSeries = LDBL.GetStats_English(EMP_ID);

        if (dsSeries == null) return;

        foreach (DataRow dr in dsSeries.Tables[0].Rows)
        {
            hidXCategories11.Add(dr["TOTAL"]);


        }

        foreach (DataRow dr1 in dsSeries.Tables[0].Rows)
        {
            hidValues11.Add(Convert.ToInt32(dr1["MATTER#"]));
            yValues = hidValues11.ToArray(typeof(object)) as object[];
            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }


        //Title
       // Statices.Title = new Highchart.Core.Title("Consumo de energia");

        //define Axis
        Statices.YAxis.Add(new YAxisItem { title = new Highchart.Core.Title("Matter#") });
        Statices.XAxis.Add(new XAxisItem { categories = hidXCategories11.ToArray(typeof(string)) as string[] });

        //Data
        var series = new Collection<Serie>();
        series.Add(new Serie { name = "Matter Summary", data = yValues });
        //  series.Add(new Serie { name = "televis�o", data = new object[] { 4, 6, 7, 7, 8, 13, 11 } });

        //Ploting action
        Statices.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true } };

        //Customize tooltip
        Statices.Tooltip = new ToolTip("this.x +': '+ this.y");

        //Customize legend
        Statices.Legend = new Highchart.Core.Legend
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
        Statices.DataSource = series;
        Statices.DataBind();
    }

    private void bindChartbyMatter()
    {
        dsSeries3 = LDBL.GetMatterbyLawyer_English(EMP_ID);

        if (dsSeries3 == null) return;

        foreach (DataRow dr in dsSeries3.Tables[0].Rows)
        {
            hidXCategories13.Add(dr["UserName"]);


        }

        foreach (DataRow dr1 in dsSeries3.Tables[0].Rows)
        {
            hidValues13.Add(Convert.ToInt32(dr1["TotActiveMatter"]));
            yValues3 = hidValues13.ToArray(typeof(object)) as object[];
            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }


        //Title
        // Statices.Title = new Highchart.Core.Title("Consumo de energia");

        //define Axis
        ChartByEmployee.YAxis.Add(new YAxisItem { title = new Highchart.Core.Title("Total Active Matter") });
        ChartByEmployee.XAxis.Add(new XAxisItem { categories = hidXCategories13.ToArray(typeof(string)) as string[] });

        //Data
        var series = new Collection<Serie>();
        series.Add(new Serie { name = "Employee Summary", data = yValues3 });
        //  series.Add(new Serie { name = "televis�o", data = new object[] { 4, 6, 7, 7, 8, 13, 11 } });

        //Ploting action
        ChartByEmployee.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true } };

        //Customize tooltip
        ChartByEmployee.Tooltip = new ToolTip("this.x +': '+ this.y");

        //Customize legend
        ChartByEmployee.Legend = new Highchart.Core.Legend
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
        ChartByEmployee.DataSource = series;
        ChartByEmployee.DataBind();
    }

    private void bindChartbyCourt()
    {
        dsSeries2 = LDBL.GetCasebyCourt_English(EMP_ID);

        if (dsSeries2 == null) return;

        foreach (DataRow dr in dsSeries2.Tables[0].Rows)
        {
            hidXCategories12.Add(dr["court_name"]);


        }

        foreach (DataRow dr1 in dsSeries2.Tables[0].Rows)
        {
            hidValues12.Add((dr1["TOT"]));
            yValues2 = hidValues12.ToArray(typeof(object)) as object[];
            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }


        //Title
        // Statices.Title = new Highchart.Core.Title("Consumo de energia");

        //define Axis
        ChartByCase.YAxis.Add(new YAxisItem { title = new Highchart.Core.Title("TOTAL CASE") });
        ChartByCase.XAxis.Add(new XAxisItem { categories = hidXCategories12.ToArray(typeof(string)) as string[] });

        //Data
        var series = new Collection<Serie>();
        series.Add(new Serie { name = "Court Name", data = yValues2 });
        //  series.Add(new Serie { name = "televis�o", data = new object[] { 4, 6, 7, 7, 8, 13, 11 } });

        //Ploting action
        ChartByCase.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true } };

        //Customize tooltip
        ChartByCase.Tooltip = new ToolTip("this.x +': '+ this.y");

        //Customize legend
        ChartByCase.Legend = new Highchart.Core.Legend
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
        ChartByCase.DataSource = series;
        ChartByCase.DataBind();
    }
    
    #endregion

}

#endregion

