<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Hearings.aspx.cs" Inherits="Matter_Hearings_Hearings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        #panel, #flip
        {
            padding: 5px;
        }
        #panel
        {
            border: solid 1px #c3c3c3;
            display: none;
        }
        #panel1, #flip1
        {
            padding: 5px;
        }
        #panel1
        {
            border: solid 1px #c3c3c3;
            display: none;
        }
        #panel2, #flip2
        {
            padding: 5px;
        }
        #panel2
        {
            border: solid 1px #c3c3c3;
            display: none;
        }
    </style>
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <link href="../../css/colorbox.css" type="text/css" rel="stylesheet" />
    <script src="../../js/jquery.colorbox.js" type="text/javascript"></script>
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblAllMatter" runat="server" meta:resourcekey="HHearingDetails" Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <asp:Panel ID="AddHearing" runat="server" Visible="false">
                            <a class='inline' href="#inline_content">
                                <asp:Label ID="lblAddHearings" runat="server" meta:resourcekey="Hnewhearings" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Createpleading" runat="server" Visible="false">
                            <a class='inline1' href="#inline_content1">
                                <asp:Label ID="lblpledings" runat="server" meta:resourcekey="Hcreatepladdings" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Adddecisions" runat="server" Visible="false">
                            <a class='inline2' href="#inline_content2">
                                <asp:Label ID="lbldecision" runat="server" meta:resourcekey="HaddDecision" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Addjudgement" runat="server" Visible="false">
                            <a class='inline3' href="#inline_content3">
                                <asp:Label ID="lbljudgement" runat="server" meta:resourcekey="HaddJudgement" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Adddocument" runat="server" Visible="false">
                            <a class='inline4' href="#inline_content4">
                                <asp:Label ID="lbldocument" runat="server" meta:resourcekey="HaddDocument" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="DelHearings" runat="server" Visible="false">
                            <a class='inline5' href="#inline_content5">
                                <asp:Label ID="lblDelHearings" runat="server" meta:resourcekey="DelHearings" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 3%; margin-right: 3%; margin-top: 2%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                <ContentTemplate>
                    <div>
                        <table style="width: 100%">
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="dtgHearingGrid" runat="server" Width="100%" CssClass="grid-view"
                                        OnRowCreated="gvHover_RowCreated" AutoGenerateColumns="false" DataKeyNames="Hearing_ID"
                                        AllowPaging="true" OnPageIndexChanging="dtgHearingGrid_PageIndexChanging" GridLines="Both"
                                        OnRowDataBound="dtgHearingGrid_RowDataBound" OnSelectedIndexChanged="dtgHearingGrid_SelectedIndexChanged"
                                        PageSize="10">
                                        <Columns>
                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                            <asp:BoundField DataField="Hearing_ID" HeaderText="Hearing_ID" SortExpression="Hearing_ID"
                                                meta:resourcekey="HCase_ID" Visible="false" />
                                            <asp:BoundField DataField="Case_number" HeaderText="Case #" SortExpression="Case_number"
                                                meta:resourcekey="HCAseNumbers" />
                                            <asp:BoundField DataField="Hearing_date" HeaderText="Hearing Date" SortExpression="Hearing_date"
                                                meta:resourcekey="HHearingdate1" DataFormatString="{0:dd-MMM-yyy}" />
                                            <asp:BoundField DataField="staus_desc" HeaderText="Status" SortExpression="staus_desc"
                                                meta:resourcekey="HStaus_Desc" />
                                            <asp:BoundField DataField="Pleading_status_desc_en" HeaderText="Pleading_status_desc_en"
                                                SortExpression="Pleading_status_desc_en" meta:resourcekey="Hpleading" />
                                            <asp:BoundField DataField="Hearing_Outcome_Desc_EN" HeaderText="Hearing Outcome"
                                                SortExpression="Hearing_Outcome_Desc_EN" meta:resourcekey="HHearing_Outcome_Desc_EN" />
                                        </Columns>
                                        <SelectedRowStyle BackColor=" #90AA1E" ForeColor="White" Font-Bold="false" />
                                        <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                        NextPageText="Next" PreviousPageText="Previous" />--%>
                                        <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                    </asp:GridView>
                                    <asp:Label runat="server" ID="lbl" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblcasenumber" runat="server" meta:resourcekey="HCaseno" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblhearingdate" runat="server" meta:resourcekey="HHearingdate" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblstatus" runat="server" meta:resourcekey="HStatus" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblattendedby" runat="server" meta:resourcekey="HAttendedby" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtcaseno" runat="server" CssClass="NormalText"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txthearingdate" runat="server" CssClass="NormalText"></asp:TextBox>
                                                <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txthearingdate"
                                                    PopupButtonID="txthearingdate" Format="dd-MMM-yyyy" Enabled="True">
                                                </AjaxControlToolkit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlstatus" runat="server" DataTextField="staus_desc" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="status_id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAttendedby" runat="server" DataTextField="UserName" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="Employee_Id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblhearingNote" runat="server" meta:resourcekey="HHearingnote" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="txthearingNotes" runat="server" CssClass="NormalText" TextMode="MultiLine"
                                                    Rows="3" Columns="120"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="ClientDoc" runat="server" meta:resourcekey="Clientdocket" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:LinkButton ID="LinkbtnClientDocket" runat="server" OnClick="LinkbtnClientDocket_Click"
                                                    OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="OpponentDoc" runat="server" meta:resourcekey="Opponentdocket" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:LinkButton ID="LinkbtnClientOpponent" runat="server" OnClick="LinkbtnClientOpponent_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                                <div id="flip" style="width: 15%">
                                                    <img src="../../img/icn_new_article.png" alt="Toggle" /><asp:Label ID="lblpleadings"
                                                        runat="server" Text="Pleading" CssClass="HeaderText1" meta:resourcekey="TPleading"><br /></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div id="panel">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="lblPstaus" runat="server" meta:resourcekey="HpleadingStatus" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="lblprepardby" runat="server" meta:resourcekey="Hpreparedby" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="lblprepaeddate" runat="server" meta:resourcekey="Hdateprepared" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="lblreviewd" runat="server" meta:resourcekey="HReviewdby" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 20%">
                                                                <asp:Label ID="lbldate" runat="server" meta:resourcekey="Hreviewdate" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlpleading" runat="server" DataTextField="Pleading_status_desc_en"
                                                                    AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                                                    DataValueField="Pleadings_Status_ID" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlprerparedby" runat="server" DataTextField="UserName" AppendDataBoundItems="false"
                                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="Employee_Id"
                                                                    AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbldateprepared" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblreview" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblpleadingsdate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="PleadingDocuments" runat="server" meta:resourcekey="Pleadingdocket"
                                                                    Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LinkPleadingDocument" runat="server" OnClick="LinkPleadingDocument_Click"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                                <div id="flip1" style="width: 22%">
                                                    <img src="../../img/icn_new_article.png" alt="Toggle" /><asp:Label ID="lblhearingoutcome"
                                                        runat="server" Text="Hearing Outcome" CssClass="HeaderText1" meta:resourcekey="Thearingoutcome"><br /></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div id="panel1">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lbloutcome" runat="server" meta:resourcekey="Houtcomestatus" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 75%">
                                                                <asp:Label ID="lbldecisiondetail" runat="server" meta:resourcekey="HDecisiondetails"
                                                                    Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="ddlHearingoutcome" runat="server" DataTextField="Hearing_Outcome_Desc_EN"
                                                                    AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                                                    DataValueField="Hearing_Outcome_ID" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txthearingdetails" runat="server" CssClass="NormalText" TextMode="MultiLine"
                                                                    Rows="3" Columns="90"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                                <div id="flip2" style="width: 14%">
                                                    <img src="../../img/icn_new_article.Png" alt="Toggle" /><asp:Label ID="lbljudgements"
                                                        runat="server" Text="Judgement" CssClass="HeaderText1" meta:resourcekey="TJudgement"><br /></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div id="panel2">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lbljudgementoutcome" runat="server" meta:resourcekey="Hjudgementoutcomes"
                                                                    Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 35%">
                                                                <asp:Label ID="lbldaterecive" runat="server" meta:resourcekey="Hdaterecvied" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 35%">
                                                                <asp:Label ID="JudgmentDocument" runat="server" meta:resourcekey="JudgementDoc" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddljudgment" runat="server" DataTextField="OutCome_Desc_En"
                                                                    AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                                                    DataValueField="Outcome_ID" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtjudgementdate" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="linkJudgement" runat="server" OnClick="linkJudgement_Click"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dtgHearingGrid" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="dtgHearingGrid" EventName="RowCommand" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content' style="width: 612px; margin-top: 2px">
            <h2>
                <asp:Label ID="addhearings" runat="server" Text="" meta:resourcekey="Addhearings"></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddHearingspanel" runat="server">
                    <ContentTemplate>
                        <table class="form" style="width: 75%">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMatterHearings" runat="server" meta:resourcekey="MatterNo" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="lblMatterhearing" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHearingsDate" runat="server" meta:resourcekey="HeHearingsDate"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthearngDate" runat="server" Text="" CssClass="NormalText" Width="150px"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txthearngDate"
                                            PopupButtonID="txthearngDate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqHearings" runat="server" ValidationGroup="AddHearings"
                                            ErrorMessage="*" ControlToValidate="txthearngDate"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblhearingsCaseID" runat="server" meta:resourcekey="HEcaseID" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMatterCase" runat="server" Text="0000"></asp:Label>
                                        <%--<asp:DropDownList ID="ddlCaseId" runat="server" DataTextField="Case_Number" DataValueField="Case_ID"
                                    CssClass="NormalText">
                                </asp:DropDownList>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHearingsStatus" runat="server" meta:resourcekey="Hestatus" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlHearingStaus" runat="server" DataTextField="staus_desc"
                                            data-placeholder="Select Status" DataValueField="status_id" CssClass="NormalText">
                                        </asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="ReqHearingStatus" runat="server" ValidationGroup="AddHearings" ErrorMessage="*" InitialValue=""  Display="Dynamic" ControlToValidate="ddlHearingStaus"  ></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAttendby" runat="server" meta:resourcekey="HeAttendedBy" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAttendby" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            data-placeholder="Select Employee" CssClass="NormalText">
                                        </asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="ReqAttendedby" runat="server" ValidationGroup="AddHearings" ErrorMessage="*" InitialValue="0" ControlToValidate="ddlAttendby" ></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblHeatingsNotes" runat="server" meta:resourcekey="HeHearingsNotes"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtHearingsNotes" runat="server" Text="" TextMode="MultiLine" Rows="5"
                                            Columns="35"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqHearingNotes" runat="server" ValidationGroup="AddHearings"
                                            ErrorMessage="*" ControlToValidate="txtHearingsNotes"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Button class="btn" runat="server" ID="btn" Text="Add Hearings" ValidationGroup="AddHearings"
                                            CausesValidation="true" OnClick="Addhearing_Click"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content1' style="width: 587px; margin-top: 2px">
            <h2>
                <asp:Label ID="Createpladings" runat="server" Text="" meta:resourcekey="Createpladings"></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddPleadingsPanel" runat="server">
                    <ContentTemplate>
                        <table class="form" style="width: 70%">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="pleadingCaseno" runat="server" meta:resourcekey="CaseNo" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="lblpleadingCaseno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="pleadingstatus" runat="server" meta:resourcekey="HpleadingStatus"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlpladingsst" runat="server" DataTextField="Pleading_status_desc_en"
                                            DataValueField="Pleadings_Status_ID" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="pleadingpreparedby" runat="server" meta:resourcekey="Hpreparedby"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlplpreaparedby" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="pleadingpreparedate" runat="server" meta:resourcekey="pleadingpreparedate"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpladingdate" runat="server" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="calenddate" runat="server" TargetControlID="txtpladingdate"
                                            PopupButtonID="txtpladingdate" Format="dd-MMM-yyyy" Enabled="True">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqPleading" runat="server" ValidationGroup="AddPleading"
                                            ErrorMessage="*" ControlToValidate="txtpladingdate"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblreviewby" runat="server" meta:resourcekey="Reviewby" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlreviewby" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Button class="btn" runat="server" ID="Button1" Text="Add Pleadings" ValidationGroup="AddPleading"
                                            CausesValidation="true" OnClick="CreatePleading_Click"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content2' style="width: 575px; margin-top: 2px">
            <h2>
                <asp:Label ID="AddDecision" runat="server" Text="" meta:resourcekey="AddDecision"></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddDecisionpanel" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="DecisionCaseno" runat="server" meta:resourcekey="CaseNo" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="txtDecisionCaseno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Decisionoutcome" runat="server" meta:resourcekey="DecsionOutcome"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddlDecisionoutcome" runat="server" DataTextField="Hearing_Outcome_Desc_EN"
                                            DataValueField="Hearing_Outcome_ID" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Decisiondetails" runat="server" meta:resourcekey="DecsionDetails"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDecisiondetails" runat="server" Text="" TextMode="MultiLine"
                                            Rows="5" Columns="45"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqDecisionDetails" runat="server" ValidationGroup="AddDecision"
                                            ErrorMessage="*" ControlToValidate="txtDecisiondetails"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btndecision" Text="Add Decision" ValidationGroup="AddDecision"
                                            CausesValidation="true" OnClick="AddDecision_Click"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content3' style="width: 575px; margin-top: 2px">
            <h2>
                <asp:Label ID="ADDjudgements" runat="server" Text="" meta:resourcekey="ADDjudgement"></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddJudgementpanel" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Judgementcaseno" runat="server" meta:resourcekey="CaseNo" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="lblJudgementcaseno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="judgements" runat="server" meta:resourcekey="Judgement" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddlJudgements" runat="server" DataTextField="OutCome_Desc_En"
                                            DataValueField="Outcome_ID" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblJudgementDeatils" runat="server" meta:resourcekey="JudgementDetails"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJudgementDeatils" runat="server" Text="" TextMode="MultiLine"
                                            Rows="5" Columns="45"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RrqJudgementdtl" runat="server" ValidationGroup="AddJudgement"
                                            ErrorMessage="*" ControlToValidate="txtJudgementDeatils"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lbljudgementdate" runat="server" meta:resourcekey="JudgementDate"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="judgementdate" runat="server" Text=""></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="caljudgementdate" runat="server" TargetControlID="judgementdate"
                                            PopupButtonID="judgementdate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqJudgementdate" runat="server" ValidationGroup="AddJudgement"
                                            ErrorMessage="*" ControlToValidate="txtJudgementDeatils"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblJudgementDocument" runat="server" meta:resourcekey="JudgementDoc"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <AjaxControlToolkit:AsyncFileUpload runat="server" ID="FileuploadJudgement" CompleteBackColor="White"
                                            UploadingBackColor="#CCFFFF" ThrobberID="imgLoader3" OnUploadedComplete="FileUploadCompleteJudge" />
                                        <asp:Image ID="imgLoader3" runat="server" ImageUrl="~/Images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnJudge" Text="Add Judgement" ValidationGroup="AddJudgement"
                                            CausesValidation="true" OnClick="AddJudgement_Click"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content4' style="width: 575px; margin-top: 2px">
            <h2>
                <asp:Label ID="Label1" runat="server" Text="" meta:resourcekey="HaddDocument"></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tr>
                                <td>
                                    <asp:Label ID="documentcaseno" runat="server" meta:resourcekey="CaseNo" Text="" CssClass="HeaderText"></asp:Label>
                                </td>
                                <td style="width: 15px">
                                </td>
                                <td colspan="4">
                                    <asp:Label ID="lbldocumentcaseno" runat="server" Text="0000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblclientdocket" runat="server" meta:resourcekey="Clientdocket" CssClass="HeaderText"
                                        Text=""></asp:Label>
                                </td>
                                <td style="width: 15px">
                                </td>
                                <td colspan="4">
                                    <AjaxControlToolkit:AsyncFileUpload runat="server" ID="FileUploadClient" CompleteBackColor="White"
                                        UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" OnUploadedComplete="FileUploadCompleteClient" />
                                    <asp:Image ID="imgLoader" runat="server" ImageUrl="~/Images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblopponentdocket" runat="server" meta:resourcekey="Opponentdocket"
                                        CssClass="HeaderText" Text=""></asp:Label>
                                </td>
                                <td style="width: 15px">
                                </td>
                                <td colspan="4">
                                    <AjaxControlToolkit:AsyncFileUpload runat="server" ID="FileUploadOpponent" CompleteBackColor="White"
                                        UploadingBackColor="#CCFFFF" ThrobberID="imgLoader1" OnUploadedComplete="FileUploadCompleteOpponent" />
                                    <asp:Image ID="imgLoader1" runat="server" ImageUrl="~/Images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblpleadingdocket" runat="server" meta:resourcekey="Pleadingdocket"
                                        CssClass="HeaderText" Text=""></asp:Label>
                                </td>
                                <td style="width: 15px">
                                </td>
                                <td colspan="4">
                                    <AjaxControlToolkit:AsyncFileUpload runat="server" ID="FileUploadPleading" CompleteBackColor="White"
                                        UploadingBackColor="#CCFFFF" ThrobberID="imgLoader2" OnUploadedComplete="FileUploadCompletePleading" />
                                    <asp:Image ID="imgLoader2" runat="server" ImageUrl="~/Images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button class="btn" runat="server" ID="btnDocument" Text="Add Document" CausesValidation="true"
                                        OnClick="hearingDocument_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content5' style="width: 612px; margin-top: 2px">
            <h2>
                <asp:Label ID="lblDelHearing" runat="server" Text="" meta:resourcekey="DelHearings"></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="form" style="width: 75%">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="delmatterno" runat="server" meta:resourcekey="MatterNo" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:Label ID="txtdelmatterno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="delhearingdate" runat="server" meta:resourcekey="HeHearingsDate" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdelhearingdate" runat="server" Text="" CssClass="NormalText"
                                            Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="delcaseid" runat="server" meta:resourcekey="HEcaseID" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="txtdelcaseid" runat="server" Text="0000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="delsatus" runat="server" meta:resourcekey="Hestatus" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlstatus" runat="server" DataTextField="staus_desc" data-placeholder="Select Status"
                                            DataValueField="status_id" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="delattendeby" runat="server" meta:resourcekey="HeAttendedBy" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlattendedby" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            data-placeholder="Select Employee" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="delhnptes" runat="server" meta:resourcekey="HeHearingsNotes" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtdelhearingsnotes" runat="server" Text="" TextMode="MultiLine"
                                            Rows="5" Columns="35"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Button class="btn" runat="server" ID="Button2" Text="Delete Hearings" CausesValidation="true"
                                            OnClick="Deletehearing_Click"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#ctl00_ContentPlaceHolder1_ddljudgment").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlHearingoutcome").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlprerparedby").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlpleading").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlAttendedby").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlstatus").chosen();
            $("#ctl00_ContentPlaceHolder1_AddHearingOutcome").chosen();


            $("#ctl00_ContentPlaceHolder1_ddlJudgements").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlDecisionoutcome").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlpladingsst").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlreviewby").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlplpreaparedby").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlCaseId").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlAttendby").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlHearingStaus").chosen();

            $("#ctl00_ContentPlaceHolder1_delddlattendedby").chosen();
            $("#ctl00_ContentPlaceHolder1_delddlstatus").chosen();

            $(".inline").colorbox({ inline: true, width: "53%", height: "75%" });
            $(".inline1").colorbox({ inline: true, width: "51%", height: "75%" });
            $(".inline2").colorbox({ inline: true, width: "50%", height: "75%" });
            $(".inline3").colorbox({ inline: true, width: "50%", height: "75%" });
            $(".inline4").colorbox({ inline: true, width: "50%", height: "75%" });
            $(".inline5").colorbox({ inline: true, width: "53%", height: "75%" });
            $("#colorbox, #cboxOverlay").appendTo('form:first');
            $(document).ready(function () {

                $("#flip").click(function () {
                    $("#panel").slideToggle("slow");

                });
                $("#flip1").click(function () {
                    $("#panel1").slideToggle("slow");
                });
                $("#flip2").click(function () {
                    $("#panel2").slideToggle("slow");

                });

            });
        }
        
    </script>
</asp:Content>
