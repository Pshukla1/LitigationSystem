using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Udev.MasterPageWithLocalization.Classes
{
    /// <summary>
    /// This class provides ISO definitions for all cultures that are supported by this application.
    /// </summary>
    public struct Culture
    {
        //German - Switzerland definition
        public const string DE = "de-CH";
        //English - Great Britain definition
        public const string EN = "en-GB";
        public const string AR = "ar-AE";
    }
}