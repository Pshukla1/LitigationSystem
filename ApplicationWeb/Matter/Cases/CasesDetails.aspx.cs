#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    03.06.13                        Praveen Shukla                                Case SpecificInformation.

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
using System.Data;
using System.Web.UI.HtmlControls;
using LitigationClearkLogic;
#endregion

#region   ********Page Controls *************************
public partial class Matter_Cases_Cases : BasePage
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    CaseDetails CD = new CaseDetails();
    SaveCases CS = new SaveCases();
    SaveHearings SH = new SaveHearings();
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
            
            if (Request.QueryString["Case_ID"].ToString() != null)
            {
                lbl.Text = Request.QueryString["Case_ID"].ToString();
                Case_Data();
                lbl.Text = "";
            }
            LoginCss_load();
            if (Session["ID"] != null)
            {
              
                string M_id = Session["ID"].ToString();
                dt = CD.GetSpecficSearch(M_id);
                if (dt.Rows.Count > 0)
                {

                    TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
                    Label lblMatterNo = this.Master.FindControl("lblMatterNo") as Label;
                    MatterTreeView.Nodes[0].Text = dt.Rows[0]["Matter_number"].ToString();
                    //MatterTreeView.Nodes[0].ChildNodes[0].Text = "Stage("+(5)+")";
                    //MatterTreeView.Nodes[0].ChildNodes[1].Text = "Cases(" + (3) + ")";
                    //MatterTreeView.Nodes[0].ChildNodes[2].Text = "Hearings(" + (4) + ")";
                    //MatterTreeView.Nodes[0].ChildNodes[3].Text = "POA & Fee Details(" + (1) + ")";

                    lblCasematterNum.Text = dt.Rows[0]["Matter_number"].ToString();
                    txtAMatternumber.Text = dt.Rows[0]["Matter_number"].ToString();
                    lblMatterhearing.Text = dt.Rows[0]["Matter_number"].ToString();
                    txtdelmatterno.Text = dt.Rows[0]["Matter_number"].ToString();
                    MatterTreeView.Nodes[0].ChildNodes[0].NavigateUrl = "~/Matter/Stage/StageDetails.aspx?Matter_Id=" + M_id;
                    MatterTreeView.Nodes[0].ChildNodes[1].NavigateUrl = "~/Matter/Cases/CasesDetails.aspx?Matter_Id=" + M_id + "&Case_ID=" + 0;
                    MatterTreeView.Nodes[0].ChildNodes[2].NavigateUrl = "~/Matter/Hearings/Hearings.aspx?Matter_Id=" + lbl.Text + "&Hearing_ID=" + 0;
                    MatterTreeView.Nodes[0].ChildNodes[3].NavigateUrl = "~/Matter/ViewMatter/FeeDetailsandPOA.aspx?Matter_Id=" + M_id;
                    MatterTreeView.Nodes[0].ChildNodes[4].NavigateUrl = "~/Matter/ViewMatter/Parties.aspx?Matter_Id=" + M_id;
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
        ddlCtypedata();
        ddlstagedata();
        ddlstatusdata();
        ddldepartmentdata();
        ddlcapcity();
        ddlEmployeedata();
        ddljudgedata();
        ddlcourtdata();
        Hearingstatusdata();
        ddlCasestagedata();
        Case_Grid();
        getRightInformation();
    }
    #endregion
    #region   ********Case Grid Data Bind *************************
    public void Case_Grid()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.CaseGridArabic();
        }
        else
        {
            dt = CD.CaseGridEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            dtgCaseGrid.DataSource = dt;
            dtgCaseGrid.DataBind();
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
    protected void dtgCaseGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow selectedRow = dtgCaseGrid.SelectedRow;
        caseno.Text = selectedRow.Cells[2].Text.ToString();

        CaseNo_AddHearings.Text = selectedRow.Cells[2].Text.ToString();
        int index = dtgCaseGrid.SelectedIndex;
        lbl.Text = dtgCaseGrid.DataKeys[index].Value.ToString();
        string @Matter_number = "";
        int i = CS.MATTERNOFROMCASE(Convert.ToInt32(lbl.Text), out @Matter_number);
        lblCasematterNum.Text = @Matter_number;
        txtAMatternumber.Text = @Matter_number;
        lblMatterhearing.Text = @Matter_number;
        txtdelmatterno.Text = @Matter_number;
         Case_Data();
    }
    protected void dtgCaseGrid_RowDataBound(object sender, GridViewRowEventArgs e)
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

    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in dtgCaseGrid.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
    }
    protected void dtgCaseGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgCaseGrid.PageIndex = e.NewPageIndex;
        Case_Grid();
    }
    #endregion
    #region   ********Dropdown Lists *************************
    public void ddlCtypedata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.CasetypeArabic();
        }
        else
        {
            dt = CD.CasetypeEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlcasetype.DataSource = dt;
            ddlcasetype.DataBind();
            ddlacasetype.DataSource = dt;
            ddlacasetype.DataBind();
            ddlcasetypedata.DataSource = dt;
            ddlcasetypedata.DataBind();
            delddlcasetype.DataSource = dt;
            delddlcasetype.DataBind();
            ddlcasetype.Items.Insert(0, new ListItem(""));
            ddlacasetype.Items.Insert(0, new ListItem(""));
            ddlcasetypedata.Items.Insert(0, new ListItem(""));
            delddlcasetype.Items.Insert(0, new ListItem(""));
        }
    }
    public void ddlstatusdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.GetAllStatusArabic();
        }
        else
        {
            dt = CD.GetAllStatusEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlstatus.DataSource = dt;
            ddlstatus.DataBind();
            ddlcaseStatus.DataSource = dt;
            ddlcaseStatus.DataBind();
            ddlstatus.Items.Insert(0, new ListItem(""));
            ddlcaseStatus.Items.Insert(0, new ListItem(""));


        }
    }
    public void ddlstagedata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.GetAllStagesArabic();
        }
        else
        {
            dt = CD.GetAllStagesEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlstage.DataSource = dt;
            ddlstage.DataBind();
            ddlastage.DataSource = dt;
            ddlastage.DataBind();
            delddlstage.DataSource = dt;
            delddlstage.DataBind();
            ddlstage.Items.Insert(0, new ListItem(""));
            ddlastage.Items.Insert(0, new ListItem(""));
            delddlstage.Items.Insert(0, new ListItem(""));


        }
    }
    public void ddlCasestagedata()
    {
        if (Session["ID"] != null)
        {
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = CS.MatterStagesArabic(Convert.ToInt32(Session["ID"].ToString()));
            }
            else
            {
                dt = CS.MatterStagesEnglish(Convert.ToInt32(Session["ID"].ToString()));
            }
            if (dt.Rows.Count > 0)
            {

                ddlCasestage.DataSource = dt;
                ddlCasestage.DataBind();
                ddlCasestage.Items.Insert(0, new ListItem(""));


            }
        }
    }
    public void ddldepartmentdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.DepartmentArabic();
        }
        else
        {
            dt = CD.DepartmentEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            ddldepartment.DataSource = dt;
            ddldepartment.DataBind();
            ddladeptname.DataSource = dt;
            ddladeptname.DataBind();
            ddlDepartmentADDPOPUP.DataSource = dt;
            ddlDepartmentADDPOPUP.DataBind();
            delddldepartnent.DataSource = dt;
            delddldepartnent.DataBind();
            ddldepartment.Items.Insert(0, new ListItem(""));
            ddladeptname.Items.Insert(0, new ListItem(""));
            ddlDepartmentADDPOPUP.Items.Insert(0, new ListItem(""));
            delddldepartnent.Items.Insert(0, new ListItem(""));

        }
    }
    public void ddlcapcity()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.Client_oppnent_Capcity_Arebic();
        }
        else
        {
            dt = CD.Client_opponent_Capcity_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddlclientCap.DataSource = dt;
            ddlclientCap.DataBind();
            ddlopponentCap.DataSource = dt;
            ddlopponentCap.DataBind();
            ddlAclientcap.DataSource = dt;
            ddlAclientcap.DataBind();
            ddlaoppcap.DataSource = dt;
            ddlaoppcap.DataBind();
            ddlClientCapty.DataSource = dt;
            ddlClientCapty.DataBind();
            ddlOppCap.DataSource = dt;
            ddlOppCap.DataBind();
            delddlcapcityopp.DataSource = dt;
            delddlcapcityopp.DataBind();
            delddlcapcityclient.DataSource = dt;
            delddlcapcityclient.DataBind();
            ddlclientCap.Items.Insert(0, new ListItem(""));
            ddlopponentCap.Items.Insert(0, new ListItem(""));
            ddlAclientcap.Items.Insert(0, new ListItem(""));
            ddlaoppcap.Items.Insert(0, new ListItem(""));
            ddlClientCapty.Items.Insert(0, new ListItem(""));
            ddlOppCap.Items.Insert(0, new ListItem(""));
            delddlcapcityopp.Items.Insert(0, new ListItem(""));
            delddlcapcityclient.Items.Insert(0, new ListItem(""));
        }
    }
    public void ddlEmployeedata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.GetAllEmployeeArebic();
        }
        else
        {
            dt = CD.GetAllEmployeeEnlish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlcourtcleark.DataSource = dt;
            ddlcourtcleark.DataBind();
            ddlclerkname.DataSource = dt;
            ddlclerkname.DataBind();
            dddAcourtclek.DataSource = dt;
            dddAcourtclek.DataBind();
            ddlAttendby.DataSource = dt;
            ddlAttendby.DataBind();
            delddlcourtclerk.DataSource = dt;
            delddlcourtclerk.DataBind();
            ddlcourtcleark.Items.Insert(0, new ListItem(""));
            ddlclerkname.Items.Insert(0, new ListItem(""));
            dddAcourtclek.Items.Insert(0, new ListItem(""));
            ddlAttendby.Items.Insert(0, new ListItem(""));
            delddlcourtclerk.Items.Insert(0, new ListItem(""));

        }
    }
    public void ddlcourtdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.CourtName_Arabic();
        }
        else
        {
            dt = CD.CourtName_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddlcourt.DataSource = dt;
            ddlcourt.DataBind();
            ddlacourt.DataSource = dt;
            ddlacourt.DataBind();
            ddlcourtname.DataSource = dt;
            ddlcourtname.DataBind();
            delddlcourt.DataSource = dt;
            delddlcourt.DataBind();
            ddlcourt.Items.Insert(0, new ListItem(""));
            ddlacourt.Items.Insert(0, new ListItem(""));
            ddlcourtname.Items.Insert(0, new ListItem(""));
            delddlcourt.Items.Insert(0, new ListItem(""));
        }
    }
    public void ddljudgedata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.JudgeName_Arabic();
        }
        else
        {
            dt = CD.JudgeName_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddljudge.DataSource = dt;
            ddljudge.DataBind();
            ddljudgename.DataSource = dt;
            ddljudgename.DataBind();
            ddlajudge.DataSource = dt;
            ddlajudge.DataBind();
            delddljudge.DataSource = dt;
            delddljudge.DataBind();
            ddljudge.Items.Insert(0, new ListItem(""));
            ddljudgename.Items.Insert(0, new ListItem(""));
            ddlajudge.Items.Insert(0, new ListItem(""));
            delddljudge.Items.Insert(0, new ListItem(""));
        }
    }
    public void Hearingstatusdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = CD.HearingStatusArabic();
        }
        else
        {
            dt = CD.HearingStatusEnlish();
        }
        if (dt.Rows.Count > 0)
        {

            ddlHearingStaus.DataSource = dt;
            ddlHearingStaus.DataBind();
            ddlHearingStaus.Items.Insert(0, new ListItem(""));
            
        }
    }
    #endregion
    #region   ********Case Details *************************

    protected void Case_Data()
    {
        
        dt = CD.ClickCaseGrid(Convert.ToInt32(lbl.Text));
        if (dt.Rows.Count > 0)
        {
            txtcaseno.Text = dt.Rows[0]["Case_number"].ToString();
            ddlcasetype.SelectedValue = dt.Rows[0]["Case_Type_ID"].ToString();
            ddlstatus.SelectedValue = dt.Rows[0]["Status_ID"].ToString();
            ddlstage.SelectedValue = dt.Rows[0]["Stage_Type_ID"].ToString();
            txtfillingdate.Text = Convert.ToDateTime(dt.Rows[0]["Registration_Date"]).ToString("dd-MMM-yyyy");
            txtenddate.Text = Convert.ToDateTime(dt.Rows[0]["End_date"]).ToString("dd-MMM-yyyy");
            ddlcourt.SelectedValue = dt.Rows[0]["Court_Id"].ToString();
            ddlcourtcleark.SelectedValue = dt.Rows[0]["Court_Cleark_ID"].ToString();
            ddlclientCap.SelectedValue = dt.Rows[0]["Client_Capcity_ID"].ToString();
            ddlopponentCap.SelectedValue = dt.Rows[0]["Opponents_Capcity_ID"].ToString();
            ddljudge.SelectedValue = dt.Rows[0]["Judge_Id"].ToString();
            ddldepartment.SelectedValue = dt.Rows[0]["Department_Id"].ToString();
            txthallNumber.Text = dt.Rows[0]["Hall_number"].ToString();

            ddlastage.SelectedValue = dt.Rows[0]["Stage_Type_ID"].ToString();
            dddAcourtclek.SelectedValue = dt.Rows[0]["Court_Cleark_ID"].ToString();
            txtacase.Text = dt.Rows[0]["Case_number"].ToString();
            ddlacasetype.SelectedValue = dt.Rows[0]["Case_Type_ID"].ToString();
            txtafillinddate.Text = Convert.ToDateTime(dt.Rows[0]["Registration_Date"]).ToString("dd-MMM-yyyy");
            txtaEnddate.Text = Convert.ToDateTime(dt.Rows[0]["End_date"]).ToString("dd-MMM-yyyy");
            ddlAclientcap.SelectedValue = dt.Rows[0]["Client_Capcity_ID"].ToString();
            ddlaoppcap.SelectedValue = dt.Rows[0]["Opponents_Capcity_ID"].ToString();
            txtahallnumner.Text = dt.Rows[0]["Hall_number"].ToString();
            ddladeptname.SelectedValue = dt.Rows[0]["Department_Id"].ToString();
            ddlajudge.SelectedValue = dt.Rows[0]["Judge_Id"].ToString();
            ddlacourt.SelectedValue = dt.Rows[0]["Court_Id"].ToString();
            txtadiscription.Text = dt.Rows[0]["Court_Id"].ToString();

            //DELETE CASE
            delddlstage.SelectedValue = dt.Rows[0]["Stage_Type_ID"].ToString();
            delddlcourtclerk.SelectedValue = dt.Rows[0]["Court_Cleark_ID"].ToString();
            txtdelcaseno.Text = dt.Rows[0]["Case_number"].ToString();
            delddlcasetype.SelectedValue = dt.Rows[0]["Case_Type_ID"].ToString();
            txtdelfillingdate.Text = Convert.ToDateTime(dt.Rows[0]["Registration_Date"]).ToString("dd-MMM-yyyy");
            txtdelenddate.Text = Convert.ToDateTime(dt.Rows[0]["End_date"]).ToString("dd-MMM-yyyy");
            delddlcapcityclient.SelectedValue = dt.Rows[0]["Client_Capcity_ID"].ToString();
            delddlcapcityopp.SelectedValue = dt.Rows[0]["Opponents_Capcity_ID"].ToString();
            txtdelhallno.Text = dt.Rows[0]["Hall_number"].ToString();
            delddldepartnent.SelectedValue = dt.Rows[0]["Department_Id"].ToString();
            delddljudge.SelectedValue = dt.Rows[0]["Judge_Id"].ToString();
            delddlcourt.SelectedValue = dt.Rows[0]["Court_Id"].ToString();
            txtdeldiscription.Text = dt.Rows[0]["Court_Id"].ToString();
        }
    }

    #endregion
    #region   ********Operation Contarct*************************
    protected void AddCase_Click(object sender, EventArgs e)
    {

        string Mode = "INSERT";
        if (lblCasematterNum.Text != "")
        {
            if (ddlCasestage.SelectedIndex != 0)
            {
                if (ddlclerkname.SelectedIndex != 0)
                {
                    if (ddlcasetypedata.SelectedIndex != 0)
                    {
                        if (ddlClientCapty.SelectedIndex != 0)
                        {
                            if (ddlOppCap.SelectedIndex != 0)
                            {
                                if (ddlDepartmentADDPOPUP.SelectedIndex != 0)
                                {
                                    if (ddljudgename.SelectedIndex != 0)
                                    {
                                        if (ddlcourtname.SelectedIndex != 0)
                                        {
                                            int i = CS.CaseAction(txtcasenumber.Text, Convert.ToInt32(ddlcourtname.SelectedValue), Convert.ToInt32(ddljudgename.Text), Convert.ToInt32(ddlClientCapty.SelectedValue), Convert.ToInt32(ddlOppCap.SelectedValue),
                                                txtxCasediscription.Text, Convert.ToDateTime(txtfillindatde.Text), Convert.ToDateTime(txtEdate.Text), Convert.ToInt32(ddlCasestage.SelectedValue), Convert.ToInt32(ddlclerkname.SelectedValue), Convert.ToInt32(ddlcasetypedata.SelectedValue),
                                                1, txtHallnoADDPoPUP.Text, Convert.ToInt32(ddlDepartmentADDPOPUP.SelectedValue), Mode);
                                            if (i > 0)
                                            {
                                                int j = CS.AuditCase(1, Mode, USERID);
                                                ddlCasestage.SelectedIndex = 0;
                                                ddlclerkname.SelectedIndex = 0;
                                                txtcasenumber.Text = "";
                                                ddlcasetypedata.SelectedIndex = 0;
                                                txtfillindatde.Text = "";
                                                txtEdate.Text = "";
                                                ddlClientCapty.SelectedIndex = 0;
                                                ddlOppCap.SelectedIndex = 0;
                                                txtHallnoADDPoPUP.Text = "";
                                                ddlDepartmentADDPOPUP.SelectedIndex = 0;
                                                ddljudgename.SelectedIndex = 0;
                                                ddlcourtname.SelectedIndex = 0;
                                                txtxCasediscription.Text = "";
                                                Case_Grid();
                                                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                                            }
                                        }
                                        else
                                        {
                                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Court.", 125, 300);
                                        }
                                    }
                                    else
                                    {
                                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Judge.", 125, 300);
                                    }
                                }
                                else
                                {
                                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select department.", 125, 300);
                                }
                            }
                            else
                            {
                                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Opponent Capacity.", 125, 300);
                            }
                        }
                        else
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Client Capacity.", 125, 300);
                        }
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Case type.", 125, 300);
                    }
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Clerk name.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select stage.", 125, 300);
        }
    }
    protected void CloseCase_Click(object sender, EventArgs e)
    {

        string Mode = "UPDATE";
        if (lbl.Text != "")
        {
            dt = CS.CaseChk(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Case is under judgement.", 125, 300);
            }
            else
            {
                if (ddlcaseStatus.SelectedIndex != 0)
                {
                    int i = CS.CloseCaseAction(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlcaseStatus.SelectedValue), Mode);
                    if (i > 0)
                    {
                        int j = CS.AuditCase(Convert.ToInt32(lbl.Text), Mode, USERID);
                        Case_Grid();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.UpdatedRecord, 125, 300);

                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Status.", 125, 300);
                }
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Case.", 125, 300);
        }
    }
    protected void Addhearing_Click(object sender, EventArgs e)
    {
        if (CaseNo_AddHearings.Text != "0000")
        {

            if (ddlHearingStaus.SelectedIndex != 0)
            {
                if (ddlAttendby.SelectedIndex != 0)
                {
                    string Mode = "INSERT";
                    if (ddlHearingStaus.SelectedIndex != 0)
                    {
                        if (ddlAttendby.SelectedIndex != 0)
                        {
                            int i = SH.HearingsAction(lbl.Text, Convert.ToDateTime(txthearngDate.Text), Convert.ToInt32(ddlAttendby.SelectedValue), Convert.ToInt32(ddlHearingStaus.SelectedValue), txtHearingsNotes.Text, Mode);
                            if (i > 0)
                            {
                                int j = SH.AuditHearings(Convert.ToInt32(lbl.Text), Mode, USERID);
                                txthearngDate.Text = "";
                                txtHearingsNotes.Text = "";
                                ddlHearingStaus.SelectedIndex = 0;
                                ddlAttendby.SelectedIndex = 0;
                                Case_Grid();
                                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                            }
                        }
                        else
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,"Please Select Employee", 125, 300);
                        }
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success,"Please select status", 125, 300);
                    }
                }
                else
                {
                    txthearngDate.Text = "";
                    txtHearingsNotes.Text = "";
                    ddlHearingStaus.SelectedIndex = 0;
                    ddlAttendby.SelectedIndex = 0;
                    Case_Grid();
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Slect Employee", 125, 300);
                }
            }
            else
            {
                txthearngDate.Text = "";
                txtHearingsNotes.Text = "";
                ddlHearingStaus.SelectedIndex = 0;
                ddlAttendby.SelectedIndex = 0;
                Case_Grid();
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Slect Status", 125, 300);
            }


        }
        else
        {
            txthearngDate.Text = "";
            txtHearingsNotes.Text = "";
            ddlHearingStaus.SelectedIndex = 0;
            ddlAttendby.SelectedIndex = 0;
            Case_Grid();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Case.", 125, 300);
        }

    }
    protected void DeleteCase_Click(object sender, EventArgs e)
    {

        string Mode = "DELETE";
        if (lbl.Text != "")
        {
            dt = CS.CaseChk(Convert.ToInt32(lbl.Text));
            if (Convert.ToString(dt.Rows[0][0]) != "")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Case is under judgement.", 125, 300);
            }
            else
            {
                if (ddlcaseStatus.SelectedIndex != 0)
                {

                    int i = CS.CloseCaseAction(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlcaseStatus.SelectedValue), Mode);
                    if (i > 0)
                    {
                        int j = CS.AuditCase(Convert.ToInt32(lbl.Text), Mode, USERID);
                        Case_Grid();
                        lbl.Text = "";
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.DeletedRecord, 125, 300);

                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Status.", 125, 300);
                }
            }
            
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Case.", 125, 300);
        }
    }
    #endregion

    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = CD.RightsDetails(EMPID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i][0].ToString() == "Add Case")
                {
                    Addcase.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Close Case")
                {
                    Closecase.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Add Hearings")
                {
                    Addhearing.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Delete Case")
                {
                    DelCase.Visible = true;
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
}
#endregion

