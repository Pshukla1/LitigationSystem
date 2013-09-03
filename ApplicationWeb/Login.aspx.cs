using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using Common;
using Udev.MasterPageWithLocalization.Classes;
using System.Data;
using LitigationDataLogic;
public partial class Login : System.Web.UI.Page
{
    LoginLogic LC = new LoginLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginLogo();
        }
        

    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
                
        //Common.ActiveDirectoryHelper ds = new ActiveDirectoryHelper();
        // string UserId = txtusername.Text.Trim().ToString();
        // DataTable dt = ds.UserDetails(UserId);
        // if (dt.Rows.Count > 0)
        //{
        //    dt = LC.GetUserDetailsEnglish(dt.Rows[0][0].ToString());
        //    if (dt.Rows.Count > 0)
        //    {
                Session["Employee_Id"] = 1;
                Session["Name"] = "Praveen Shukla";
                Session["GROUP"] = "MANAGER";
                //Session["Employee_Id"] = dt.Rows[0]["Employee_Id"].ToString();
                //Session["Name"] = dt.Rows[0][1].ToString();
                //Session["GROUP"] = dt.Rows[0]["GROUPNAME"].ToString();
                if (Session["GROUP"].ToString() == "LAWYER")
                {
                    Response.Redirect("~/Matter/Dashboards/LawyerDashBoard.aspx");
                }
                else if (Session["GROUP"].ToString() == "MANAGER")
                {
                    Response.Redirect("~/Matter/Dashboards/ManagerDashboard.aspx");
                }

                else if (Session["GROUP"].ToString() == "SECRETARY")
                {
                    Response.Redirect("~/Matter/Dashboards/SecretaryDashboard.aspx");
                }
                else if (Session["GROUP"].ToString() == "DATAENTRY")
                {
                    Response.Redirect("~/Matter/Dashboards/DataEntryDashboard.aspx");
                }
                else if (Session["Name"].ToString() == "ADMIN")
                {
                    Response.Redirect("~/Matter/Dashboards/ViewAllMatter.aspx");
                }
    //        }

    //        else
    //        {
    //            Error.Text = "Plase create user account first.";

    //        }
           
    //    }
    //    else
    //    {
    //        Error.Text = "Please enter correct Username / Password.";
           
           
    //    }
        
    }
    private void LoginLogo()
    {
        if (Convert.ToString(Session["languageId"]) == "ar-AE")
        {

            pnlArebic.Visible = true;
            pnlEnlish.Visible = false;
          
        }
        else
        {
            pnlArebic.Visible = false;
            pnlEnlish.Visible = true;
        }
    }
    //protected void EN_Click(object sender, EventArgs e)
    //{
    //    lblcompanyname.Text = "Habib Al Mulla & Co. 2013.";
    //    lblusername.Text = "Username";
    //    lblpassword.Text = "Password";
    //    lblmanage.Text = "This system is managed by Habib Al Mulla IT Version 2.1.";
    //    BtnLogin.Text = "Login";
    //    pnlArebic.Visible = false;
    //    pnlEnlish.Visible = true;
    //    lbllogin.Text = "Login";

    //}
    //protected void AR_Click(object sender, EventArgs e)
    //{
    //    lblcompanyname.Text = "حبيب الملا وشركاه 2013.";
    //    lblusername.Text = "اسم المستخدم";
    //    lblpassword.Text = "كلمة السر";
    //    lblmanage.Text = "يدار هذا النظام من قبل حبيب الملا IT الإصدار 2.1.";
    //    BtnLogin.Text = "دخول";
    //    pnlArebic.Visible = true;
    //    pnlEnlish.Visible = false;
    //    lbllogin.Text = "دخول";
    //}
    protected override void InitializeCulture()
    {
        string language = Request.Form["__EventTarget"];
        string languageId = "";
        if (!string.IsNullOrEmpty(language))
        {
            if (language.EndsWith("Arebic")) languageId = "ar-AE";
            else languageId = "en-US";
            SetCulture(languageId);
        }

        if (Session["Language"] != null)
        {
            if (!Session["Language"].ToString().StartsWith(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)) SetCulture(Session["Language"].ToString());
        }

        base.InitializeCulture();
    }
    protected void SetCulture(string languageId)
    {
        Session["Language"] = languageId;
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageId);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageId);
       
    }
    protected void btnCss1_Click(object sender, EventArgs e)
    {
        //lnkCSS.Attributes["href"] = "css/"+ (sender as LinkButton).CommandArgument;
        lnkCSS.Attributes["href"] = "~/css/generalArebic.css";
        
        pnlArebic.Visible = true;
        pnlEnlish.Visible = false;
    }
    protected void btnCss2_Click(object sender, EventArgs e)
    {
       
        //lnkCSS.Attributes["href"] = "css/"+ (sender as LinkButton).CommandArgument;
        lnkCSS.Attributes["href"] = "~/css/generalEnglish.css";
        pnlArebic.Visible = false;
        pnlEnlish.Visible = true;
    } 

}