#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    20.06.13                        Praveen Shukla                                Party Details.

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

public partial class Matter_ViewMatter_Parties : System.Web.UI.Page
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    ViewStageLogic VSL = new ViewStageLogic();
    MatterDetails MDetails = new MatterDetails();
    SaveStage SV = new SaveStage();
    PartyDetails PL = new PartyDetails();
    Common_Message commessage = new Common_Message();
    static string M_id;
    static int EMPID;
    static string USERID;
    #endregion

    #region   ******** Page Load *************************
    protected void Page_Load(object sender, EventArgs e)
    {

        GetSession();
        if (!IsPostBack)
        {
           
            if (Session["ID"] != null)
            {
                LoginCss_load();

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
        AllParty();
        AllPartyType();
        AllROleType();
        MatterView();
    }
    #endregion

    #region   ********Matter Grid*************************
    public void MatterView()
    {
        dt = PL.MatterView();
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
        GridViewRow selectedRow = DtgMatter.SelectedRow;
        int index = DtgMatter.SelectedIndex;
        lbl.Text = DtgMatter.DataKeys[index].Value.ToString();
        txtMatterno.Text = selectedRow.Cells[2].Text.ToString();
        BindParty();
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
    protected void btnAddparty_Click(object sender, EventArgs e)
    {
        string Mode = "INSERT";
        int Rank =0;
        if (lbl.Text.ToString() != "")
        {
            if (ddlParty.SelectedIndex != 0)
            {
                if (ddlPartyType.SelectedIndex != 0)
                {
                    if (ddlRole.SelectedIndex != 0)
                    {
                        #region ************Insert Party ***************

                        if (ddlRole.SelectedValue.ToString() == "1")
                        {
                            Rank = 0;
                        }
                        else
                        {
                            dt = PL.OPPonentRank(Convert.ToInt32(lbl.Text));
                            if (dt.Rows[0]["RANK"].ToString() != "")
                            {
                                Rank = Convert.ToInt32(dt.Rows[0]["RANK"]);
                            }
                            else
                            {
                                Rank = 1;
                            }

                        }
                        dt = PL.ChkClient(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlRole.SelectedValue));
                        if (dt.Rows.Count > 0)
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Client Already Added.", 125, 300);
                        }
                        else
                        {
                            #region*********************Add Parties********************************************
                            int i = PL.AddParty(Convert.ToInt32(lbl.Text), Convert.ToInt32(ddlParty.SelectedValue), Convert.ToInt32(ddlPartyType.SelectedValue), Convert.ToInt32(ddlRole.SelectedValue), Rank, Mode);
                            if (i > 0)
                            {

                                ddlParty.SelectedIndex = 0;
                                ddlPartyType.SelectedIndex = 0;
                                ddlRole.SelectedIndex = 0;
                                BindParty();
                                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);
                            }
                            #endregion
                        }
                        #endregion
                    }

                    else
                    {

                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Type.", 125, 300);

                    }
                        
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Role.", 125, 300);
                }
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Party.", 125, 300);
            }
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select the Record.", 125, 300);
        }

    }

    protected void Delete_Party(object sender, GridViewDeleteEventArgs e)
    {
        int Pid = (int)AddPartyGrid.DataKeys[e.RowIndex].Value;
        string Mode = "DELETE";
        int i = PL.DeleteParty (Pid, Mode);
        if (i > 0)
        {
            BindParty();
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Warning, commessage.DeletedRecord, 125, 300);
        }
    }
   

    #endregion

    #region   ********Party Dropdown*************************
    private void AllParty()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = PL.Party_Arabic();
        }
        else
        {
            dt = PL.Party_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddlParty.DataSource = dt;
            ddlParty.DataBind();
            ddlParty.Items.Insert(0, new ListItem(""));
        }
    }
    private void AllPartyType()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = PL.Partytype_Arabic();
        }
        else
        {
            dt = PL.PartyType_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddlPartyType.DataSource = dt;
            ddlPartyType.DataBind();
            ddlPartyType.Items.Insert(0, new ListItem(""));

        }
    }
    private void AllROleType()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = PL.PartyRole_Arabic();
        }
        else
        {
            dt = PL.PartyRole_English();
        }
        if (dt.Rows.Count > 0)
        {
            ddlRole.DataSource = dt;
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem(""));
        }
    }
    #endregion

    #region   ********Party bind At Save and Grid Click*************************
    private void BindParty()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = PL.PartyDetails_Arabic(Convert.ToInt32(lbl.Text));
        }
        else
        {
            dt = PL.PartyDetails_English(Convert.ToInt32(lbl.Text));
        }
        if (dt.Rows.Count > 0)
        {
            dtgPartyGRID.DataSource = dt;
            dtgPartyGRID.DataBind();
            AddPartyGrid.DataSource = dt;
            AddPartyGrid.DataBind();
        }
        else
        {
            dtgPartyGRID.DataSource = null;
            dtgPartyGRID.DataBind();
            AddPartyGrid.DataSource = null;
            AddPartyGrid.DataBind();
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
    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = PL.RightsDetails(EMPID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "Add Party")
                {
                    AddParty.Visible = true;
                }
                
            }
        }
    }
    #endregion
}
#endregion