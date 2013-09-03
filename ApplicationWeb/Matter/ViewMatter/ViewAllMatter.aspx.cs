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
public partial class Matter_ViewMatter_ViewAllMatter : BasePage
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    MatterView MV = new MatterView();
    SaveMatter SV = new SaveMatter();
    MatterDetails MDetails = new MatterDetails();
    Common_Message commessage = new Common_Message();
    static int EMPID;
    static string USERID;

    #endregion

    #region   ******** Page Load *************************
    protected void Page_Load(object sender, EventArgs e)
    {

        GetSession();
        if (!IsPostBack)
        {

            LoginCss_load();
            BindMatterType();
            OfficeName();
            AllMatterNumber();
            AllMatterNumberFromMatter();
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
        BindAllMatter();
        BindAllEmployee();
        BindAllstages();
        BindAllStatus();
        getRightInformation();

    }
    #endregion

    #region   *******PublicFunction*************************
    private void AllMatterNumberFromMatter()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MV.MatterNumberFromMatter();
        }
        else
        {
            dt = MV.MatterNumberFromMatter();
        }
        if (dt.Rows.Count > 0)
        {

            ddlCloseMatter.DataSource = dt;
            ddlCloseMatter.DataBind();
            ddlFallowerMatter.DataSource = dt;
            ddlFallowerMatter.DataBind();
            ddlCloseMatter.Items.Insert(0, new ListItem(""));
            ddlFallowerMatter.Items.Insert(0, new ListItem(""));
        }
    }
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
    private void OfficeName()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = SV.GetAllOfficArabic();
        }
        else
        {
            dt = SV.GetAllOfficEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlOfficeName.DataSource = dt;
            ddlOfficeName.DataBind();
            ddlOfficeName.Items.Insert(0, new ListItem(""));
        }
    }
    private void BindAllMatter()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MV.GetAllMatterView_Arabic();
        }
        else
        {
            dt = MV.GetAllMatterView_English();
        }
        if (dt.Rows.Count > 0)
        {
            MatterGrid.DataSource = dt;
            MatterGrid.DataBind();
        }
    }
    private void BindAllStatus()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {

            dt = MV.GetAllStatusArebic();
        }
        else
        {
            dt = MV.GetAllStatusEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlcMatterStatusdata.DataSource = dt;
            ddlcMatterStatusdata.DataBind();
            ddlStatus.DataSource = dt;
            ddlStatus.DataBind();
            ddlcMatterStatusdata.Items.Insert(0, new ListItem(""));
            ddlStatus.Items.Insert(0, new ListItem(""));
        }
    }
    private void BindAllEmployee()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MV.GetAllEmployeeArebic();
        }
        else
        {
            dt = MV.GetAllEmployeeEnlish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlemp.DataSource = dt;
            ddlemp.DataBind();
            ddlSuperWiseSerach.DataSource = dt;
            ddlSuperWiseSerach.DataBind();
            ddlAssignedSearch.DataSource = dt;
            ddlAssignedSearch.DataBind();
            ddlAssignedSearch.Items.Insert(0, new ListItem(""));
            ddlSuperWiseSerach.Items.Insert(0, new ListItem(""));
            ddlemp.Items.Insert(0, new ListItem(""));

        }
    }
    private void BindAllstages()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MV.GetAllStagesArebic();
        }
        else
        {
            dt = MV.GetAllStagesEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            //ddlstage.DataSource = dt;
            //ddlstage.DataBind();
            //ddlstage.Items.Insert(0, new ListItem(""));
        }
    }
    private void BindMatterType()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = MV.GetMTYPEArebic();
        }
        else
        {
            dt = MV.GetMTYPEEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlMatterType.DataSource = dt;
            ddlMatterType.DataBind();
            ddlMatterType.Items.Insert(0, new ListItem(""));
        }
    }
    protected void Get_MatterOverView(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        GridViewRow Gvr = lnk.NamingContainer as GridViewRow;
        string id = MatterGrid.DataKeys[Gvr.RowIndex]["Matter_Id"].ToString();
        //lblClientName.Text = id.ToString();
        //lblMatterNo.Text = "TestMatter";
    }
    #endregion

    #region   *********************************Grid Operation *************************************************
    protected void GridSerach_data(object sender, EventArgs e)
    {
        if (txtserach.Text != "")
        {
            dt = MV.SearchGrid(txtserach.Text);
            if (dt.Rows.Count > 0)
            {
                MatterGrid.DataSource = dt;
                MatterGrid.DataBind();
                //MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,+dt.Rows.Count+" Record Found.", 125, 300);
            }
            else
            {
                // MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.NoRecordFound, 125, 300);
            }

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

        int index = MatterGrid.SelectedIndex;
        Session["ID"] = MatterGrid.DataKeys[index].Value.ToString();
        lbl.Text = MatterGrid.DataKeys[index].Value.ToString();
        //Response.Redirect("~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id=" + MatterGrid.DataKeys[index].Value.ToString());
        TreeNodePopulate();
        ddlSuperWiseSerach.SelectedIndex = 0;
        ddlAssignedSearch.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        ddlMatterType.SelectedIndex = 0;
        txtserach.Text = "";
    }
    private void TreeNodePopulate()
    {
        dt = MDetails.GetSpecficSearch(lbl.Text);
        if (dt.Rows.Count > 0)
        {
            TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
            MatterTreeView.Nodes[0].Text = dt.Rows[0]["Matter_number"].ToString();
            MatterTreeView.Nodes[0].ChildNodes[0].NavigateUrl = "~/Matter/Stage/StageDetails.aspx?Matter_Id=" + lbl.Text;
            MatterTreeView.Nodes[0].ChildNodes[1].NavigateUrl = "~/Matter/Cases/CasesDetails.aspx?Matter_Id=" + lbl.Text +"&Case_ID="+0;
            MatterTreeView.Nodes[0].ChildNodes[2].NavigateUrl = "~/Matter/Hearings/Hearings.aspx?Matter_Id=" + lbl.Text +"&Hearing_ID="+0;
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
        foreach (GridViewRow row in MatterGrid.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
    }
    #endregion

    #region *******************************Search_Window******************************
    private void Serach()
    {
        if (ddlSuperWiseSerach.SelectedIndex == 0 && ddlAssignedSearch.SelectedIndex != 0 && ddlMatterType.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
        {
            dt = MV.AssignedLawyerSearch(ddlAssignedSearch.SelectedValue);
        }
        if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlMatterType.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
        {
            dt = MV.SupervisiorLawyerSearch(ddlSuperWiseSerach.SelectedValue);
        }

        else if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex == 0)
        {
            dt = MV.Assigned_Matter(ddlAssignedSearch.SelectedValue, ddlMatterType.SelectedValue);
        }

        else if (ddlSuperWiseSerach.SelectedIndex == 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex == 0)
        {
            dt = MV.MatterTypeSearch(ddlMatterType.SelectedValue);
        }
        else if (ddlSuperWiseSerach.SelectedIndex == 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlMatterType.SelectedIndex == 0 && ddlStatus.SelectedIndex != 0)
        {
            dt = MV.StatusSearch(ddlStatus.SelectedValue);
        }

        else if (ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlSuperWiseSerach.SelectedIndex == 0)
        {
            dt = MV.Matter_status(ddlStatus.SelectedValue, ddlStatus.SelectedValue);
        }

        #region ************Superwisedropdown**************
        else if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex != 0 && ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0)
        {
            dt = MV.Assigned_superwiser_Matter_status(ddlAssignedSearch.SelectedValue, ddlSuperWiseSerach.SelectedValue, ddlMatterType.SelectedValue, ddlStatus.SelectedValue);
        }
        else if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex != 0 && ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex == 0)
        {
            dt = MV.Assigned_superwiser_Matter(ddlAssignedSearch.SelectedValue, ddlSuperWiseSerach.SelectedValue, ddlMatterType.SelectedValue);
        }
        else if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex != 0 && ddlStatus.SelectedIndex == 0 && ddlMatterType.SelectedIndex == 0)
        {
            dt = MV.Assigned_superwiser(ddlAssignedSearch.SelectedValue, ddlSuperWiseSerach.SelectedValue);
        }

        else if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex == 0)
        {
            dt = MV.superwiser_Matter_status(ddlSuperWiseSerach.SelectedValue, ddlMatterType.SelectedValue, ddlStatus.SelectedValue);
        }
        else if (ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlSuperWiseSerach.SelectedIndex == 0)
        {
            dt = MV.Matter_status(ddlMatterType.SelectedValue, ddlStatus.SelectedValue);
        }
        else if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlMatterType.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlStatus.SelectedIndex == 0)
        {
            dt = MV.superwiser_Matter(ddlSuperWiseSerach.SelectedValue, ddlMatterType.SelectedValue);
        }

        else if (ddlSuperWiseSerach.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0 && ddlAssignedSearch.SelectedIndex == 0 && ddlMatterType.SelectedIndex == 0)
        {
            dt = MV.superwiser_status(ddlSuperWiseSerach.SelectedValue, ddlStatus.SelectedValue);
        }

        else if (ddlSuperWiseSerach.SelectedIndex == 0 && ddlAssignedSearch.SelectedIndex != 0 && ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex != 0)
        {
            dt = MV.Assigned_Matter_status(ddlAssignedSearch.SelectedValue, ddlMatterType.SelectedValue, ddlStatus.SelectedValue);
        }

        else if (ddlSuperWiseSerach.SelectedIndex == 0 && ddlAssignedSearch.SelectedIndex != 0 && ddlMatterType.SelectedIndex != 0 && ddlStatus.SelectedIndex == 0)
        {
            dt = MV.Assigned_Matter(ddlAssignedSearch.SelectedValue, ddlMatterType.SelectedValue);
        }
        else if (ddlSuperWiseSerach.SelectedIndex == 0 && ddlAssignedSearch.SelectedIndex != 0 && ddlMatterType.SelectedIndex == 0 && ddlStatus.SelectedIndex != 0)
        {
            dt = MV.Assigned_status(ddlAssignedSearch.SelectedValue, ddlStatus.SelectedValue);
        }

        #endregion
        MatterGrid.DataSource = dt;
        MatterGrid.DataBind();
    }

    #endregion

    #region ******************************Search_DropDown******************************
    protected void ddlSuperWiseSerach_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtserach.Text = "";
        Serach();
    }
    protected void ddlMatterType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtserach.Text = "";
        Serach();
    }
    protected void ddlstage_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtserach.Text = "";
        Serach();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtserach.Text = "";
        Serach();
    }
    protected void ddlAssignedSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtserach.Text = "";
        Serach();
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
    protected void GetMatterDetailsClose(object sender, EventArgs e)
    {
        dt = MV.CloseMatterDetails(ddlCloseMatter.SelectedItem.ToString());
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
            lblcleintdata.Text = "";
            lblResponsibalelawyerdata.Text = "";
            lblAssignedLawyerdata.Text = "";
            lblmattertypedata.Text = "";
            txtOpenDate.Text = "";
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.NoRecordFound, 125, 300);
        }
    }
    #endregion

    #region   ********OpertaionContract*************************
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
                            int j = SV.AuditMatter(1, Mode, USERID);
                            //lblcleintdata.Text = "";
                            //lblResponsibalelawyerdata.Text = "";
                            //lblAssignedLawyerdata.Text = "";
                            //lblmattertypedata.Text = "";
                            //txtOpenDate.Text = "";
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
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please Select Office Name.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please Select the Matter Number.", 125, 300);
        }

    }
    protected void btnCloseMatter_Click(object sender, EventArgs e)
    {
        string Mode = "UPDATE";
        if (ddlCloseMatter.SelectedIndex != 0)
        {
            if (ddlcMatterStatusdata.SelectedIndex != 0)
            {
                string parameter2 = "";
                int i = MV.MatterClose(ddlCloseMatter.SelectedItem.ToString(), Convert.ToInt32(ddlcMatterStatusdata.SelectedValue), Mode, out parameter2);
                if (i > 0)
                {
                    ddlCloseMatter.SelectedIndex = 0;
                    ddlcMatterStatusdata.SelectedIndex = 0;
                    int j = SV.AuditMatter(Convert.ToInt32(ddlCloseMatter.SelectedValue.ToString()), Mode, USERID);
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning, parameter2, 125, 300);
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please Select status.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, "Please Select Matter number.", 125, 300);
        }
    }
    protected void AddFallower_Click(object sender, EventArgs e)
    {
        if (ddlFallowerMatter.SelectedIndex != 0)
        {
            if (ddlemp.SelectedIndex != 0)
            {
                string Mode = "INSERT";
                int i = MDetails.AddFallower(Convert.ToInt32(ddlemp.SelectedValue), Convert.ToInt32(ddlFallowerMatter.SelectedValue), Mode);
                if (i > 0)
                {
                    ddlemp.SelectedIndex = 0;
                    BindFallowerGrid();
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning, "Please Select Employee Name.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning, "Please Select Matter.", 125, 300);
        }

    }
    protected void Delete_Fallower(object sender, GridViewDeleteEventArgs e)
    {
        int FallowerID = (int)DtgFallower.DataKeys[e.RowIndex].Value;
        string Mode = "DELETE";
        int i = MDetails.DeleteFallower(FallowerID, Mode);
        if (i > 0)
        {
            BindFallowerGrid();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning, commessage.DeletedRecord, 125, 300);
        }
    }

    #endregion

    #region   *******BindGrid Falllower*************************
    protected void GetFallower(object sender, EventArgs e)
    {
        BindFallowerGrid();
    }


    protected void BindFallowerGrid()
    {
        dt = MDetails.FallowerGrid(Convert.ToInt32(ddlFallowerMatter.SelectedValue));
        if (dt.Rows.Count > 0)
        {
            DtgFallower.DataSource = dt;
            DtgFallower.DataBind();
        }
        else
        {
            DtgFallower.DataSource = null;
            DtgFallower.DataBind();
        }
    }


    #endregion

    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = MV.RightsDetails(EMPID);
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

    #region **************Click on Show All*********************
    protected void lnkshowAll_Click(object sender, EventArgs e)
    {
        BindAllMatter();
        ddlMatterType.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        ddlSuperWiseSerach.SelectedIndex = 0;
        ddlAssignedSearch.SelectedIndex = 0;
        txtserach.Text = "";
    }
    #endregion
}
#endregion