<%@ Application Language="C#" %>
<%@ Import Namespace="Udev.MasterPageWithLocalization.Classes" %>

<script runat="server">

    
    void Application_Start(object sender, EventArgs e) 
    {
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //set english as default startup language
        Session[Global.SESSION_KEY_CULTURE] = Culture.EN;
    }

    void Session_End(object sender, EventArgs e) 
    {
    }
       
</script>
