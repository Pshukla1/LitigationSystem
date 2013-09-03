<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CasesDetails.aspx.cs" Inherits="Matter_Cases_Cases" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblAllMatter" runat="server" meta:resourcekey="CCaseDetails" Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <asp:Panel ID="Addcase" runat="server" Visible="false">
                            <a class='inline' href="#inline_content">
                                <asp:Label ID="lblAddcaseh" runat="server" meta:resourcekey="CAddCase" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Closecase" runat="server" Visible="false">
                            <a class='inline1' href="#inline_content1">
                                <asp:Label ID="lblclose" runat="server" meta:resourcekey="CClosecase" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Addhearing" runat="server" Visible="false">
                            <a class='inline2' href="#inline_content2">
                                <asp:Label ID="lbladdhearings" runat="server" meta:resourcekey="CaddHearings" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="DelCase" runat="server" Visible="false">
                            <a class='inline3' href="#inline_content3">
                                <asp:Label ID="lbldelcase" runat="server" meta:resourcekey="Delcase" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
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
                                    <asp:GridView ID="dtgCaseGrid" runat="server" Width="100%" CssClass="grid-view" OnRowCreated="gvHover_RowCreated"
                                        AutoGenerateColumns="false" DataKeyNames="Case_ID" AllowPaging="true" OnPageIndexChanging="dtgCaseGrid_PageIndexChanging"
                                        GridLines="Both" OnRowDataBound="dtgCaseGrid_RowDataBound" OnSelectedIndexChanged="dtgCaseGrid_SelectedIndexChanged"
                                        PageSize="10">
                                        <Columns>
                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                            <asp:BoundField DataField="Case_ID" HeaderText="Case_ID" SortExpression="Case_ID"
                                                meta:resourcekey="CCase_ID" Visible="false" />
                                            <asp:BoundField DataField="Case_number" HeaderText="Case_number" SortExpression="Case_number"
                                                meta:resourcekey="Case_number" Visible="true" />
                                            <asp:BoundField DataField="Case_Type_desc" HeaderText="Case Type" SortExpression="Case_Type_desc"
                                                meta:resourcekey="CCase_Type_desc" />
                                            <asp:BoundField DataField="Staus_Desc" HeaderText="Staus" SortExpression="Staus_Desc"
                                                meta:resourcekey="CStaus_Desc" />
                                            <asp:BoundField DataField="stage_type_desc" HeaderText="Stage" SortExpression="stage_type_desc"
                                                meta:resourcekey="Cstage_type_desc" />
                                            <asp:BoundField DataField="Registration_Date" HeaderText="Registration Date" SortExpression="Registration_Date"
                                                meta:resourcekey="CRegistration_Date" DataFormatString="{0:dd-MMM-yyy}" />
                                            <asp:BoundField DataField="End_date" HeaderText="End Date" SortExpression="End_date"
                                                meta:resourcekey="CEnd_date" DataFormatString="{0:dd-MMM-yyy}" />
                                            <asp:BoundField DataField="Hearing_Outcome_Desc_EN" HeaderText="Hearing Outcome"
                                                SortExpression="Hearing_Outcome_Desc_EN" meta:resourcekey="CHearing_Outcome_Desc_EN" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#90AA1E" ForeColor="White" Font-Bold="false" />
                                        <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                        NextPageText="Next" PreviousPageText="Previous" />--%>
                                        <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                    </asp:GridView>
                                    <asp:Label runat="server" ID="lbl" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="caseno" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCasenumber" runat="server" meta:resourcekey="Caseno" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblcasetype" runat="server" meta:resourcekey="Casetype" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblstaus" runat="server" meta:resourcekey="status" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblstage" runat="server" meta:resourcekey="stage" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtcaseno" runat="server" CssClass="NormalText"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlcasetype" runat="server" DataTextField="Case_Type_desc"
                                                    AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                                    DataValueField="Case_Type_ID" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlstatus" runat="server" DataTextField="Staus_Desc" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="Satus_id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlstage" runat="server" DataTextField="stage_type_desc" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="stage_type_id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblfdate" runat="server" meta:resourcekey="Fillingdate" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbledate" runat="server" meta:resourcekey="Enddate" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcourt" runat="server" meta:resourcekey="Court" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcourtclk" runat="server" meta:resourcekey="courtcleark" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtfillingdate" runat="server" CssClass="NormalText"></asp:TextBox>
                                                <AjaxControlToolkit:CalendarExtender ID="calFilingdate" runat="server" TargetControlID="txtfillingdate"
                                                    PopupButtonID="txtfillingdate" Format="dd-MMM-yyyy" Enabled="True">
                                                </AjaxControlToolkit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtenddate" runat="server" CssClass="NormalText"></asp:TextBox>
                                                <AjaxControlToolkit:CalendarExtender ID="calenddate" runat="server" TargetControlID="txtenddate"
                                                    PopupButtonID="txtenddate" Format="dd-MMM-yyyy" Enabled="True">
                                                </AjaxControlToolkit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlcourt" runat="server" DataTextField="court" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="court_id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <%--<asp:DropDownList ID="ddloutcome" runat="server" DataTextField="UserName" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="Employee_Id"
                                                    AutoPostBack="true" >
                                                </asp:DropDownList>--%>
                                            <td>
                                                <asp:DropDownList ID="ddlcourtcleark" runat="server" DataTextField="UserName" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="Employee_Id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblccapity" runat="server" meta:resourcekey="Clinetcapcity" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblocapity" runat="server" meta:resourcekey="Opponentcapcity" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbljudge" runat="server" meta:resourcekey="Judge" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldname" runat="server" meta:resourcekey="Departmentname" Text=""></asp:Label>>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlclientCap" runat="server" DataTextField="capcitiy" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="Capacity_id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlopponentCap" runat="server" DataTextField="capcitiy" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="Capacity_id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddljudge" runat="server" DataTextField="JudgeName" AppendDataBoundItems="false"
                                                    data-placeholder="Supervising Lawyer" CssClass="NormalText" DataValueField="judge_id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddldepartment" runat="server" DataTextField="Department_Name_EN"
                                                    AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                                    DataValueField="Department_ID" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblhallno" runat="server" meta:resourcekey="hallnumber" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txthallNumber" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dtgCaseGrid" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content' style="width: 600px; margin-top: 2px">
            <h2>
                <asp:Label ID="lblAddCase" runat="server" meta:resourcekey="AddCase" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel runat="server" ID="Casepnl">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMatterNo" runat="server" meta:resourcekey="CMatter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:Label ID="lblCasematterNum" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStageCase" runat="server" meta:resourcekey="CStage" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCasestage" runat="server" DataTextField="stage_type_desc"
                                            DataValueField="Stage_Id" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcourtcleark" runat="server" meta:resourcekey="Ccourtcleark" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlclerkname" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <%--<td>
                                <asp:Label ID="lblStatus" runat="server" meta:resourcekey="Cstaus" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width:20px"></td>
                            <td>
                                <asp:DropDownList ID="ddlcaseStatus" runat="server" DataTextField="Staus_Desc" DataValueField="Satus_id"
                                    CssClass="NormalText">
                                </asp:DropDownList>
                            </td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCaseNo" runat="server" meta:resourcekey="CCase" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcasenumber" runat="server" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqCaseNo" runat="server" ValidationGroup="AddCase"
                                            ErrorMessage="*" ControlToValidate="txtcasenumber"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblctype" runat="server" meta:resourcekey="CCaseType" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlcasetypedata" runat="server" DataTextField="Case_Type_desc"
                                            DataValueField="Case_Type_ID" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCFillingDate" runat="server" meta:resourcekey="CFillingDate" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtfillindatde" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfillindatde"
                                            PopupButtonID="txtfillindatde" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqFillingdate" runat="server" ValidationGroup="AddCase"
                                            ErrorMessage="*" ControlToValidate="txtfillindatde"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEndDAte" runat="server" meta:resourcekey="CEnddate" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEdate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtEdate"
                                            PopupButtonID="txtEdate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqEnddate" runat="server" ValidationGroup="AddCase"
                                            ErrorMessage="*" ControlToValidate="txtEdate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblclientCapcity" runat="server" meta:resourcekey="CClientCapicity"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlClientCapty" runat="server" DataTextField="capcitiy" DataValueField="Capacity_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbloppnentscapcity" runat="server" meta:resourcekey="COpoonentCapicty"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlOppCap" runat="server" DataTextField="capcitiy" DataValueField="Capacity_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHallNumber" runat="server" meta:resourcekey="hallnumber" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHallnoADDPoPUP" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqhallPOpup" runat="server" ValidationGroup="AddCase"
                                            ErrorMessage="*" ControlToValidate="txtHallnoADDPoPUP"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldepartment" runat="server" meta:resourcekey="Departmentname" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDepartmentADDPOPUP" runat="server" DataTextField="Department_Name_EN"
                                            AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                            DataValueField="Department_ID" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbljudgename" runat="server" meta:resourcekey="Cjudge" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddljudgename" runat="server" DataTextField="JudgeName" DataValueField="judge_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcourtname" runat="server" meta:resourcekey="Ccourt" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlcourtname" runat="server" DataTextField="court" DataValueField="court_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblCaseDiscription" runat="server" meta:resourcekey="SstageDiscription"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtxCasediscription" runat="server" Text="" TextMode="MultiLine"
                                            Rows="5" Columns="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqDiscription" runat="server" ValidationGroup="AddCase"
                                            ErrorMessage="*" ControlToValidate="txtxCasediscription"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnCase" Text="Add Case" ValidationGroup="AddCase"
                                            CausesValidation="true" OnClick="AddCase_Click"></asp:Button>
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
        <div class="box round first fullpage" id='inline_content1' style="width: 600px; margin-top: 2px">
            <h2>
                <asp:Label ID="lblclosecase" runat="server" meta:resourcekey="Closecase" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="CloseCasePanel" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAMatternumber" runat="server" meta:resourcekey="CMatter" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:Label ID="txtAMatternumber" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAstage" runat="server" meta:resourcekey="CStage" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlastage" runat="server" DataTextField="stage_type_desc" DataValueField="stage_type_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblacourtclerk" runat="server" meta:resourcekey="Ccourtcleark" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dddAcourtclek" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblacase" runat="server" meta:resourcekey="CCase" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtacase" runat="server" Text=""></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblacaetype" runat="server" meta:resourcekey="CCaseType" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlacasetype" runat="server" DataTextField="Case_Type_desc"
                                            DataValueField="Case_Type_ID" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblafillinddate" runat="server" meta:resourcekey="CFillingDate" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtafillinddate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtafillinddate"
                                            PopupButtonID="txtafillinddate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblaEnddate" runat="server" meta:resourcekey="CEnddate" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtaEnddate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtaEnddate"
                                            PopupButtonID="txtaEnddate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblaclientcap" runat="server" meta:resourcekey="CClientCapicity" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAclientcap" runat="server" DataTextField="capcitiy" DataValueField="Capacity_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblaoppcap" runat="server" meta:resourcekey="COpoonentCapicty" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlaoppcap" runat="server" DataTextField="capcitiy" DataValueField="Capacity_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblahallnumber" runat="server" meta:resourcekey="hallnumber" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtahallnumner" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbladeptname" runat="server" meta:resourcekey="Departmentname" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddladeptname" runat="server" DataTextField="Department_Name_EN"
                                            AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                            DataValueField="Department_ID" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblajudge" runat="server" meta:resourcekey="Cjudge" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlajudge" runat="server" DataTextField="JudgeName" DataValueField="judge_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblacourt" runat="server" meta:resourcekey="Ccourt" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlacourt" runat="server" DataTextField="court" DataValueField="court_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lbladiscription" runat="server" meta:resourcekey="SstageDiscription"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtadiscription" runat="server" Text="" TextMode="MultiLine" Rows="5"
                                            Columns="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblCaseStatus" runat="server" meta:resourcekey="Cstaus" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:DropDownList ID="ddlcaseStatus" runat="server" DataTextField="Staus_Desc" DataValueField="Satus_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnCloseCase" Text="Close Case" ValidationGroup="CloseCase"
                                            CausesValidation="true" OnClick="CloseCase_Click"></asp:Button>
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
        <div class="box round first fullpage" id='inline_content2' style="width: 600px; margin-top: 2px">
            <h2>
                <asp:Label ID="lblhearings" runat="server" meta:resourcekey="AddHearings" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddhearingPnl" runat="server">
                    <ContentTemplate>
                        <table class="form" style="width: 80%">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMatterHearings" runat="server" meta:resourcekey="HeMatter" Text=""
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
                                        <asp:TextBox ID="txthearngDate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txthearngDate"
                                            PopupButtonID="txthearngDate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqHearings" runat="server" ValidationGroup="AddHearings"
                                            ErrorMessage="*" ControlToValidate="txthearngDate"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblhearingsCaseID" runat="server" meta:resourcekey="Caseno" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="CaseNo_AddHearings" runat="server" Text="0000"></asp:Label>
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
                                            DataValueField="status_id" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAttendby" runat="server" meta:resourcekey="HeAttendedBy" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAttendby" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
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
        <div class="box round first fullpage" id='inline_content3' style="width: 600px; margin-top: 2px">
            <h2>
                <asp:Label ID="Label1" runat="server" meta:resourcekey="Closecase" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="delmatterno" runat="server" meta:resourcekey="CMatter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:Label ID="txtdelmatterno" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="delstage" runat="server" meta:resourcekey="CStage" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlstage" runat="server" DataTextField="stage_type_desc"
                                            DataValueField="stage_type_id" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="delcourtclerrk" runat="server" meta:resourcekey="Ccourtcleark" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlcourtclerk" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="delcaseno" runat="server" meta:resourcekey="CCase" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdelcaseno" runat="server" Text=""></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="delcasetype" runat="server" meta:resourcekey="CCaseType" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlcasetype" runat="server" DataTextField="Case_Type_desc"
                                            DataValueField="Case_Type_ID" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="delfillingdate" runat="server" meta:resourcekey="CFillingDate" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdelfillingdate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="delenddate" runat="server" meta:resourcekey="CEnddate" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdelenddate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="delcacityclient" runat="server" meta:resourcekey="CClientCapicity"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlcapcityclient" runat="server" DataTextField="capcitiy"
                                            DataValueField="Capacity_id" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="delcacityopponent" runat="server" meta:resourcekey="COpoonentCapicty"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlcapcityopp" runat="server" DataTextField="capcitiy" DataValueField="Capacity_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="delhallnumber" runat="server" meta:resourcekey="hallnumber" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdelhallno" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="deldepartname" runat="server" meta:resourcekey="Departmentname" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddldepartnent" runat="server" DataTextField="Department_Name_EN"
                                            AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                            DataValueField="Department_ID" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="deljudge" runat="server" meta:resourcekey="Cjudge" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddljudge" runat="server" DataTextField="JudgeName" DataValueField="judge_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="delcourt" runat="server" meta:resourcekey="Ccourt" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="delddlcourt" runat="server" DataTextField="court" DataValueField="court_id"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="deldiscription" runat="server" meta:resourcekey="SstageDiscription"
                                            Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtdeldiscription" runat="server" Text="" TextMode="MultiLine" Rows="5"
                                            Columns="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="Button1" Text="Delete Case" CausesValidation="true"
                                            OnClick="DeleteCase_Click"></asp:Button>
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
            $("#ctl00_ContentPlaceHolder1_ddlcasetype").chosen();
            $("#ctl00_ContentPlaceHolder1_ddldepartment").chosen();
            $("#ctl00_ContentPlaceHolder1_ddljudge").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlopponentCap").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlclientCap").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcourtcleark").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcourt").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlstage").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlstatus").chosen();

            $("#ctl00_ContentPlaceHolder1_ddlcourtname").chosen();
            $("#ctl00_ContentPlaceHolder1_ddljudgename").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlDepartmentADDPOPUP").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlOppCap").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlClientCapty").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcasetypedata").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlCasestage").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlclerkname").chosen();


            $("#ctl00_ContentPlaceHolder1_ddlacourt").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlajudge").chosen();
            $("#ctl00_ContentPlaceHolder1_ddladeptname").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlaoppcap").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlclientCap").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlacasetype").chosen();
            $("#ctl00_ContentPlaceHolder1_dddAcourtclek").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlastage").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlstatus").chosen();


            $("#ctl00_ContentPlaceHolder1_delddlcourt").chosen();
            $("#ctl00_ContentPlaceHolder1_delddljudge").chosen();
            $("#ctl00_ContentPlaceHolder1_delddldepartnent").chosen();
            $("#ctl00_ContentPlaceHolder1_delddlcapcityopp").chosen();
            $("#ctl00_ContentPlaceHolder1_delddlcapcityclient").chosen();
            $("#ctl00_ContentPlaceHolder1_delddlcasetype").chosen();
            $("#ctl00_ContentPlaceHolder1_delddlstage").chosen();
            $("#ctl00_ContentPlaceHolder1_delddlcourtclerk").chosen();


            $("#ctl00_ContentPlaceHolder1_ddlcaseStatus").chosen();

            $("#ctl00_ContentPlaceHolder1_ddlAttendby").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlHearingStaus").chosen();
            //without this PainFUll
            $("#colorbox, #cboxOverlay").appendTo('form:first');

            $(".inline").colorbox({ inline: true, width: "52%", height: "90%" });
            $(".inline1").colorbox({ inline: true, width: "52%", height: "90%" });
            $(".inline2").colorbox({ inline: true, width: "52%", height: "90%" });
            $(".inline3").colorbox({ inline: true, width: "52%", height: "90%" });
            //event.preventDefault();
        }
        
    </script>
</asp:Content>
