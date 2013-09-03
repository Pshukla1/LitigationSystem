using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.MasterPageWithLocalization.Classes;
using System.Globalization;
using LitigationClearkLogic;
using LitigationDataLogic;
public partial class Habib : System.Web.UI.MasterPage
{
    DataTable dt = new DataTable();
    AlertBindings AB = new AlertBindings();
    protected void Page_Load(object sender, EventArgs e)
     {
         MenuBind();
        //Page.MaintainScrollPositionOnPostBack = true;
        if (Session["Name"] != null)
        {
            lblname.Text =Session["Name"].ToString();

        }
        lnkCSS.Attributes["href"] = "css1/general.css";
        pnlArebic.Visible = false;
        pnlEnlish.Visible = true;
        if (!IsPostBack)
        {
            getAllert();
        }


    }
    protected void RequestLanguageChange_Click(object sender, EventArgs e)
    {
        LinkButton senderLink = sender as LinkButton;
        Session["USER"] = senderLink.CommandArgument.ToString();
        Session[Global.SESSION_KEY_CULTURE] = senderLink.CommandArgument;
        Server.Transfer(Request.Path);
    }
    protected void MenuBind()
    {
        if (Session["GROUP"].ToString() == "LAWYER")
        {
            Lawyer.Visible = true;
            Manager.Visible = false;
            Secretary.Visible = false;
            Dataentry.Visible = false;
        }
        else if (Session["GROUP"].ToString() == "MANAGER")
        {
            Lawyer.Visible = false;
            Manager.Visible = true;
            Secretary.Visible = false;
            Dataentry.Visible = false;
        }
        else if (Session["GROUP"].ToString() == "SECRETARY")
        {
            Lawyer.Visible = false;
            Manager.Visible = false;
            Secretary.Visible = true;
            Dataentry.Visible = false;
        }
        else if (Session["GROUP"].ToString() == "DATAENTRY")
        {
            Lawyer.Visible = false;
            Manager.Visible = false;
            Secretary.Visible = false;
            Dataentry.Visible = true;
        }
        else if (Session["Name"].ToString() == "ADMIN")
        {
            Lawyer.Visible = false;
            Manager.Visible = false;
            Secretary.Visible = false;
            Dataentry.Visible = false;
        }
    }

    #region ***************************Get Alert and date Click event*******************
    protected void getAllert()
    {
        
            if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = AB.GetAllAlertsArabic();
            }
            else
            {
                dt = AB.GetAllAlertsEnglish();
            }
            if (dt.Rows.Count > 0)
            {
                idAlert.DataSource = dt;
                idAlert.DataBind();
            }
        
    }
    protected void CalAlert_SelectionChanged(object sender, EventArgs e)
    {
          if (Convert.ToString(Session[Global.SESSION_KEY_CULTURE]) == "ar-AE")
            {
                dt = AB.GetAllAlertsArabic_Calclick(CalAlert.SelectedDate.ToString("yyyy-MM-dd"));
            }
            else
            {
                dt = AB.GetAllAlertsEnglish_Calclick(CalAlert.SelectedDate.ToString("yyyy-MM-dd"));
            }
          if (dt.Rows.Count > 0)
          {
              idAlert.DataSource = dt;
              idAlert.DataBind();
          }
          else
          {
              idAlert.DataSource = null;
              idAlert.DataBind();
          }

    }
    protected void lnlshowAll_Click(object sender, EventArgs e)
    {
        getAllert();
    }
    #endregion
   
}


