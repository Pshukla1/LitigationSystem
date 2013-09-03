using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class CommonScriptMessageClass
{
	public CommonScriptMessageClass()
	{
		
	}

    public static bool CreateMessageAlert(System.Web.UI.Page aspxPage, string strMessage)
    {
        string strScript = "alert( \"" + strMessage + "\" )";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strScript, true);

        return false;
    }

    public static bool CreateMessageAlertForAscxPage(System.Web.UI.UserControl ascxPage, string strMessage)
    {
        {
            string strScript = "alert( \"" + strMessage + "\" )";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(ascxPage, ascxPage.GetType(), "Key1", strScript, true);
            return false ;
        }
        return true;
    }

    public static bool CreatePopupWindow(System.Web.UI.Page aspxPage, string strMessage)
    {
        //string strScript = "alert( \"" + strMessage + "\" )";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strMessage, true);

        return false;
    }


    public static bool OpenWindowInPopup(System.Web.UI.Page aspxPage)
    {
        string strScript = @"var w = screen.availWidth || screen.width;
                             var h = screen.availHeight || screen.height; 
                            var ConfigurationpopUpWindow = window.open(/Production/DownTime.aspx, 'ConfigurationpopUpWindow', 'width=950,height=450,top=' + (h - 500) / 2 + ',left=' + (w - 1005) / 2 + ',resizable=no,scrollbars=yes');";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strScript, true);
        return false;
    }

    public static bool AlertColseWindow(System.Web.UI.Page aspxPage, string strMessage)
    {
        string strScript = @"alert( '" + strMessage + "' ); self.close();";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strScript, true);

        return false;
    }

    public static bool AlertRedirectWindow(System.Web.UI.Page aspxPage, string strMessage, string RedirectPage)
    {

        string strScript = @"alert( '" + strMessage + "' ); window.location.href='" + RedirectPage + "';";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strScript, true);
        return false;

    }

    public static bool AlertRedirectWindowForAscx(System.Web.UI.UserControl ascxPage, string strMessage, string RedirectPage)
    {

        string strScript = @"alert( '" + strMessage + "' ); window.location.href='" + RedirectPage + "';";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(ascxPage, ascxPage.GetType(), "Key1", strScript, true);
        return false;

    }

    public static bool AlertRedirectWindowMaster(System.Web.UI.MasterPage masterPage, string strMessage, string RedirectPage)
    {
        string strScript = @"alert( '" + strMessage + "' ); window.location.href='" + RedirectPage + "';";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(masterPage, masterPage.GetType(), "Key1", strScript, true);
        return false;
    }

    public static bool AlertColseWindowAndRefreshParent(System.Web.UI.Page aspxPage, string strMessage, string ParentFormName)
    {
        string strScript = @"alert( '" + strMessage + "' );  window.opener.document.forms['" + ParentFormName + "'].submit(); self.close(); ";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strScript, true);

        return false;
    }


    public static bool ColseWindowAndRefreshParent(System.Web.UI.Page aspxPage, string ParentFormName)
    {
        string strScript = @"window.opener.document.forms['" + ParentFormName + "'].submit(); self.close(); ";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strScript, true);

        return false;
    }


    public static bool ColseWindow(System.Web.UI.Page aspxPage)
    {
        string strScript = @"self.close();";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", strScript, true);

        return false;
    }

    public static bool setcontrolfocus(System.Web.UI.Page aspxPage, string strMessage)
    {

        //function SetCursorToTextEnd(textControlID)
        //{
        string str = "";
        str += " var text = document.getElementById('" + strMessage + "').value;";
        str += "document.getElementById('" + strMessage + "').focus();";
        str += "if (text.value.length > 0)";
        str += "{  if (text.createTextRange) {";
        str += "var FieldRange = text.createTextRange();";
        str += "FieldRange.moveStart('character', text.value.length);";
        str += "FieldRange.collapse();";
        str += "FieldRange.select();}}";
        //}


        // string strScript = @"document.getElementById('" + strMessage + "').value=document.getElementById('" + strMessage + "').value;";
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(aspxPage, aspxPage.GetType(), "Key1", str, true);

        return false;
    }

    /*=====================================================================================================*/

    public static bool CreateMessageAlertForAspxPage(System.Web.UI.Page aspxPage, string strMessage)
    {
        string strScript = "<script language=JavaScript>alert( \"" + strMessage + "\" )</script>";
        if (!aspxPage.IsStartupScriptRegistered("strKey1"))
        {
            aspxPage.RegisterStartupScript("strKey1", strScript);
        }
        return false;

    }

    /*=====================================================================================================*/

    public static bool CreateMessageAlertToAWebPage(System.Web.UI.Page aspxPage, string strMessage, string pagename)
    {
        string strScript = @"<script language=JavaScript>alert('" + strMessage + "'); window.location.href('" + pagename + "')</script>";
        if (!aspxPage.IsStartupScriptRegistered("strKey1"))
        {
            aspxPage.RegisterStartupScript("strKey1", strScript);
        }
        return false;
    }

    /*=====================================================================================================*/

    public static bool CreateMessage(System.Web.UI.Page aspxPage, string strMessage)
    {
        string strScript = @"<script language=JavaScript>alert('" + strMessage + "'); self.close();</script>";
        if (!aspxPage.IsStartupScriptRegistered("strKey1"))
        {
            aspxPage.RegisterStartupScript("strKey1", strScript);
        }
        return false;
    }

    /*===========================================For BarCode===============================================*/

    public static string printbar(string num)
    {
        int b1 = 0;
        int b2 = 0;
        int b3 = 0;
        int b4 = 0;
        int b5 = 0;
        int b6 = 0;
        string strbar = "";
        strbar = strbar + "b2,";
        strbar = strbar + "w1,";
        strbar = strbar + "b1,";
        strbar = strbar + "w2,";
        strbar = strbar + "b3,";
        strbar = strbar + "w2,";
        num = Code128c(num);
        int i, ii;
        if (num.Length % 2 != 0)
            num = num + " ";

        for (i = 0; i < num.Length; i = i + 2)
        {
            ii = int.Parse(num.Substring(i, 2));
            //from here writebar function starts
            switch (ii)
            {

                case 0:
                    b1 = 2;
                    b2 = 1;
                    b3 = 2;
                    b4 = 2;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 1:
                    b1 = 2;
                    b2 = 2;
                    b3 = 2;
                    b4 = 1;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 2:
                    b1 = 2;
                    b2 = 2;
                    b3 = 2;
                    b4 = 2;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 3:
                    b1 = 1;
                    b2 = 2;
                    b3 = 1;
                    b4 = 2;
                    b5 = 2;
                    b6 = 3;
                    break;
                case 4:
                    b1 = 1;
                    b2 = 2;
                    b3 = 1;
                    b4 = 3;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 5:
                    b1 = 1;
                    b2 = 3;
                    b3 = 1;
                    b4 = 2;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 6:
                    b1 = 1;
                    b2 = 2;
                    b3 = 2;
                    b4 = 2;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 7:
                    b1 = 1;
                    b2 = 2;
                    b3 = 2;
                    b4 = 3;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 8:
                    b1 = 1;
                    b2 = 3;
                    b3 = 2;
                    b4 = 2;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 9:
                    b1 = 2;
                    b2 = 2;
                    b3 = 1;
                    b4 = 2;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 10:
                    b1 = 2;
                    b2 = 2;
                    b3 = 1;
                    b4 = 3;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 11:
                    b1 = 2;
                    b2 = 3;
                    b3 = 1;
                    b4 = 2;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 12:
                    b1 = 1;
                    b2 = 1;
                    b3 = 2;
                    b4 = 2;
                    b5 = 3;
                    b6 = 2;
                    break;
                case 13:
                    b1 = 1;
                    b2 = 2;
                    b3 = 2;
                    b4 = 1;
                    b5 = 3;
                    b6 = 2;
                    break;
                case 14:
                    b1 = 1;
                    b2 = 2;
                    b3 = 2;
                    b4 = 2;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 15:
                    b1 = 1;
                    b2 = 1;
                    b3 = 3;
                    b4 = 2;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 16:
                    b1 = 1;
                    b2 = 2;
                    b3 = 3;
                    b4 = 1;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 17:
                    b1 = 1;
                    b2 = 2;
                    b3 = 3;
                    b4 = 2;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 18:
                    b1 = 2;
                    b2 = 2;
                    b3 = 3;
                    b4 = 2;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 19:
                    b1 = 2;
                    b2 = 2;
                    b3 = 1;
                    b4 = 1;
                    b5 = 3;
                    b6 = 2;
                    break;
                case 20:
                    b1 = 2;
                    b2 = 2;
                    b3 = 1;
                    b4 = 2;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 21:
                    b1 = 2;
                    b2 = 1;
                    b3 = 3;
                    b4 = 2;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 22:
                    b1 = 2;
                    b2 = 2;
                    b3 = 3;
                    b4 = 1;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 23:
                    b1 = 3;
                    b2 = 1;
                    b3 = 2;
                    b4 = 1;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 24:
                    b1 = 3;
                    b2 = 1;
                    b3 = 1;
                    b4 = 2;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 25:
                    b1 = 3;
                    b2 = 2;
                    b3 = 1;
                    b4 = 1;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 26:
                    b1 = 3;
                    b2 = 2;
                    b3 = 1;
                    b4 = 2;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 27:
                    b1 = 3;
                    b2 = 1;
                    b3 = 2;
                    b4 = 2;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 28:
                    b1 = 3;
                    b2 = 2;
                    b3 = 2;
                    b4 = 1;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 29:
                    b1 = 3;
                    b2 = 2;
                    b3 = 2;
                    b4 = 2;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 30:
                    b1 = 2;
                    b2 = 1;
                    b3 = 2;
                    b4 = 1;
                    b5 = 2;
                    b6 = 3;
                    break;
                case 31:
                    b1 = 2;
                    b2 = 1;
                    b3 = 2;
                    b4 = 3;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 32:
                    b1 = 2;
                    b2 = 3;
                    b3 = 2;
                    b4 = 1;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 33:
                    b1 = 1;
                    b2 = 1;
                    b3 = 1;
                    b4 = 3;
                    b5 = 2;
                    b6 = 3;
                    break;
                case 34:
                    b1 = 1;
                    b2 = 3;
                    b3 = 1;
                    b4 = 1;
                    b5 = 2;
                    b6 = 3;
                    break;
                case 35:
                    b1 = 1;
                    b2 = 3;
                    b3 = 1;
                    b4 = 3;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 36:
                    b1 = 1;
                    b2 = 1;
                    b3 = 2;
                    b4 = 3;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 37:
                    b1 = 1;
                    b2 = 3;
                    b3 = 2;
                    b4 = 1;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 38:
                    b1 = 1;
                    b2 = 3;
                    b3 = 2;
                    b4 = 3;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 39:
                    b1 = 2;
                    b2 = 1;
                    b3 = 1;
                    b4 = 3;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 40:
                    b1 = 2;
                    b2 = 3;
                    b3 = 1;
                    b4 = 1;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 41:
                    b1 = 2;
                    b2 = 3;
                    b3 = 1;
                    b4 = 3;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 42:
                    b1 = 1;
                    b2 = 1;
                    b3 = 2;
                    b4 = 1;
                    b5 = 3;
                    b6 = 3;
                    break;
                case 43:
                    b1 = 1;
                    b2 = 1;
                    b3 = 2;
                    b4 = 3;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 44:
                    b1 = 1;
                    b2 = 3;
                    b3 = 2;
                    b4 = 1;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 45:
                    b1 = 1;
                    b2 = 1;
                    b3 = 3;
                    b4 = 1;
                    b5 = 2;
                    b6 = 3;
                    break;
                case 46:
                    b1 = 1;
                    b2 = 1;
                    b3 = 3;
                    b4 = 3;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 47:
                    b1 = 1;
                    b2 = 3;
                    b3 = 3;
                    b4 = 1;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 48:
                    b1 = 3;
                    b2 = 1;
                    b3 = 3;
                    b4 = 1;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 49:
                    b1 = 2;
                    b2 = 1;
                    b3 = 1;
                    b4 = 3;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 50:
                    b1 = 2;
                    b2 = 3;
                    b3 = 1;
                    b4 = 1;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 51:
                    b1 = 2;
                    b2 = 1;
                    b3 = 3;
                    b4 = 1;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 52:
                    b1 = 2;
                    b2 = 1;
                    b3 = 3;
                    b4 = 3;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 53:
                    b1 = 2;
                    b2 = 1;
                    b3 = 3; ;
                    b4 = 1;
                    b5 = 3;
                    b6 = 1;
                    break;
                case 54:
                    b1 = 3;
                    b2 = 1;
                    b3 = 1;
                    b4 = 1;
                    b5 = 2;
                    b6 = 3;
                    break;
                case 55:
                    b1 = 3;
                    b2 = 1;
                    b3 = 1;
                    b4 = 3;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 56:
                    b1 = 3;
                    b2 = 3;
                    b3 = 1;
                    b4 = 1;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 57:
                    b1 = 3;
                    b2 = 1;
                    b3 = 2;
                    b4 = 1;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 58:
                    b1 = 3;
                    b2 = 1;
                    b3 = 2;
                    b4 = 3;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 59:
                    b1 = 3;
                    b2 = 3;
                    b3 = 2;
                    b4 = 1;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 60:
                    b1 = 3;
                    b2 = 1;
                    b3 = 4;
                    b4 = 1;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 61:
                    b1 = 2;
                    b2 = 2;
                    b3 = 1;
                    b4 = 4;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 62:
                    b1 = 4;
                    b2 = 3;
                    b3 = 1;
                    b4 = 1;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 63:
                    b1 = 1;
                    b2 = 1;
                    b3 = 1;
                    b4 = 2;
                    b5 = 2;
                    b6 = 4;
                    break;
                case 64:
                    b1 = 1;
                    b2 = 1;
                    b3 = 1;
                    b4 = 4;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 65:
                    b1 = 1;
                    b2 = 2;
                    b3 = 1;
                    b4 = 1;
                    b5 = 2;
                    b6 = 4;
                    break;
                case 66:
                    b1 = 1;
                    b2 = 2;
                    b3 = 1;
                    b4 = 4;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 67:
                    b1 = 1;
                    b2 = 4;
                    b3 = 1;
                    b4 = 1;
                    b5 = 2;
                    b6 = 2;
                    break;
                case 68:
                    b1 = 1;
                    b2 = 4;
                    b3 = 1;
                    b4 = 2;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 69:
                    b1 = 1;
                    b2 = 1;
                    b3 = 2;
                    b4 = 2;
                    b5 = 1;
                    b6 = 4;
                    break;
                case 70:
                    b1 = 1;
                    b2 = 1;
                    b3 = 2;
                    b4 = 4;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 71:
                    b1 = 1;
                    b2 = 2;
                    b3 = 2;
                    b4 = 1;
                    b5 = 1;
                    b6 = 4;
                    break;
                case 72:
                    b1 = 1;
                    b2 = 2;
                    b3 = 2;
                    b4 = 4;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 73:
                    b1 = 1;
                    b2 = 4;
                    b3 = 2; ;
                    b4 = 1;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 74:
                    b1 = 1;
                    b2 = 4;
                    b3 = 2;
                    b4 = 2;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 75:
                    b1 = 2;
                    b2 = 4;
                    b3 = 1;
                    b4 = 2;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 76:
                    b1 = 2;
                    b2 = 2;
                    b3 = 1;
                    b4 = 1;
                    b5 = 1;
                    b6 = 4;
                    break;
                case 77:
                    b1 = 4;
                    b2 = 1;
                    b3 = 3;
                    b4 = 1;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 78:

                    b1 = 2;
                    b2 = 4;
                    b3 = 1;
                    b4 = 1;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 79:
                    b1 = 1;
                    b2 = 3;
                    b3 = 4;
                    b4 = 1;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 80:
                    b1 = 1;
                    b2 = 1;
                    b3 = 1;
                    b4 = 2;
                    b5 = 4;
                    b6 = 2;
                    break;
                case 81:
                    b1 = 1;
                    b2 = 2;
                    b3 = 1;
                    b4 = 1;
                    b5 = 4;
                    b6 = 2;
                    break;
                case 82:
                    b1 = 1;
                    b2 = 2;
                    b3 = 1;
                    b4 = 2;
                    b5 = 4;
                    b6 = 1;
                    break;
                case 83:

                    b1 = 1;
                    b2 = 1;
                    b3 = 4;
                    b4 = 2;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 84:
                    b1 = 1;
                    b2 = 2;
                    b3 = 4;
                    b4 = 1;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 85:
                    b1 = 1;
                    b2 = 2;
                    b3 = 4;
                    b4 = 2;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 86:
                    b1 = 4;
                    b2 = 1;
                    b3 = 1;
                    b4 = 2;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 87:
                    b1 = 4;
                    b2 = 2;
                    b3 = 1;
                    b4 = 1;
                    b5 = 1;
                    b6 = 2;
                    break;
                case 88:
                    b1 = 4;
                    b2 = 2;
                    b3 = 1;
                    b4 = 2;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 89:

                    b1 = 2;
                    b2 = 1;
                    b3 = 2;
                    b4 = 1;
                    b5 = 4;
                    b6 = 1;
                    break;
                case 90:
                    b1 = 2;
                    b2 = 1;
                    b3 = 4;
                    b4 = 1;
                    b5 = 2;
                    b6 = 1;
                    break;
                case 91:
                    b1 = 4;
                    b2 = 1;
                    b3 = 2;
                    b4 = 1;
                    b5 = 4;
                    b6 = 1;
                    break;
                case 92:
                    b1 = 1;
                    b2 = 1;
                    b3 = 1;
                    b4 = 1;
                    b5 = 4;
                    b6 = 3;
                    break;
                case 93:

                    b1 = 1;
                    b2 = 1;
                    b3 = 1;
                    b4 = 3;
                    b5 = 4;
                    b6 = 1;
                    break;
                case 94:
                    b1 = 1;
                    b2 = 3;
                    b3 = 1;
                    b4 = 1;
                    b5 = 4;
                    b6 = 1;
                    break;
                case 95:
                    b1 = 1;
                    b2 = 1;
                    b3 = 4;
                    b4 = 1;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 96:
                    b1 = 1;
                    b2 = 1;
                    b3 = 4;
                    b4 = 3;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 97:
                    b1 = 4;
                    b2 = 1;
                    b3 = 1;
                    b4 = 1;
                    b5 = 1;
                    b6 = 3;
                    break;
                case 98:
                    b1 = 4;
                    b2 = 1;
                    b3 = 1;
                    b4 = 3;
                    b5 = 1;
                    b6 = 1;
                    break;
                case 99:
                    b1 = 1;
                    b2 = 1;
                    b3 = 3;
                    b4 = 1;
                    b5 = 4;
                    b6 = 1;
                    break;
            }
            strbar = strbar + "b" + b1 + ",";
            strbar = strbar + "w" + b2 + ",";
            strbar = strbar + "b" + b3 + ",";
            strbar = strbar + "w" + b4 + ",";
            strbar = strbar + "b" + b5 + ",";
            strbar = strbar + "w" + b6 + ",";
        }

        strbar = strbar + "b2,";
        strbar = strbar + "w3,";
        strbar = strbar + "b3,";
        strbar = strbar + "w1,";
        strbar = strbar + "b1,";
        strbar = strbar + "w1,";
        strbar = strbar + "b2,";


        return strbar.Remove(strbar.Length - 1, 1);
    }

    /*=====================================================================================================*/

    public static string Code128c(string ThisNumber)
    {
        string OutNumber = "";
        ThisNumber = ThisNumber.Trim();
        int NumLength = ThisNumber.Length;
        if (ThisNumber.Length % 2 == 1)
        {
            ThisNumber = "0" + ThisNumber;
        }
        char StartCode = Convert.ToChar(205);
        char StopCode = Convert.ToChar(206);

        int weightedTotal = 105;
        int WeightValue = 1;
        NumLength = ThisNumber.Length;
        int i;
        int CurrentValue;
        for (i = 0; i < NumLength; i = i + 2)
        {
            CurrentValue = int.Parse(ThisNumber.Substring(i, 2));

            if (CurrentValue < 95 && CurrentValue > 0)
            {
                OutNumber = OutNumber + Convert.ToChar(CurrentValue + 32);
            }
            if (CurrentValue > 94)
            {
                OutNumber = OutNumber + Convert.ToChar(CurrentValue + 100);
            }
            if (CurrentValue == 0)
            {
                OutNumber = OutNumber + Convert.ToChar(194);
            }
            //'multiply by the weighting character
            CurrentValue = CurrentValue * WeightValue;
            //add the values together to get the weighted total
            weightedTotal = weightedTotal + CurrentValue;
            WeightValue = WeightValue + 1;
        }
        //division of WeightedTotal by 103 and getting the remainder, this is the CheckDigitValue
        int CheckDigitValue = (weightedTotal % 103);
        int C128_CheckDigit;
        //Now that we have the CheckDigitValue, find the corresponding ASCII character from the table
        if (CheckDigitValue < 95 && CheckDigitValue > 0)
        {

            C128_CheckDigit = Convert.ToChar(CheckDigitValue + 32);
        }

        if (CheckDigitValue > 94)
        {
            C128_CheckDigit = Convert.ToChar(CheckDigitValue + 100);

        }
        if (CheckDigitValue == 0)
        {
            C128_CheckDigit = Convert.ToChar(194);
        }
        return ThisNumber + CheckDigitValue;
    }


    /*=====================================================================================================*/

    public string GetInBarCodeFormat(String BarCode, string TYPE)
    {
        int Len = BarCode.Length;
        for (int i = 0; i < (11 - Len); i++)
        {
            BarCode = "0" + BarCode;


        }

        if (TYPE == "BOOK")
        {

            BarCode = "1" + BarCode;


        }
        if (TYPE == "USER")
        {

            BarCode = "2" + BarCode;

        }

        return BarCode;

    }

    /*=====================================================================================================*/

    public bool checkBarCode(String BarCode, string TYPE)
    {
        bool ret = false;


        if (TYPE == "BOOK")
        {

            if (BarCode.Substring(0, 1) == "1")
            {
                ret = true;
            }

        }
        if (TYPE == "USER")
        {
            if (BarCode.Substring(0, 1) == "2")
            {
                ret = true;
            }

        }

        return ret;
    }
}
