<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="FeeDetailsandPOA.aspx.cs" Inherits="Matter_ViewMatter_FeeDetailsandPOA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <link href="../../css/colorbox.css" type="text/css" rel="stylesheet" />
    <script src="../../js/jquery.colorbox.js" type="text/javascript"></script>
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblFessandPOA" runat="server" meta:resourcekey="FeesAndPOA" Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="Addfee" Visible="false">
                            <a class='inline' href="#inline_content">
                                <asp:Label ID="lblAddForecase" runat="server" meta:resourcekey="AddFeeDetails" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel runat="server" ID="AddPOA" Visible="false">
                            <a class='inline1' href="#inline_content1">
                                <asp:Label ID="lbladdstage" runat="server" meta:resourcekey="AddPoas" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 3%; margin-right: 3%; margin-top: 2%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="1" cellspacing="1" border="0">
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="DtgMatter" runat="server" Width="100%" CssClass="grid-view" AllowPaging="true"
                                    PageSize="10" OnRowCreated="gvHover_RowCreated" AutoGenerateColumns="False" DataKeyNames="Matter_Id"
                                    OnPageIndexChanging="DtgMatter_PageIndexChanging" GridLines="Both" OnRowDataBound="DtgMatter_RowDataBound"
                                    OnSelectedIndexChanged="DtgMatter_SelectedIndexChanged">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select" Visible="false" />
                                        <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" meta:resourcekey="HMatter"
                                            Visible="false" />
                                        <asp:BoundField DataField="Matter_number" HeaderText="Matter#" SortExpression="Matter_number"
                                            meta:resourcekey="HMatter" />
                                        <asp:BoundField DataField="Open_date" HeaderText="Open Date" meta:resourcekey="HOpendate"
                                            DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="Clientname" HeaderText="Client" meta:resourcekey="Hclient" />
                                        <asp:BoundField DataField="AssignedLawyer" HeaderText="Supervising Lawyer" meta:resourcekey="HRlawyer" />
                                        <asp:BoundField DataField="ResponsibileLawyer" HeaderText="Assigned lawyer" meta:resourcekey="HAssigned" />
                                        <asp:BoundField DataField="Matter_Type_Desc" HeaderText="MatterType" meta:resourcekey="HMatterType" />
                                        <asp:BoundField DataField="Staus_Desc" HeaderText="Status" meta:resourcekey="HStatus" />
                                    </Columns>
                                  
                                     <SelectedRowStyle BackColor=" #90AA1E" ForeColor="White" Font-Bold="false" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <PagerStyle CssClass="PagerStyle" />
                                </asp:GridView>
                                <asp:Label runat="server" ID="lbl" Text="" ForeColor="Red" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Label ID="DlblFeeamonut" runat="server" meta:resourcekey="FeeAmount" Text=""
                                                    CssClass="HeaderText"></asp:Label>
                                            </td>
                                            <td style="width: 15px">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="DtxtFeeamonut" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="DlblSucessFess" runat="server" meta:resourcekey="SucessFee" Text=""
                                                    CssClass="HeaderText"></asp:Label>
                                            </td>
                                            <td style="width: 15px">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="DtxtSucessFess" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="DlblFeeEstimate" runat="server" meta:resourcekey="FeeEstimate" CssClass="HeaderText"
                                                    Text=""></asp:Label>
                                            </td>
                                            <td style="width: 15px">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="DtxtFeeEstimate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Label ID="DlblFeeDiscription" runat="server" meta:resourcekey="FeeDiscription"
                                                    CssClass="HeaderText" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 15px">
                                            </td>
                                            <td colspan="7">
                                                <asp:TextBox ID="DtxtFeeDiscription" runat="server" Text="" TextMode="MultiLine"
                                                    Rows="3" Columns="70"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Label ID="DlblAgreement" runat="server" meta:resourcekey="FeeAgreement" CssClass="HeaderText"
                                                    Text=""></asp:Label>
                                            </td>
                                            <td style="width: 15px">
                                            </td>
                                            <td colspan="7">

                                                <asp:LinkButton ID="linkfeedocument" runat="server" OnClick="openFIle"></asp:LinkButton>  
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dtgPOAGRID" runat="server" Width="100%" CssClass="grid-view"
                                    AllowPaging="true" PageSize="10" GridLines="Both" AutoGenerateColumns="False"
                                    DataKeyNames="POA_id">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select" Visible="false" />
                                        <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" meta:resourcekey="HMatter"
                                            Visible="false" />
                                        <asp:BoundField DataField="Poa_Types_desc" HeaderText="POA Type" meta:resourcekey="HPOAType" />
                                        <asp:BoundField DataField="Issue_date" HeaderText="Issue Date" meta:resourcekey="HIssuedate"
                                            DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="Location_desc" HeaderText="Location" meta:resourcekey="Hlocation" />
                                        <asp:BoundField DataField="Notes" HeaderText="Notes" meta:resourcekey="HNOTE" />
                                    </Columns>
                                    <RowStyle CssClass="RowStyle" Height="25px" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <PagerStyle CssClass="PagerStyle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DtgMatter" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="DtgMatter" EventName="RowCommand" />
                    <%--<asp:PostBackTrigger  />
                            <asp:PostBackTrigger  />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none;'>
        <div class="box round first fullpage" id='inline_content' style="width: 575px;margin-top:2px">
            <h2>
                <asp:Label ID="AddFess" runat="server" meta:resourcekey="AddFeeDetails" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="FeeDetailsPanel" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMatter" runat="server" meta:resourcekey="Matter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:Label ID="txtMatterno" runat="server" Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFeeamonut" runat="server" meta:resourcekey="FeeAmount" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFeeamonut" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqFeeAmonut" runat="server" ValidationGroup="AddFee"
                                            ErrorMessage="*" ControlToValidate="txtFeeamonut"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSucessFess" runat="server" meta:resourcekey="SucessFee" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSucessFess" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqSucessFess" runat="server" ValidationGroup="AddFee"
                                            ErrorMessage="*" ControlToValidate="txtSucessFess"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFeeEstimate" runat="server" meta:resourcekey="FeeEstimate" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFeeEstimate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqFeeEstimate" runat="server" ValidationGroup="AddFee"
                                            ErrorMessage="*" ControlToValidate="txtFeeEstimate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblFeeDiscription" runat="server" meta:resourcekey="FeeDiscription"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtFeeDiscription" runat="server" Text="" TextMode="MultiLine" Rows="5"
                                            Columns="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqDiscription" runat="server" ValidationGroup="AddFee"
                                            ErrorMessage="*" ControlToValidate="txtFeeDiscription"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblAgreement" runat="server" meta:resourcekey="FeeAgreement" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td colspan="4">
                                        <AjaxControlToolkit:asyncfileupload   runat="server" id="FileFeeAgreement"   completebackcolor="White"
                                            uploadingbackcolor="#CCFFFF" throbberid="imgLoader" onuploadedcomplete="FileUploadComplete" />
                                          <asp:Image ID="imgLoader" runat="server" ImageUrl="~/Images/loading.gif" />
                                         <asp:Label ID="lbluploadpath" runat="server" Text="Label" Visible="false"></asp:Label>                                  
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnFeeDetails" Text="Add Details" ValidationGroup="AddFee"
                                            CausesValidation="true" OnClick="btnAddFeeDetails_Click"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnFeeDetails" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content1' style="width: 600px;margin-top:2px">
            <h2>
                <asp:Label ID="AddPoas" runat="server" meta:resourcekey="AddPoas" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="PoaSPanel" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td style="width: 5%">
                                        <asp:Label ID="lblPOAMatter" runat="server" meta:resourcekey="Matter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="lblPOAmatterno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 5%">
                                        <asp:Label ID="lblPOAType" runat="server" meta:resourcekey="POAType" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                   <td style="width: 18%">
                                        <asp:DropDownList ID="ddlPOATypes" runat="server" DataTextField="Poa_Types_desc"
                                            data-placeholder="POA Type" CssClass="NormalText" DataValueField="Poa_Type_Id"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPoAissuedate" runat="server" meta:resourcekey="POAIssuedate" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtissuedate" runat="server" Text=""></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtissuedate"
                                            PopupButtonID="txtissuedate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="Reqissuedate" runat="server" ValidationGroup="Poas"
                                            ErrorMessage="*" ControlToValidate="txtissuedate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                   <td style="width: 5%">
                                        <asp:Label ID="lbllocation" runat="server" meta:resourcekey="location" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlLocation" runat="server" DataTextField="Location_desc" data-placeholder="Location"
                                            CssClass="NormalText" DataValueField="Location_id" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 5%">
                                        <asp:Label ID="lblPoasDocument" runat="server" meta:resourcekey="Document" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="3">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnAddPoas" Text="Add POAs" ValidationGroup="AddForecast"
                                            CausesValidation="true" OnClick="btnAddPOAS_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="lblsucess" runat="server" Text="Label" Visible="false" meta:resourcekey="Sucess"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <%-- <asp:AsyncPostBackTrigger  ControlID="btn" EventName="Click" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#ctl00_ContentPlaceHolder1_ddlLocation").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlPOATypes").chosen();
            $("#ctl00_ContentPlaceHolder1_DddlLocation").chosen();
            $("#ctl00_ContentPlaceHolder1_DddlPOATypes").chosen();

            $(".inline").colorbox({ inline: true, width: "50%", height: "75%" });
            $(".inline1").colorbox({ inline: true, width: "52%", height: "75%" });
            $("#colorbox, #cboxOverlay").appendTo('form:first');

        }
              
        
    </script>
</asp:Content>
