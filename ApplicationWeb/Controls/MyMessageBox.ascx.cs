using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class MyMessageBox : System.Web.UI.UserControl
{
    #region Properties
    public bool ShowCloseButton { get; set; }

    #endregion

    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserID"] == null)
        //{
        //    try
        //    {
        //        Response.Redirect("../SessionExpired.aspx", false);
        //    }
        //    catch { }
        //}
        if (ShowCloseButton)
            CloseButton.Attributes.Add("onclick", "document.getElementById('" + MessageBox.ClientID + "').style.display = 'none'");
    }
    #endregion

    #region Wrapper methods
    public void ShowError(string message, int height, int width)
    {
        Show(MessageType.Error, message, height, width);
       // ImgMsgType.ImageUrl = "../Images/error.png";
    }

    public void ShowInfo(string message, int height, int width)
    {
        Show(MessageType.Info, message, height, width);
       // ImgMsgType.ImageUrl = "../Images/info.png";
    }

    public void ShowSuccess(string message, int height, int width)
    {
        Show(MessageType.Success, message, height, width);
       // ImgMsgType.ImageUrl = "../Images/success.png";
    }

    public void ShowWarning(string message, int height, int width)
    {
        Show(MessageType.Warning, message, height, width);
       //ImgMsgType.ImageUrl = "../Images/warning.png";
    }
    #endregion

    #region Show control
    public void Show(MessageType messageType, string message, int height, int width)
    {
        CloseButton.Visible = ShowCloseButton;
        litMessage.Text = message;

        MessageBox.Height = height;
        MessageBox.Width = width;
        MessageBox.CssClass = messageType.ToString().ToLower();
        
        ModalPopupExtenderMessage.Show();
        this.Visible = true;
    }
    #endregion

    #region Enum
    public enum MessageType
    {
        Error = 1,
        Info = 2,
        Success = 3,
        Warning = 4
    }
    #endregion
}
