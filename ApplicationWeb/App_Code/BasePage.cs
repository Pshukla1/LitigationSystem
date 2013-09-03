using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Udev.MasterPageWithLocalization.Classes
{
    /// <summary>
    /// Custom base page used for all web forms.
    /// </summary>
    public class BasePage : Page
    {
        protected override void InitializeCulture()
        {
            //retrieve culture information from session
            string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);

            //check whether a culture is stored in the session
            if (culture.Length > 0) Culture = culture;

            //set culture to current thread
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            //call base class
            base.InitializeCulture();
        }
    }
}
