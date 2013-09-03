#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    04.06.13                        Praveen Shukla                                HearingsInformation
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
public partial class Matter_Hearings_Hearings : BasePage
{
    #region   ********  Public Declaration *************************
    ResponeHelper ResponeHelper = new ResponeHelper();
    DataTable dt = new DataTable();
    SaveHearings SH = new SaveHearings();
    HearingLogic HD = new HearingLogic();
    Common_Message commessage = new Common_Message();
    static int EMPID;
    static string USERID;
    static string PleadingDocket;
    static string ClientDocket;
    static string opponentgDocket;
    static string JudgementDocket;
    #endregion
    #region   ******** Page Load *************************
    protected void Page_Load(object sender, EventArgs e)
    {
        GetSession();
             
        if (!IsPostBack)
        {
           
            if (Request.QueryString["Hearing_ID"].ToString() != null)
            {
                lbl.Text = Request.QueryString["Hearing_ID"].ToString();
                GetHearingDetails();
                lbl.Text = "";
            }
            LoginCss_load();
            if (Session["ID"] != null)
            {
                string M_id = Session["ID"].ToString();
                dt = HD.GetSpecficSearch(M_id);
                if (dt.Rows.Count > 0)
                {

                    TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
                    Label lblMatterNo = this.Master.FindControl("lblMatterNo") as Label;
                    MatterTreeView.Nodes[0].Text = dt.Rows[0]["Matter_number"].ToString();

                    lblMatterhearing.Text = dt.Rows[0]["Matter_number"].ToString();
                    txtdelmatterno.Text = dt.Rows[0]["Matter_number"].ToString();
                    //MatterTreeView.Nodes[0].ChildNodes[0].Text = "Stage("+(5)+")";
                    //MatterTreeView.Nodes[0].ChildNodes[1].Text = "Cases(" + (3) + ")";
                    //MatterTreeView.Nodes[0].ChildNodes[2].Text = "Hearings(" + (4) + ")";
                    //MatterTreeView.Nodes[0].ChildNodes[3].Text = "POA & Fee Details(" + (1) + ")";
                    MatterTreeView.Nodes[0].ChildNodes[0].NavigateUrl = "~/Matter/Stage/StageDetails.aspx?Matter_Id=" + M_id;
                    MatterTreeView.Nodes[0].ChildNodes[1].NavigateUrl = "~/Matter/Cases/CasesDetails.aspx?Matter_Id=" + M_id + "&Case_ID=" + 0;
                    MatterTreeView.Nodes[0].ChildNodes[2].NavigateUrl = "~/Matter/Hearings/Hearings.aspx?Matter_Id=" + M_id + "&Hearing_ID=" + 0;
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
        Hearing_Grid();
        ddlEmployeedata();
        HearingOutcome();
        Hearingstatusdata();
        Judgementdata();
        pleadingdata();
        getRightInformation();



    }
    #endregion
    #region   ********Hearing  Grid Data Bind *************************
    public void Hearing_Grid()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = HD.HearingGridArabic();
        }
        else
        {
            dt = HD.HearingGridEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            dtgHearingGrid.DataSource = dt;
            dtgHearingGrid.DataBind();
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
    protected void dtgHearingGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow selectedRow = dtgHearingGrid.SelectedRow;
        //caseno.Text = selectedRow.Cells[2].Text.ToString();
        //CaseNo_AddHearings.Text = selectedRow.Cells[2].Text.ToString(); ;
        int index = dtgHearingGrid.SelectedIndex;
        lbl.Text = dtgHearingGrid.DataKeys[index].Value.ToString();
        lblMatterCase.Text = selectedRow.Cells[2].Text.ToString();
        lbldocumentcaseno.Text = selectedRow.Cells[2].Text.ToString();
        lblpleadingCaseno.Text = selectedRow.Cells[2].Text.ToString();
        txtDecisionCaseno.Text = selectedRow.Cells[2].Text.ToString();
        lblJudgementcaseno.Text = selectedRow.Cells[2].Text.ToString();
        string @Matter_number = "";
        int i = SH.MATTERNOFROMCASE(Convert.ToInt32(lbl.Text), out @Matter_number);
        lblMatterhearing.Text = @Matter_number;
        txtdelmatterno.Text = @Matter_number;
        Hearing_Grid();
        GetHearingDetails();
    }
    protected void dtgHearingGrid_RowDataBound(object sender, GridViewRowEventArgs e)
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
        foreach (GridViewRow row in dtgHearingGrid.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
    }
    protected void dtgHearingGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgHearingGrid.PageIndex = e.NewPageIndex;
        Hearing_Grid();
    }
    #endregion
    #region   ********Dropdown Lists *************************
    public void Hearingstatusdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = HD.HearingStatusArabic();
        }
        else
        {
            dt = HD.HearingStatusEnlish();
        }
        if (dt.Rows.Count > 0)
        {
            ddlstatus.DataSource = dt;
            ddlstatus.DataBind();
            ddlHearingStaus.DataSource = dt;
            ddlHearingStaus.DataBind();
            ddlstatus.Items.Insert(0, new ListItem(""));
            ddlHearingStaus.Items.Insert(0, new ListItem(""));
            delddlstatus.DataSource = dt;
            delddlstatus.DataBind();
            delddlstatus.Items.Insert(0, new ListItem(""));
        }
    }
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
            ddlpleading.DataSource = dt;
            ddlpleading.DataBind();
            ddlpladingsst.DataSource = dt;
            ddlpladingsst.DataBind();
            ddlpleading.Items.Insert(0, new ListItem(""));
            ddlpladingsst.Items.Insert(0, new ListItem(""));
        }
    }
    public void HearingOutcome()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = HD.HearingOutcomeArabic();
        }
        else
        {
            dt = HD.HearingOutcomeEnlish();
        }
        if (dt.Rows.Count > 0)
        {

            ddlHearingoutcome.DataSource = dt;
            ddlHearingoutcome.DataBind();
            ddlDecisionoutcome.DataSource = dt;
            ddlDecisionoutcome.DataBind();
            ddlHearingoutcome.Items.Insert(0, new ListItem(""));
            ddlDecisionoutcome.Items.Insert(0, new ListItem(""));

        }
    }
    public void Judgementdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = HD.JudgementArabic();
        }
        else
        {
            dt = HD.JudgementEnlish();
        }
        if (dt.Rows.Count > 0)
        {
            ddljudgment.DataSource = dt;
            ddljudgment.DataBind();
            ddlJudgements.DataSource = dt;
            ddlJudgements.DataBind();
            ddljudgment.Items.Insert(0, new ListItem(""));
            ddlJudgements.Items.Insert(0, new ListItem(""));
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
            ddlAttendedby.DataSource = dt;
            ddlAttendedby.DataBind();
            ddlprerparedby.DataSource = dt;
            ddlprerparedby.DataBind();
            ddlplpreaparedby.DataSource = dt;
            ddlplpreaparedby.DataBind();
            ddlreviewby.DataSource = dt;
            ddlreviewby.DataBind();
            ddlAttendby.DataSource = dt;
            ddlAttendby.DataBind();
            delddlattendedby.DataSource = dt;
            delddlattendedby.DataBind();

            ddlreviewby.Items.Insert(0, new ListItem(""));
            ddlAttendedby.Items.Insert(0, new ListItem(""));
            ddlprerparedby.Items.Insert(0, new ListItem(""));
            ddlplpreaparedby.Items.Insert(0, new ListItem(""));
            ddlAttendby.Items.Insert(0, new ListItem(""));
            delddlattendedby.Items.Insert(0, new ListItem(""));
        }
    }


    #endregion
    #region   ********Hearing Details*************************
    protected void GetHearingDetails()
    {
        if (lbl.Text != "")
        {
            #region*********************Hearing Details************************
            dt = HD.HearingDetails(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {
                txtcaseno.Text = dt.Rows[0]["Case_number"].ToString();
                txthearingdate.Text = Convert.ToDateTime(dt.Rows[0]["Hearing_date"]).ToString("dd-MMM-yyyy");
                ddlstatus.SelectedValue = dt.Rows[0]["Hearing_Staus_Id"].ToString();
                ddlAttendedby.SelectedValue = dt.Rows[0]["Attend_Empl_Id"].ToString();
                txthearingNotes.Text = dt.Rows[0]["Hearings_Notes"].ToString();
                if (dt.Rows[0]["Pleading_status_id"].ToString() != "")
                {
                    ddlpleading.SelectedValue = dt.Rows[0]["Pleading_status_id"].ToString();
                }
                else
                {
                    ddlpleading.SelectedIndex = 0;
                }
                if (dt.Rows[0]["Reviewed_by"].ToString() != "")
                {
                    ddlprerparedby.SelectedValue = dt.Rows[0]["Reviewed_by"].ToString();
                }
                else
                {
                    ddlprerparedby.SelectedIndex = 0;
                }
                if (dt.Rows[0]["Created_date"].ToString() != "")
                {
                    lbldateprepared.Text = Convert.ToDateTime(dt.Rows[0]["Created_date"]).ToString("dd-MMM-yyyy");
                }
                else
                {
                    lbldateprepared.Text = "";
                }
                lblreview.Text = dt.Rows[0]["Reviewed_by"].ToString();
                if (dt.Rows[0]["Created_date"].ToString() != "")
                {
                    lblpleadingsdate.Text = Convert.ToDateTime(dt.Rows[0]["Reviewed_Date"]).ToString("dd-MMM-yyyy");
                }
                else
                {
                    lblpleadingsdate.Text = "";
                }
                if (dt.Rows[0]["Hearing_outcome_ID"].ToString() != "")
                {
                    ddlHearingoutcome.SelectedValue = dt.Rows[0]["Hearing_outcome_ID"].ToString();
                }
                else
                {
                }
                txthearingdetails.Text = dt.Rows[0]["Decision_Details"].ToString();
                if (dt.Rows[0]["Judgement_OutCome_ID"].ToString() != "")
                {
                    ddljudgment.SelectedValue = dt.Rows[0]["Judgement_OutCome_ID"].ToString();
                }
                else
                {
                    ddljudgment.SelectedIndex = 0;
                }
                if (dt.Rows[0]["Date_Judgement"].ToString() != "")
                {
                    txtjudgementdate.Text = Convert.ToDateTime(dt.Rows[0]["Date_Judgement"]).ToString("dd-MMM-yyyy");
                }
                else
                {
                    txtjudgementdate.Text = "";
                }
                //DeleteHearings
                txtdelcaseid.Text = dt.Rows[0]["Case_number"].ToString();
                txtdelhearingdate.Text = Convert.ToDateTime(dt.Rows[0]["Hearing_date"]).ToString("dd-MMM-yyyy");
                delddlstatus.SelectedValue = dt.Rows[0]["Hearing_Staus_Id"].ToString();
                delddlattendedby.SelectedValue = dt.Rows[0]["Attend_Empl_Id"].ToString();
                txtdelhearingsnotes.Text = dt.Rows[0]["Hearings_Notes"].ToString();
                linkJudgement.Text = dt.Rows[0]["Judgement_doc"].ToString();
                LinkbtnClientDocket.Text = dt.Rows[0]["Client_Docket"].ToString();
                LinkbtnClientOpponent.Text = dt.Rows[0]["oppenet_Docket"].ToString();
                LinkPleadingDocument.Text = dt.Rows[0]["Pleading_document"].ToString();
            }
            #endregion
        }
    }

    #endregion
    #region   ********Operation Contarct*************************
    protected void Addhearing_Click(object sender, EventArgs e)
    {
        if (lblMatterCase.Text != "0000")
        {

            if (ddlHearingStaus.SelectedIndex != 0)
            {
                if (ddlAttendby.SelectedIndex != 0)
                {
                    string Mode = "INSERT";

                    int i = SH.HearingsAction(lblMatterCase.Text, Convert.ToDateTime(txthearngDate.Text), Convert.ToInt32(ddlAttendby.SelectedValue), Convert.ToInt32(ddlHearingStaus.SelectedValue), txthearingNotes.Text, Mode);
                    if (i > 0)
                    {
                        int j = SH.AuditHearings(Convert.ToInt32(lbl.Text), Mode, USERID);
                        txthearngDate.Text = "";
                        txthearingNotes.Text = "";
                        ddlHearingStaus.SelectedIndex = 0;
                        ddlAttendby.SelectedIndex = 0;
                        Hearing_Grid();
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
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Case.", 125, 300);
        }

    }
    protected void CreatePleading_Click(object sender, EventArgs e)
    {
        if (lbl.Text != "")
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
                                int K = SH.AuditPleadings(Convert.ToInt32(lbl.Text), Mode, USERID);
                                txtpladingdate.Text = "";
                                ddlpladingsst.SelectedIndex = 0;
                                ddlplpreaparedby.SelectedIndex = 0;
                                ddlreviewby.SelectedIndex = 0;
                                Hearing_Grid();
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
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "No Hearing Found.", 125, 300);
        }

    }
    protected void AddJudgement_Click(object sender, EventArgs e)
    {
        if (lbl.Text != "")
        {

                #region**********************Check Decision Details***********
            dt = SH.ChkDecision(Convert.ToInt32(lbl.Text));
            if (Convert.ToString(dt.Rows[0][0]) != "")
            {
            #endregion
                #region***************Add Judgement Details*********************************
                if (lblJudgementcaseno.Text != "")
                {
                    if (ddlJudgements.SelectedIndex != 0)
                    {
                        string Mode = "INSERT";

                        int i = SH.JudgementAction(Convert.ToInt32(ddlJudgements.SelectedValue), JudgementDocket, Convert.ToInt32(lbl.Text), Convert.ToDateTime(judgementdate.Text), (txtJudgementDeatils.Text), Mode);
                        if (i > 0)
                        {
                            int j = SH.AuditJudgement(Convert.ToInt32(lbl.Text), Mode, USERID);
                            ddlJudgements.SelectedIndex = 0;
                            JudgementDocket = "";
                            judgementdate.Text = "";
                            txtJudgementDeatils.Text = "";
                            Hearing_Grid();
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                        }
                    }
                    else
                    {
                        ddlJudgements.SelectedIndex = 0;
                        JudgementDocket = "";
                        judgementdate.Text = "";
                        txtJudgementDeatils.Text = "";
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Slect Judgement.", 125, 300);
                    }

                }
                else
                {
                    ddlJudgements.SelectedIndex = 0;
                    JudgementDocket = "";
                    judgementdate.Text = "";
                    txtJudgementDeatils.Text = "";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Selec the Case.", 125, 300);
                }
                #endregion
            }
            else
            {

                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Add the Decision Details First.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Case/Hearing Not Fond .", 125, 300);
        }

    }
    protected void AddDecision_Click(object sender, EventArgs e)
    {

        if (txtDecisionCaseno.Text != "")
        {
            if (ddlDecisionoutcome.SelectedIndex != 0)
            {
                string Mode = "INSERT";

                int i = SH.DecisionAction(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlDecisionoutcome.SelectedValue), txtDecisiondetails.Text, Mode);
                if (i > 0)
                {
                    int j = SH.AuditHearings(Convert.ToInt32(lbl.Text), Mode, USERID);
                    ddlDecisionoutcome.SelectedIndex = 0;
                    txtDecisiondetails.Text = "";
                    Hearing_Grid();
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Slect Judgement.", 125, 300);
            }

        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Selec the Case.", 125, 300);
        }

    }
    protected void Deletehearing_Click(object sender, EventArgs e)
    {
        if (lblMatterCase.Text != "0000")
        {
            if (lbl.Text != "")
            {
                dt = SH.ChkDecision(Convert.ToInt32(lbl.Text));
                if (Convert.ToString(dt.Rows[0][0]) != "")
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Heraings is under process.", 125, 300);

                }
                else
                {
                    string Mode = "DELETE";

                    int i = SH.DeleteHearings(Convert.ToInt32(lbl.Text), Mode);
                    if (i > 0)
                    {
                        int j = SH.AuditHearings(Convert.ToInt32(lbl.Text), Mode, USERID);
                        Hearing_Grid();
                        lbl.Text = "";
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.DeletedRecord, 125, 300);
                    }

                }

            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Case.", 125, 300);
            }
        }

    }
    protected void hearingDocument_Click(object sender, EventArgs e)
    {
        if (lbl.Text != "")
        {
            if (lbldocumentcaseno.Text != "0000")
            {
                string Mode = "UPDATE";
                string @Hearingerror = "";
                int i = SH.AddHearingDocument(Convert.ToInt32(lbl.Text), ClientDocket, opponentgDocket, PleadingDocket, Mode, out @Hearingerror);
                if (i > 0)
                {
                    int j = SH.AuditHearings(Convert.ToInt32(lbl.Text), Mode, USERID);
                    int K = SH.AuditPleadings(Convert.ToInt32(lbl.Text), Mode, USERID);
                    Hearing_Grid();
                    lbl.Text = "";
                    ClientDocket = "";
                    opponentgDocket = "";
                    PleadingDocket = "";
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.DeletedRecord, 125, 300);
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, @Hearingerror, 125, 300);
                }
            }
        }
    }

       
    #endregion
    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = HD.RightsDetails(EMPID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i][0].ToString() == "New Hearings")
                {
                    AddHearing.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Create Pleadings")
                {
                    Createpleading.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Add Decision")
                {
                    Adddecisions.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Add Judgement")
                {
                    Addjudgement.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Add Document")
                {
                    Adddocument.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Delete Hearings")
                {
                    DelHearings.Visible = true;
                }

            }
        }
    }
    #endregion

    #region**********************FIle Uploader Client,opponent and pleadings**************************
    protected void FileUploadCompletePleading(object sender, EventArgs e)
    {
        if (lbldocumentcaseno.Text.ToString() != "")
        {
            string filename = System.IO.Path.GetFileName(FileUploadPleading.FileName);
            FileUploadPleading.SaveAs(Server.MapPath("~/Upload_Document/" + lbldocumentcaseno.Text + "_" + filename));
            PleadingDocket = lbldocumentcaseno.Text + "_" + filename;
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Case no", 125, 300);
        }
    }
    protected void FileUploadCompleteClient(object sender, EventArgs e)
    {
        if (lbldocumentcaseno.Text.ToString() != "")
        {
            string filename = System.IO.Path.GetFileName(FileUploadClient.FileName);
            FileUploadClient.SaveAs(Server.MapPath("~/Upload_Document/" + lbldocumentcaseno.Text + "_" + filename));
            ClientDocket = lbldocumentcaseno.Text + "_" + filename;
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Case no", 125, 300);
        }
    }
    protected void FileUploadCompleteOpponent(object sender, EventArgs e)
    {
        if (lbldocumentcaseno.Text.ToString() != "")
        {
            string filename = System.IO.Path.GetFileName(FileUploadOpponent.FileName);
            FileUploadOpponent.SaveAs(Server.MapPath("~/Upload_Document/" + lbldocumentcaseno.Text + "_" + filename));
            opponentgDocket = lbldocumentcaseno.Text + "_" + filename;
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Case no", 125, 300);
        }
    }
    protected void FileUploadCompleteJudge(object sender, EventArgs e)
    {
        if (lbldocumentcaseno.Text.ToString() != "")
        {
            string filename = System.IO.Path.GetFileName(FileuploadJudgement.FileName);
            FileuploadJudgement.SaveAs(Server.MapPath("~/Upload_Document/" + lbldocumentcaseno.Text + "_" + filename));
            JudgementDocket = lbldocumentcaseno.Text + "_" + filename;
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Case no", 125, 300);
        }
    }
    protected void LinkbtnClientDocket_Click(object sender, EventArgs e)
    {
        string Path = LinkbtnClientDocket.Text;
        ResponeHelper.ResponseHelper.Redirect("~/Upload_Document/" + Path + "", "_blank", "");
        //Response.Redirect("~/Upload_Document/" + Path + "");
        
    }
    protected void LinkbtnClientOpponent_Click(object sender, EventArgs e)
    {
        string Path = LinkbtnClientOpponent.Text;
        ResponeHelper.ResponseHelper.Redirect("~/Upload_Document/" + Path + "", "_blank", "");
    }
    protected void LinkPleadingDocument_Click(object sender, EventArgs e)
    {
        string Path = LinkPleadingDocument.Text;
        ResponeHelper.ResponseHelper.Redirect("~/Upload_Document/" + Path + "", "_blank", "");
    }
    protected void linkJudgement_Click(object sender, EventArgs e)
    {
        string Path = linkJudgement.Text;
        ResponeHelper.ResponseHelper.Redirect("~/Upload_Document/" + Path + "", "_blank", "menubar=0,width=400,height=400");
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