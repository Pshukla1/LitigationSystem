#region   ********  Revision History *************************

//  Sl#          	Date	                        Created By	                                  Description
//   1			    26.06.13                        Praveen Shukla                               Alerts& Notication.

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
using System.Net.Mail;
using System.IO;
#endregion

#region   ********Page Controls *************************
public partial class Matter_Alerts_AlertsPage : System.Web.UI.Page
{
    #region   ********  Public Declaration *************************
    bool bSendMail = false;
    DataTable dt = new DataTable();
    Addalertslogic AL = new Addalertslogic();
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
             
            LoginCss_load();
            getRightInformation();
            if (Session["ID"] != null)
            {
                
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

        Alert_Grid();
        Employeedata();
        Alertdata();
    }
    #endregion
    #region   ********Alert Grid Data Bind *************************
    public void Alert_Grid()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = AL.AlertGridArabic();
        }
        else
        {
            dt = AL.AlertGridEnglish();
        }
        if (dt.Rows.Count > 0)
        {
            dtgAlertGrid.DataSource = dt;
            dtgAlertGrid.DataBind();
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
    protected void dtgAlertGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow selectedRow = dtgAlertGrid.SelectedRow;
        lblalertMatterno.Text = selectedRow.Cells[1].Text.ToString();
        lblresendMatterno.Text = selectedRow.Cells[1].Text.ToString();
        txtmatterno.Text = selectedRow.Cells[1].Text.ToString();
        int index = dtgAlertGrid.SelectedIndex;
        lbl.Text = dtgAlertGrid.DataKeys[index].Value.ToString();
        Alert_Data();
    }
    protected void dtgAlertGrid_RowDataBound(object sender, GridViewRowEventArgs e)
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
        foreach (GridViewRow row in dtgAlertGrid.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ClientScript.RegisterForEventValidation(((LinkButton)row.Cells[0].Controls[0]).UniqueID, "Select$" + row.RowIndex);
            }
        }
        base.Render(writer);
    }
    protected void dtgAlertGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgAlertGrid.PageIndex = e.NewPageIndex;
        Alert_Grid();
    }
    #endregion
    #region   ********Dropdown Lists *************************
    public void Employeedata()
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

            ddlconcern.DataSource = dt;
            ddlconcern.DataBind();
            ddlcreated.DataSource = dt;
            ddlcreated.DataBind();
            AddlConcernEmp.DataSource = dt;
            AddlConcernEmp.DataBind();
            AddlCreatedEmp.DataSource = dt;
            AddlCreatedEmp.DataBind();
            AddlCreatedEmp.Items.Insert(0, new ListItem(""));
            AddlConcernEmp.Items.Insert(0, new ListItem(""));
            ddlconcern.Items.Insert(0, new ListItem(""));
            ddlcreated.Items.Insert(0, new ListItem(""));

        }
    }
    public void Alertdata()
    {
        if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
        {
            dt = AL.GetAlert_type_Arebic();
        }
        else
        {
            dt = AL.GetAlert_type_Enlish();
        }
        if (dt.Rows.Count > 0)
        {

            ddlalerttype.DataSource = dt;
            ddlalerttype.DataBind();
            AddlAlerttype.DataSource = dt;
            AddlAlerttype.DataBind();
            ddlalerttype.Items.Insert(0, new ListItem(""));
            AddlAlerttype.Items.Insert(0, new ListItem(""));

        }
    }

    #endregion
    #region   ********Alert Details *************************

    protected void Alert_Data()
    {
        if (lbl.Text != "")
        {
            dt = AL.GetAlertDetails(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {

                ddlalerttype.SelectedValue = dt.Rows[0]["Alert_type_ID"].ToString();
                txtduedate.Text = Convert.ToDateTime(dt.Rows[0]["Due_date"]).ToString("dd-MMM-yyyy");
                txtcreatedate.Text = Convert.ToDateTime(dt.Rows[0]["Date_Created"]).ToString("dd-MMM-yyyy");
                ddlconcern.SelectedValue = dt.Rows[0]["Concern_emp_ID"].ToString();
                ddlcreated.SelectedValue = dt.Rows[0]["Created_Emp_ID"].ToString();
                txtdicription.Text = dt.Rows[0]["Discription"].ToString();
            }
        }
        else
        {
            ddlalerttype.SelectedIndex =0;
            txtduedate.Text = "";
            txtcreatedate.Text = "";
            ddlconcern.SelectedIndex = 0;
            ddlcreated.SelectedIndex = 0;
            txtdicription.Text = "";
        }
    }

    #endregion
    #region   ********Operation Contarct*************************
    protected void Addalert_Click(object sender, EventArgs e)
    {

        string Mode = "INSERT";
        if (lblalertMatterno.Text != "")
        {
            dt = AL.GetMatterID(lblalertMatterno.Text);
            lbl.Text = dt.Rows[0]["Matter_ID"].ToString();
            int j = AL.SaveAlert(Convert.ToInt32(AddlAlerttype.SelectedValue), Convert.ToInt32(AddlConcernEmp.Text), Convert.ToInt32(AddlCreatedEmp.SelectedValue),
                 Convert.ToDateTime(txtAduedate.Text), txtAdiscription.Text, Convert.ToDateTime(txtAcdate.Text), Convert.ToInt32(lbl.Text), Mode);
            if (j > 0)
            {
                AddlAlerttype.SelectedIndex = 0;
                AddlConcernEmp.SelectedIndex = 0;
                AddlCreatedEmp.SelectedIndex = 0;
                txtAduedate.Text = "";
                txtAdiscription.Text = "";
                txtAcdate.Text = "";
                Alert_Grid();
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, commessage.RecordSaved, 125, 300);

            }

            //string ToMail = "abdul.azeem@habibalmulla.com";
            //string ToCC = "abdul.azeem@habibalmulla.com";
            //string ToBcc = "abdul.azeem@habibalmulla.com";
            //string Subject = "Test Notification Mail";

            string ToMail = "";
            string ToCC = "";
            string ToBcc = "";
            string Subject = "";

            dt = AL.GetAlertMailtoAssigned_Responsiable(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {
                ToMail = dt.Rows[0][0].ToString() + " ," + dt.Rows[0][1].ToString();
            }

            dt = AL.GetAlertMailToFallower(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ToCC += dt.Rows[i][0].ToString() + ",";

                }

            }

            //SendMail(ToMail, ToCC, ToBcc, Subject, true);
            lbl.Text = "";
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Matter.", 125, 300);
        }
    }
    protected void Resendalert_Click(object sender, EventArgs e)
    {


        if (lblresendMatterno.Text != "000-000-0000")
        {


            string ToMail = "";
            string ToCC = "";
            string ToBcc = "";
            string Subject = "";

            dt = AL.GetMatterID(lblalertMatterno.Text);
            lbl.Text = dt.Rows[0]["Matter_ID"].ToString();

            dt = AL.GetAlertMailtoAssigned_Responsiable(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {
                ToMail = dt.Rows[0][0].ToString() + " ," + dt.Rows[0][1].ToString();
            }

            dt = AL.GetAlertMailToFallower(Convert.ToInt32(lbl.Text));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ToCC += dt.Rows[i][0].ToString() + ",";

                }

            }

            //SendMail(ToMail, ToCC, ToBcc, Subject, true);
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Your Alert has been sent sucessdully.", 125, 300);
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Success, "Please Select Matter.", 125, 300);
        }
    }

    #endregion
    #region   ********Alert Mail*************************
    public string SendMail(string ToAddress, string CCAddress, string BccAddress, string Subject, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute(true)] bool IsBodyHtml)
    {

        try
        {
            StreamReader reader = new StreamReader(Server.MapPath("~/MailTemplate/HTMLPage.htm"));
            string readFile = reader.ReadToEnd();
            string myString = "";
            myString = readFile;
            myString = myString.Replace("$$Matterno$$", "HAB-009-0123");
            myString = myString.Replace("$$Alerttype$$", "Pleadings");
            myString = myString.Replace("$$Duedate$$", "24-05-2013");
            myString = myString.Replace("$$Concernemp$$", "Praveen");
            myString = myString.Replace("$$Createdby$$", "Marwan");
            myString = myString.Replace("$$Createdate$$", "22-05-2013");
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(ToAddress);
            if (CCAddress != "")
            {
                string[] tos = CCAddress.Split(',');
                for (int i = 0; i < tos.Length; i++)
                {
                    mailMessage.To.Add(new MailAddress(tos[i]));
                }

                //mailMessage.CC.Add(CCAddress);
            }

            if (BccAddress != "")
            {

                mailMessage.Bcc.Add(BccAddress);

            }
            mailMessage.Subject = Subject;
            mailMessage.Body = myString.ToString();
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("abdul.azeem@habibalmulla.com");
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "hbhcah01.hamdomain.dubai";
            bSendMail = true;
            smtp.Send(mailMessage);
            smtp = null;
            mailMessage = null;
            reader.Dispose();
        }
        catch (Exception ex)
        {
            bSendMail = false;

        }
        return bSendMail.ToString();
    }
    #endregion

    #region   ********Security Right************************
    protected void getRightInformation()
    {
        dt = AL.RightsDetails(EMPID);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "Add Alert")
                {
                    pnladdalert.Visible = true;
                }
                else if (dt.Rows[i][0].ToString() == "Resend Alert")
                {
                    pnlresendalert.Visible = true;
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