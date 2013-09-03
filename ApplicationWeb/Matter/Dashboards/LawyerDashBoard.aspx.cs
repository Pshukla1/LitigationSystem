#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    28.04.13                        Praveen Shukla                                Matter View.

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
#endregion

#region   ********Page Controls *************************

public partial class Matter_Dashboards_LawyerDashBoard :BasePage
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    LawyerDashBoardLogic LDBL = new LawyerDashBoardLogic();
    Common_Message commessage = new Common_Message();
    SaveHearings SH = new SaveHearings();
    HearingLogic HD = new HearingLogic();
    MatterDetails MD = new MatterDetails();
    static int EMP_ID;
    static string USERID;
    #endregion

    
    #region   ******** Page Load *************************
    protected void Page_Load(object sender, EventArgs e)
    {
        
        GetSession();
       
        if (!IsPostBack)
        {
            LoginCss_load();

        }
    }
    #endregion

    #region   ********Css Load *************************
    protected void LoginCss_load()
    {
        //TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
        Panel pnlarebic = this.Master.FindControl("pnlArebic") as Panel;
        Panel pnlEnlish = this.Master.FindControl("pnlEnlish") as Panel;
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {

            lnkCSS.Attributes["href"] = "../../css/generalArebic.css";
            //MatterTreeView.Attributes["ImageSet"] = "rtl";
            pnlarebic.Visible = false;
            pnlEnlish.Visible = true;


        }
        else
        {
            lnkCSS.Attributes["href"] = "../../css/generalEnglish.css";
            //MatterTreeView.Attributes["ImageSet"] = "ltr";
            pnlarebic.Visible = true;
            pnlEnlish.Visible = false;

        }


    

        BindAllMatter();
        BindHearings();
        BindPleadings();
        BindAppeals_Casssation();
        BindAlerts();
        AllMatter();
        AllCases();
        AllStatus();
        AllClient();
        pleadingdata();
        ddlEmployeedata();
        getRightInformation();



    }
    #endregion

    #region   *********************************Matter Grid Operation *************************************************
    private void BindAllMatter()
    {

        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.GetAllMatterView_Arabic(EMP_ID);
        }
        else
        {
            dt = LDBL.GetAllMatterView_English(EMP_ID);
        }
        if (dt.Rows.Count > 0)
        {
            MatterGrid.DataSource = dt;
            MatterGrid.DataBind();
        }
        else
        {
            MatterGrid.DataSource = null;
            MatterGrid.DataBind();
        }
    }
    protected void MatterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        MatterGrid.PageIndex = e.NewPageIndex;
        BindAllMatter();
    }
    protected void Page_Change(object sender, GridViewPageEventArgs e)
    {
        MatterGrid.PageIndex = e.NewPageIndex;
        BindAllMatter();

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
        //lblcase.Text = "";
        int index = MatterGrid.SelectedIndex;
        lbl.Text = MatterGrid.DataKeys[index].Value.ToString();
        BindHearings();
        BindPleadings();
        BindAppeals_Casssation();
        BindAlerts();
        TreeNodePopulate();
        //lbl.Text = "";
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
    protected void DtgViewStage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                 //Get reference to button field in the gridview.  
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "Select$" + e.Row.RowIndex);
                e.Row.Style["cursor"] = "hand";
                e.Row.Attributes["onclick"] = _jsSingle;
            }
        }



    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in MatterGrid.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
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

    #region   *********************************Hearing Grid Operation *************************************************
    private void BindHearings()
    {
        if (lbl.Text != "")
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetupcomingHearing_Arabic_Matter(EMP_ID, Convert.ToInt32(lbl.Text));
            }
            else
            {
                dt = LDBL.GetupcomingHearing_English_Matter(EMP_ID,Convert.ToInt32(lbl.Text));
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
        else
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
        lblpleadingCaseno.Text = selectedRow.Cells[3].Text.ToString();
        lblcase.Text = DtgUpcomingHearings.DataKeys[index].Value.ToString();
        //BindHearings();
        BindPleadings();
        BindAppeals_Casssation();
        BindAlerts();
        lblcase.Text = "";
        
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
        if (lbl.Text != "")
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetUnpreparedPleading_English(Convert.ToInt32(lbl.Text));
            }
            else
            {
                dt = LDBL.GetUnpreparedPleading_English(Convert.ToInt32(lbl.Text));
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
        else
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

    #region   *********************************Appeals/CAssation Operation *************************************************
    private void BindAppeals_Casssation()
    {
        if (lbl.Text != "")
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetupcomingAppeal_Cassastion_Arabic(Convert.ToInt32(lbl.Text));
            }
            else
            {
                dt = LDBL.GetupcomingAppeal_Cassastion_English(Convert.ToInt32(lbl.Text));
            }
            if (dt.Rows.Count > 0)
            {
                dtgAppeals_Cassation.DataSource = dt;
                dtgAppeals_Cassation.DataBind();
            }
            else
            {
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
            }
        }
        else
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetupcomingAppeals_Cassastions_Arabic(EMP_ID);
            }
            else
            {
                dt = LDBL.GetupcomingAppeals_Cassastions_English(EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {
                dtgAppeals_Cassation.DataSource = dt;
                dtgAppeals_Cassation.DataBind();
            }
            else
            {
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
            }

        }
        if (lblcase.Text != "")
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.GetupcomingAppeals_Cassastions_Case_Arabic(Convert.ToInt32(lblcase.Text));
            }
            else
            {
                dt = LDBL.GetupcomingAppeals_Cassastions_Case_English(Convert.ToInt32(lblcase.Text));
            }
            if (dt.Rows.Count > 0)
            {
                dtgAppeals_Cassation.DataSource = dt;
                dtgAppeals_Cassation.DataBind();
            }
            else
            {
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
            }
        }
    }
    protected void dtgAppeals_Cassation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgAppeals_Cassation.PageIndex = e.NewPageIndex;
        BindAppeals_Casssation();
    }
    protected void dtgAppeals_Cassation_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void dtgAppeals_Cassation_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = dtgAppeals_Cassation.SelectedIndex;
        //Response.Redirect("~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id=" + MatterGrid.DataKeys[index].Value.ToString());
    }
    protected void dtgAppeals_Cassation_RowDataBound(object sender, GridViewRowEventArgs e)
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

    #region   *********************************Alerts And Notification Grid Operation *************************************************
    private void BindAlerts()
    {
        if (lbl.Text != "")
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.Alert_Arabic(Convert.ToInt32(lbl.Text));
            }
            else
            {
                dt = LDBL.Alert_English(Convert.ToInt32(lbl.Text));
            }
            if (dt.Rows.Count > 0)
            {
                dtgAlerts.DataSource = dt;
                dtgAlerts.DataBind();
            }
            else
            {
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
            }
        }
        else
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = LDBL.Alerts_Arabic(EMP_ID);
            }
            else
            {
                dt = LDBL.Alerts_English(EMP_ID);
            }
            if (dt.Rows.Count > 0)
            {
                dtgAlerts.DataSource = dt;
                dtgAlerts.DataBind();
            }
            else
            {
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
            }

        }
    }
    protected void dtgAlerts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgAlerts.PageIndex = e.NewPageIndex;
        BindAlerts();
    }
    protected void dtgAlerts_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void dtgAlerts_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = dtgAlerts.SelectedIndex;
        //Response.Redirect("~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id=" + MatterGrid.DataKeys[index].Value.ToString());
    }
    protected void dtgAlerts_RowDataBound(object sender, GridViewRowEventArgs e)
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

    #region   *********************************Click On Show All Button *************************************************
    protected void lnlshowAllMatter_Click(object sender, EventArgs e)
    {
        //BindAllMatter();
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.GetAllMatterView_Arabic(EMP_ID);
        }
        else
        {
            dt = LDBL.GetAllMatterView_English(EMP_ID);
        }
        if (dt.Rows.Count > 0)
        {
            MatterGrid.DataSource = dt;
            MatterGrid.DataBind();
        }
        else
        {
            MatterGrid.DataSource = null;
            MatterGrid.DataBind();
        }
        ddlcase.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        ddlMatter.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
    }
    protected void lnlHearingShowAll_Click(object sender, EventArgs e)
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

        //BindHearings();
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
        //BindAppeals_Casssation();
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.GetupcomingAppeals_Cassastions_Arabic(EMP_ID);
        }
        else
        {
            dt = LDBL.GetupcomingAppeals_Cassastions_English(EMP_ID);
        }
        if (dt.Rows.Count > 0)
        {
            dtgAppeals_Cassation.DataSource = dt;
            dtgAppeals_Cassation.DataBind();
        }
        else
        {
            dtgAppeals_Cassation.DataSource = null;
            dtgAppeals_Cassation.DataBind();
        }
        ddlcase.SelectedIndex = 0;
        ddlclient.SelectedIndex = 0;
        ddlMatter.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
    }
    protected void lnkalerts_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = LDBL.Alerts_Arabic(EMP_ID);
        }
        else
        {
            dt = LDBL.Alerts_English(EMP_ID);
        }
        if (dt.Rows.Count > 0)
        {
            dtgAlerts.DataSource = dt;
            dtgAlerts.DataBind();
        }
        else
        {
            dtgAlerts.DataSource = null;
            dtgAlerts.DataBind();
        }
        //BindAlerts();
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
                if (ddlMatter.SelectedIndex != 0)
                {
                    if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                    {
                        dt = LDBL.GetupcomingHearing_Arabic_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    else
                    {
                        dt = LDBL.GetupcomingHearing_English_Matter(EMP_ID,Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        DtgUpcomingHearings.DataSource = dt;
                        DtgUpcomingHearings.DataBind();
                        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                        {
                            dt = LDBL.GetupcomingHearing_Arabic_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }
                        else
                        {
                            dt = LDBL.GetupcomingHearing_English_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }

                        if (dt.Rows.Count > 0)
                        {

                            DtgUpcomingHearings.DataSource = dt;
                            DtgUpcomingHearings.DataBind();
                        }
                    }
                    else
                    {
                        DtgUpcomingHearings.DataSource = null;
                        DtgUpcomingHearings.DataBind();
                        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                        {
                            dt = LDBL.GetupcomingHearing_Arabic_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }
                        else
                        {
                            dt = LDBL.GetupcomingHearing_English_Matter(EMP_ID, Convert.ToInt32(ddlMatter.SelectedValue));
                        }

                        if (dt.Rows.Count > 0)
                        {

                            DtgUpcomingHearings.DataSource = dt;
                            DtgUpcomingHearings.DataBind();
                        }
                    }
                }
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
                    }
                    else
                    {
                        dtgUnpreparedPleadings.DataSource = null;
                        dtgUnpreparedPleadings.DataBind();
                    }
                }
                if (ddlMatter.SelectedIndex != 0)
                {
                    if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                    {
                        dt = LDBL.GetupcomingAppeal_Cassastion_Arabic(Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    else
                    {
                        dt = LDBL.GetupcomingAppeal_Cassastion_English(Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        dtgAppeals_Cassation.DataSource = dt;
                        dtgAppeals_Cassation.DataBind();
                    }
                    else
                    {
                        dtgAppeals_Cassation.DataSource = null;
                        dtgAppeals_Cassation.DataBind();
                    }
                }
                if (ddlMatter.SelectedIndex != 0)
                {
                    if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                    {
                        dt = LDBL.Alert_Arabic(Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    else
                    {
                        dt = LDBL.Alert_English(Convert.ToInt32(ddlMatter.SelectedValue));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        dtgAlerts.DataSource = dt;
                        dtgAlerts.DataBind();
                    }
                    else
                    {
                        dtgAlerts.DataSource = null;
                        dtgAlerts.DataBind();
                    }
                }
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
            }
        }
        if (ddlMatter.SelectedIndex != 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
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
                if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
                {
                    if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
                    {
                        dt = LDBL.GetupcomingAppeals_Cassastions_Case_Arabic(Convert.ToInt32(ddlcase.SelectedValue));
                    }
                    else
                    {
                        dt = LDBL.GetupcomingAppeals_Cassastions_Case_English(Convert.ToInt32(ddlcase.SelectedValue));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        dtgAppeals_Cassation.DataSource = dt;
                        dtgAppeals_Cassation.DataBind();
                    }
                    else
                    {
                        dtgAppeals_Cassation.DataSource = null;
                        dtgAppeals_Cassation.DataBind();
                    }
                }
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
            }
        }

        if (ddlMatter.SelectedIndex != 0 && ddlcase.SelectedIndex != 0 && ddlclient.SelectedIndex != 0 && ddlStatus.SelectedIndex == 0)
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
            }
        }


        if (ddlMatter.SelectedIndex == 0 && ddlcase.SelectedIndex == 0 && ddlclient.SelectedIndex == 0 && ddlStatus.SelectedIndex != 0)
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
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
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
            }
            else
            {
                MatterGrid.DataSource = null;
                MatterGrid.DataBind();
                DtgUpcomingHearings.DataSource = null;
                DtgUpcomingHearings.DataBind();
                dtgUnpreparedPleadings.DataSource = null;
                dtgUnpreparedPleadings.DataBind();
                dtgAppeals_Cassation.DataSource = null;
                dtgAppeals_Cassation.DataBind();
                dtgAlerts.DataSource = null;
                dtgAlerts.DataBind();
            }
        }

    }
 

    #endregion

    #region   ********CreatePleadings *************************
    protected void CreatePleading_Click(object sender, EventArgs e)
    {
        if (lblpleadingCaseno.Text != "")
        {
            if (ddlpladingsst.SelectedIndex != 0)
            {
                if (ddlplpreaparedby.SelectedIndex != 0)
                {
                    if (ddlreviewby.SelectedIndex != 0)
                    {
                        string Mode = "INSERT";

                        int i = SH.PleadingAction(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlpladingsst.SelectedValue), Convert.ToInt32(ddlplpreaparedby.SelectedValue), Convert.ToDateTime(txtpladingdate.Text), Convert.ToInt32(ddlreviewby.SelectedValue), Mode);
                        if (i > 0)
                        {

                            txtpladingdate.Text = "";
                            ddlpladingsst.SelectedIndex = 0;
                            ddlplpreaparedby.SelectedIndex = 0;
                            ddlreviewby.SelectedIndex = 0;
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                        }
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Slect Employee", 125, 300);
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Slect Status", 125, 300);
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Slect Outcome", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Case.", 125, 300);
        }

    }
    #endregion

    #region   ********Dropdown Lists For Create Pleadings *************************

    public void pleadingdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = HD.PleadingArabic();
        }
        else
        {
            dt = HD.PleadingEnlish();
        }
        if (dt.Rows.Count > 0)
        {

            ddlpladingsst.DataSource = dt;
            ddlpladingsst.DataBind();
            ddlpladingsst.Items.Insert(0, new ListItem(""));
        }
    }


    public void ddlEmployeedata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = HD.GetAllEmployeeArabic();
        }
        else
        {
            dt = HD.GetAllEmployeeEnlish();
        }
        if (dt.Rows.Count > 0)
        {

            ddlplpreaparedby.DataSource = dt;
            ddlplpreaparedby.DataBind();
            ddlreviewby.DataSource = dt;
            ddlreviewby.DataBind();
            ddlreviewby.Items.Insert(0, new ListItem(""));
            ddlplpreaparedby.Items.Insert(0, new ListItem(""));


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
                    CreatePleadings.Visible = true;
                }

            }
        }
    }
    #endregion

}
#endregion