#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    18.06.13                        Praveen Shukla                                Fees Details and POA.

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
using System.IO;
#endregion

#region   ********Page Controls *************************

public partial class Matter_ViewMatter_FeeDetailsandPOA : BasePage
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    ViewStageLogic VSL = new ViewStageLogic();
    MatterDetails MDetails = new MatterDetails();
    SaveStage SV = new SaveStage();
    SaveMatter SM = new SaveMatter();
    FeeAndPOALogic FPL = new FeeAndPOALogic();
    Common_Message commessage = new Common_Message();
    static int EMPID;
    static string M_id;
    static string USERID;
    static string Filepath;
    #endregion

    #region   ******** Page Load *************************
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        GetSession();
        if (!IsPostBack)
        {
            
            LoginCss_load();
            if (Session["ID"] != null)
            {

                M_id = Request.QueryString["Matter_Id"].ToString();
                dt = VSL.GetSpecficSearch(M_id);
                if (dt.Rows.Count > 0)
                {

                    TreeView MatterTreeView = this.Master.FindControl("MatterTreeView") as TreeView;
                    Label lblMatterNo = this.Master.FindControl("lblMatterNo") as Label;
                    MatterTreeView.Nodes[0].Text = dt.Rows[0]["Matter_number"].ToString();
                    //MatterTreeView.Nodes[0].ChildNodes[0].Text = "Stage("+(5)+")";
                    //MatterTreeView.Nodes[0].ChildNodes[1].Text = "Cases(" + (3) + ")";
                    //MatterTreeView.Nodes[0].ChildNodes[2].Text = "Hearings(" + (4) + ")";
                    //MatterTreeView.Nodes[0].ChildNodes[3].Text = "POA & Fee Details(" + (1) + ")";
                    lblPOAmatterno.Text = dt.Rows[0]["Matter_number"].ToString();
                    txtMatterno.Text = dt.Rows[0]["Matter_number"].ToString();
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

        getRightInformation();
        MatterView();
        AllPOALocation();
        AllPOATYpes();
    }
    #endregion

    #region   ********FEE DETAILS GRID Grid*************************
    public void MatterView()
    {
        dt = FPL.MatterView();
        //dt = VSL.ViewStage("1");
        if (dt.Rows.Count > 0)
        {
            DtgMatter.DataSource = dt;
            DtgMatter.DataBind();
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
    protected void DtgMatter_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = DtgMatter.SelectedIndex;
        lbl.Text = DtgMatter.DataKeys[index].Value.ToString();
        FessDetails();
    }
    protected void DtgMatter_RowDataBound(object sender, GridViewRowEventArgs e)
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
        foreach (GridViewRow row in DtgMatter.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
    }
    protected void DtgMatter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DtgMatter.PageIndex = e.NewPageIndex;
        MatterView();
    }
    #endregion

   

    #region   ********OpertaionContract*************************
    protected void btnAddFeeDetails_Click(object sender, EventArgs e)
    {
       
        string Mode = "UPDATE";
        if (lbl.Text.ToString() != "")
        {
           
            
            int i = FPL.AddFeedetails(Convert.ToInt32(lbl.Text), Convert.ToInt32(txtFeeamonut.Text), Convert.ToInt32(txtSucessFess.Text), txtFeeDiscription.Text, txtFeeEstimate.Text, Filepath, Mode);
            if (i > 0)
            {
                int j = SM.AuditMatter(Convert.ToInt32(lbl.Text), Mode, USERID);
                Filepath = "";
                txtFeeamonut.Text = "";
                txtSucessFess.Text = "";
                txtFeeDiscription.Text = "";
                txtFeeEstimate.Text = "";
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Record.", 125, 300);
        }
    }
    protected void btnAddPOAS_Click(object sender, EventArgs e)
    {
        string Mode = "INSERT";
        if (lbl.Text.ToString() != "")
        {
            dt = FPL.PartyID(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {
                if (ddlPOATypes.SelectedIndex != 0)
                {
                    if (ddlLocation.SelectedIndex != 0)
                    {
                        int i = FPL.AddPoas(Convert.ToInt32(dt.Rows[0][0]), Convert.ToInt32(ddlPOATypes.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), "", Convert.ToDateTime(txtissuedate.Text), Mode);
                        if (i > 0)
                        {
                            ddlPOATypes.SelectedIndex = 0;
                            ddlLocation.SelectedIndex = 0;
                            txtissuedate.Text = "";
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
                        }
                    }
                    else
                    {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Location.", 125, 300);
                    }
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Type.", 125, 300);
                }
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Record.", 125, 300);
        }

    }

    #endregion

    #region   ********Stage Dropdown*************************
    private void AllPOALocation()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = FPL.Location_Arebic();
        }
        else
        {
            dt = FPL.Location_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddlLocation.DataSource = dt;
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem(""));
        }
    }
    private void AllPOATYpes()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = FPL.POATYPE_Arebic();
        }
        else
        {
            dt = FPL.POATYPE_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddlPOATypes.DataSource = dt;
            ddlPOATypes.DataBind();
            ddlPOATypes.Items.Insert(0, new ListItem(""));

        }
    }

    #endregion

    #region   ********POA AND FEES DETAILS*************************
    private void BindPOAGrid()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = FPL.POAGRID_Arebic(Convert.ToInt32(lbl.Text));
        }
        else
        {
            dt = FPL.POAGRID_English(Convert.ToInt32(lbl.Text));
        }
        if (dt.Rows.Count > 0)
        {
            dtgPOAGRID.DataSource = dt;
            dtgPOAGRID.DataBind();
        }
        else
        {
            dtgPOAGRID.DataSource = null;
            dtgPOAGRID.DataBind();
        }
    }
    private void FessDetails()
    {
        dt = FPL.GetFeeDetails(Convert.ToInt32(lbl.Text));
        if (dt.Rows.Count > 0)
        {
            txtSucessFess.Text = dt.Rows[0]["Sucess_Fees"].ToString();
            txtFeeamonut.Text = dt.Rows[0]["ClaimAmount"].ToString();
            txtFeeEstimate.Text = dt.Rows[0]["Fees_Estimate"].ToString();
            txtFeeDiscription.Text = dt.Rows[0]["Fee_details"].ToString();
            linkfeedocument.Text = dt.Rows[0]["Fees_Document"].ToString();

            DtxtSucessFess.Text = dt.Rows[0]["Sucess_Fees"].ToString();
            DtxtFeeamonut.Text = dt.Rows[0]["ClaimAmount"].ToString();
            DtxtFeeEstimate.Text = dt.Rows[0]["Fees_Estimate"].ToString();
            DtxtFeeDiscription.Text = dt.Rows[0]["Fee_details"].ToString();
            BindPOAGrid();
        }
    }
    #endregion

    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = FPL.RightsDetails(EMPID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "Add Fee")
                {
                    Addfee.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Add POA")
                {
                    AddPOA.Visible = true;
                }
               

            }
        }
    }
    #endregion

    #region**********************FIle Uploader For Fess And POA.**************************
    protected void FileUploadComplete(object sender, EventArgs e)
    {
        if (lbl.Text.ToString() != "")
        {
            string filename = System.IO.Path.GetFileName(FileFeeAgreement.FileName);
            FileFeeAgreement.SaveAs(Server.MapPath("~/Upload_Document/" + txtMatterno.Text + "_" + filename));
            Filepath = txtMatterno.Text + "_" + filename;
        }
    }
    protected void openFIle(object sender, EventArgs e)
    {
        string Path = linkfeedocument.Text;
        ResponeHelper.ResponseHelper.Redirect("~/Upload_Document/" + Path + "", "_blank", "");
        //Response.Redirect("~/Upload_Document/"+Path+"");
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