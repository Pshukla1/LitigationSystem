<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
    
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link media="screen" href="~/css/reset.css" type="text/css" rel="stylesheet">
    <link media="screen" href="~/css/text.css" type="text/css" rel="stylesheet">
    <link media="screen" href="~/css/grid.css" type="text/css" rel="stylesheet">
    <link media="screen" href="~/css/layout1.css" type="text/css" rel="stylesheet">
    <link media="screen" href="~/css/nav.css" type="text/css" rel="stylesheet">
    <link media="screen" href="~/css/colorbox.css" type="text/css" rel="stylesheet" />
      <%-- <link href="css/Litigation.css" rel="stylesheet" type="text/css" />--%>
      <link rel="stylesheet" type="text/css" href="css/login.css" media="screen" />
	<!--[if lt IE 9]>
	<link rel="stylesheet" href="css/ie.css" type="text/css" media="screen" />
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
    <title>Habib Al Mulla-Login Page</title>
    <style>
     .div 
     {
       background-color: #FFF;
       border : 0px solid #E8E6E7;  
     }
     #main .footer {
        margin: 0 15px;
        text-align: center;
        /*text-shadow: 1px 1px 0 #FFFFFF;*/
        float:none;
    }
    #main .footer a {
    color: #BEBEBE;
    text-transform: uppercase;
}
    </style>>
</head>
<body>
 <div class="wrap">
	<div id="content">
		<div id="main">
			<div class="full_w">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>

          <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tbody>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                            <tbody>
                                <tr style="height: 10px; padding-top: 5px;">
                                    <td>
                                        <asp:Panel runat="server" ID="pnlEnlish" Visible="false">
                                                <img alt="logo" src="<%=ResolveClientUrl("~/img/habib.png")%>" height="50px" width="250px" />
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlArebic" Visible="false">
                                                <img alt="logo" src="<%=ResolveClientUrl("~/img/habib.png")%>" height="50px"  width="250px" />
                                            </asp:Panel>
                                         
                                    </td>
                                    
                                    <td align="justify" valign="middle" style="height: 10px;">
                                        <table style="width:100%" border="0">
                                            <tr>
                                            <td></td>
                                                <td>
                                                  <%--  <asp:ImageButton ID="LanguageEnglish" runat="server" ImageUrl="~/Image/en_Flag.jpg" OnClick="EN_Click" 
                                                        Text="English" CommandArgument="en-GB" />
                                                    <asp:ImageButton ID="LanguageArebic" runat="server" ImageUrl="~/Image/arabic_flag_icon.gif" OnClick="AR_Click"
                                                        Text="Arebic" CommandArgument="ar-AE" />--%>
                                                       <asp:LinkButton ID="LanguageEnglish" Text="English" runat="server" CssClass="Link"  CommandArgument="generalEnglish.css" OnClick="btnCss2_Click"></asp:LinkButton>&nbsp;&nbsp;
                                                       <asp:LinkButton ID="LanguageArebic" Text="العربية" runat="server" CssClass="Link"  CommandArgument="generalArebic.css" OnClick="btnCss1_Click"></asp:LinkButton>
                                      
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td >
                        <table align="center" class="div">
                            <tr>
                                <td style="width: 30px">
                                </td>
                                
                                
                              
                                <td>
                                <asp:UpdatePanel ID="login" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                    
                                        <tr>
                                            <td>
                                               <asp:Label ID="lblusername" runat="server" Text="Username" meta:resourcekey="Username"
                                                    CssClass="NormalText"></asp:Label><br />
                                                 <asp:TextBox ID="txtusername" runat="server" Text=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtusername" ValidationGroup="login" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblpassword" runat="server" Text="Password" meta:resourcekey="Password"
                                                    CssClass="NormalText"></asp:Label><br />
                                                <asp:TextBox ID="txtpass" runat="server" Text="" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtpass" runat="server" ValidationGroup="login" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="buttton" meta:resourcekey="Login" OnClick="Login1_LoginError" ValidationGroup="login"/>
                                                <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                                                <br />
                                                <asp:Label ID="Error" runat="server" Font-Names="arial" CssClass="NormalText" ForeColor="#6773B6" ></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                   </ContentTemplate>
                                </asp:UpdatePanel>
                                </td>
                                <td style="width: 50px">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    <div class="sep"></div>
                    </td>
                </tr>
                
                
            </tbody>
        </table>
        </ContentTemplate>
       <Triggers>
                   <asp:PostBackTrigger ControlID="LanguageEnglish"  />
                   <asp:PostBackTrigger ControlID="LanguageArebic" />
                   <%--<asp:AsyncPostBackTrigger ControlID="LanguageEnglish" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="LanguageArebic" EventName="Click"/>--%>
                   <asp:AsyncPostBackTrigger ControlID="BtnLogin" />
         </Triggers>
        </asp:UpdatePanel>
    </div>
    
    </form>
	</div>
	       <div>&copy; <a href="">Baker & McKenzie.Habib Al Mulla</a> | 2013</div>
       </div>
	</div>
</div>

</body>
</html>
