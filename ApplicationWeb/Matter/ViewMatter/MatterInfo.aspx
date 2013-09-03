<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="MatterInfo.aspx.cs" Inherits="Matter_ViewMatter_MatterInfo" %>

<%@ Register Assembly="Highchart" Namespace="Highchart.UI" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../js/grid.js" type="text/javascript"></script>
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblMatterDetails" runat="server" meta:resourcekey="MMatterDetails"
                Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <asp:Panel ID="PrintMatter" runat="server" Visible="false">
                            <a href="../Reports/PrintMatter.aspx" target="_blank">
                                <asp:Label ID="lblMAddHearings" runat="server" meta:resourcekey="MPrintMatterList"
                                    Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="AddMatter" runat="server" Visible="false">
                            <a class='inline' href="#inline_content">
                                <asp:Label ID="lblMAddMatter" runat="server" meta:resourcekey="MAddMatter" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="CloseMatter" runat="server" Visible="false">
                            <a class='inline1' href="#inline_content1">
                                <asp:Label ID="lblMAddstage" runat="server" meta:resourcekey="McloseMatter" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="ManageFallower" runat="server" Visible="false">
                            <a class='inline2' href="#inline_content2">
                                <asp:Label ID="lblMangeFallower" runat="server" meta:resourcekey="MFallower" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 3%; margin-right: 3%; margin-top: 2%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                <ContentTemplate>
                    <table width="80%" align="center" cellpadding="1" cellspacing="1" border="0">
                        <%-- <tr class="Tbltr">
                                    <td>
                                        <asp:Label ID="lblClient" runat="server" meta:resourcekey="Client" Text="" CssClass="lblForm"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblcientdata" runat="server" Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblClient" runat="server" meta:resourcekey="Client" Text="" CssClass="lblForm"
                                    Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="lblcientdata" runat="server" Text="" CssClass="NormalText"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblmatterNo" runat="server" meta:resourcekey="Matter" Text="" CssClass="lblForm"
                                    Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="LblMatterData" runat="server" Text="Label" CssClass="NormalText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" meta:resourcekey="Status" Text="" CssClass="lblForm"
                                    Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="lblStatusText" runat="server" Text="Label" CssClass="NormalText"></asp:Label>
                            </td>
                            <%-- <td>
                                        <asp:Label ID="LblCurrentStage" runat="server" meta:resourcekey="Stage" Text="" CssClass="lblForm"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LblCurrentStageText" runat="server" Text="Label" CssClass="NormalText"></asp:TextBox>
                                    </td>--%>
                            <td>
                                <asp:Label ID="lblopendate" runat="server" meta:resourcekey="Opendate" Text="" CssClass="lblForm"
                                    Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="lblOpendateText" runat="server" Text="Label" CssClass="NormalText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <%--  <td>
                                        <asp:Label ID="lblClient" runat="server" meta:resourcekey="AssignedLawyer" Text="" CssClass="lblForm"></asp:Label>
                                    </td>--%>
                            <td>
                                <asp:Label ID="lblAssignedLawyer" runat="server" meta:resourcekey="AssignedLawyer"
                                    Text="" CssClass="lblForm" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="ddlAssignedLawyer" runat="server" Text="Label" CssClass="NormalText"></asp:Label>
                                <%--<asp:DropDownList ID="ddlAssignedLawyer" runat="server" DataTextField="UserName"
                                            DataValueField="Employee_Id" CssClass="NormalText">
                                        </asp:DropDownList>--%>
                            </td>
                            <td>
                                <asp:Label ID="lblResponsibleLawyer" runat="server" meta:resourcekey="Responsibalelawyer"
                                    Text="" CssClass="lblForm" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="ddlResponsiblelawyer" runat="server" Text="Label" CssClass="NormalText"></asp:Label>
                                <%--  <asp:DropDownList ID="ddlResponsiblelawyer" runat="server" DataTextField="UserName"
                                            DataValueField="Employee_Id" CssClass="NormalText">
                                        </asp:DropDownList>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMatterType" runat="server" meta:resourcekey="MatterType" Text=""
                                    CssClass="lblForm" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="ddlMatterType" runat="server" Text="Label" CssClass="NormalText"></asp:Label>
                                <%--  <asp:DropDownList ID="ddlMatterType" runat="server" DataTextField="Matter_Type_Desc"
                                            DataValueField="Matter_Type_Id" CssClass="NormalText">
                                        </asp:DropDownList>--%>
                            </td>
                            <td>
                                <asp:Label ID="lblofficeid" runat="server" meta:resourcekey="OfficeId" Text="" CssClass="lblForm"
                                    Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td>
                                <asp:Label ID="ddlOffice" runat="server"  CssClass="NormalText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblDiscription" runat="server" meta:resourcekey="Discription" Text=""
                                    CssClass="lblForm" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtMatterDiscription" runat="server" TextMode="MultiLine" Rows="4"
                                    CssClass="NormalText" Columns="40"></asp:TextBox>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblOppnents" runat="server" meta:resourcekey="Oppnents" Text="" CssClass="lblForm"
                                    Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 20px">
                            </td>
                            <td valign="top">
                                <asp:GridView ID="Dtgopponent" runat="server" Width="100%" CssClass="grid-view"
                                    ShowHeader="false" AutoGenerateColumns="False" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="Company_Name" SortExpression="PL" meta:resourcekey="HCaseNumber" />
                                    </Columns>
                                    <RowStyle CssClass="RowStyle" Height="20px" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <PagerStyle CssClass="PagerStyle" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                               <cc1:ScatterChart ID="CaseChart" runat="server" Height="250px" />
                               <br />
                               <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="GridMatterCases" runat="server" Width="100%" CssClass="grid-view"
                                    OnRowCreated="gvHover_RowCreated" AutoGenerateColumns="false" GridLines="Both"
                                    OnRowDataBound="GridMatterCases_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    DataKeyNames="Matter_Id">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select" Visible="false" />
                                        <asp:BoundField DataField="Matter_number" HeaderText="Matter #" SortExpression="CL"
                                            meta:resourcekey="HMatter" Visible="false" />
                                        <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="HMatter"
                                            Visible="false" />
                                        <asp:TemplateField HeaderText="Matter#" meta:resourcekey="Hstage">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="MatterNo" runat="server" Text='<%# Eval("CURRENT_STAGE") %>' NavigateUrl='<%# "~/Matter/Stage/StageDetails.aspx?Matter_Id="+Server.UrlEncode(Eval("Matter_Id").ToString())%>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CURRENT_STAGE" HeaderText="Current Stage" SortExpression="SL"
                                            meta:resourcekey="Hstage" Visible="false" />
                                        <asp:BoundField DataField="Case_ID" HeaderText="Case Number" SortExpression="PL" meta:resourcekey="HCaseNumber" Visible="false" />
                                         <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HCaseNumber">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="MatterNo" runat="server" Text='<%# Eval("NUMBER") %>' NavigateUrl='<%# "~/Matter/Cases/CasesDetails.aspx?Case_ID="+Server.UrlEncode(Eval("Case_ID").ToString())%>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="CO" meta:resourcekey="HStatus" />
                                          <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HLastHdate">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="MatterNo" runat="server" Text='<%# Eval("NEXT_HEARING") %>' NavigateUrl='<%# "~/Matter/Hearings/Hearings.aspx?Hearing_ID="+Server.UrlEncode(Eval("Hearing_ID").ToString())%>' DataFormatString="{0:dd-MMM-yyy}"></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Hearing_ID" HeaderText="Next Hearing Date" SortExpression="CO"
                                            meta:resourcekey="HLastHdate" DataFormatString="{0:dd-MMM-yyy}"  Visible="false"/>
                                        <asp:BoundField DataField="HERAING_DESP" HeaderText="Hearing Description" SortExpression="CO"
                                            meta:resourcekey="HLastDescision" />
                                         <asp:BoundField DataField="staus_desc" HeaderText="Hearing Description" SortExpression="staus_desc"
                                            meta:resourcekey="HeStatus" />
                                    </Columns>
                                   
                                    <SelectedRowStyle BackColor=" #90AA1E" ForeColor="White" Font-Bold="false" />
                                   
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <PagerStyle CssClass="PagerStyle" />
                                </asp:GridView>
                                <asp:Label runat="server" ID="lbl" Text="" ForeColor="White" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:PostBackTrigger  ControlID="ImageSave"/>
                            <asp:PostBackTrigger  />
                            <asp:PostBackTrigger  />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content' style="width:612px;margin-top:2px">
            <h2>
                <asp:Label ID="lbladdMater" runat="server" meta:resourcekey="AddMatter" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddMatterPanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="form" style="width: 100%" border="0">
                            <tbody>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblmatter" runat="server" meta:resourcekey="Matter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:DropDownList ID="ddlMatterNumber" runat="server" DataTextField="Matter_number"
                                            DataValueField="Matter_number" CssClass="NormalText" AutoPostBack="true" OnSelectedIndexChanged="GetMatterDetails">
                                        </asp:DropDownList>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="client" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblcleintdata" runat="server" meta:resourcekey="client" Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblResponsibalelawyer" runat="server" meta:resourcekey="ResponsibleLawyer"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblResponsibalelawyerdata" runat="server" meta:resourcekey="ResponsibleLawyer"
                                            Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblAssignedLawyerMatter" runat="server" meta:resourcekey="AssignedLawyer"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAssignedLawyerdata" runat="server" meta:resourcekey="AssignedLawyer"
                                            Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblMatterTye" runat="server" meta:resourcekey="MatterType" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblmattertypedata" runat="server" meta:resourcekey="MatterType" Text=""
                                            CssClass="NormalText"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblOpenDdate" runat="server" meta:resourcekey="DateOpen" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="txtOpenDate" runat="server" Text="22-JAN-2013"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label2" runat="server" meta:resourcekey="office" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top" colspan="4">
                                        <asp:DropDownList ID="ddlOfficeName" runat="server" DataTextField="offc_desc" DataValueField="Office_ID"
                                            CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="Label3" runat="server" meta:resourcekey="Discription" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top" colspan="4">
                                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="3" Columns="40"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnAddMatter" Text="Add Matter" ValidationGroup="AddMatter"
                                            CausesValidation="true" OnClick="btnAddMatter_Click"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMatterNumber" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content1' style="width:575px;margin-top:2px">
            <h2>
                <asp:Label ID="lblclosematter" runat="server" meta:resourcekey="closeMatter" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="closeMatterPanel" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblcMatter" runat="server" meta:resourcekey="Matter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCloseMatterNo" runat="server" Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCclient" runat="server" meta:resourcekey="client" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblcclientdata" runat="server" meta:resourcekey="client" Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblCresonsiable" runat="server" meta:resourcekey="ResponsibleLawyer"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCresonsiabledata" runat="server" meta:resourcekey="ResponsibleLawyer"
                                            Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCAssignned" runat="server" meta:resourcekey="AssignedLawyer" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCAssignneddata" runat="server" meta:resourcekey="AssignedLawyer"
                                            Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblCMattertype" runat="server" meta:resourcekey="MatterType" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCMattertypedata" runat="server" meta:resourcekey="MatterType" Text=""
                                            CssClass="NormalText"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCdateopen" runat="server" meta:resourcekey="DateOpen" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCdateopendata" runat="server" Text="22-JAN-2013" CssClass="NormalText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblCMatterstatus" runat="server" meta:resourcekey="Status" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:DropDownList ID="ddlcMatterStatusdata" runat="server" DataTextField="Staus_Desc"
                                            CssClass="NormalText" DataValueField="Satus_id">
                                        </asp:DropDownList>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCoffice" runat="server" meta:resourcekey="office" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblCofficedata" runat="server" Text="Abu Dhabi" CssClass="NormalText"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btncloseMatter" Text="Close Matter" CausesValidation="true"
                                            OnClick="btnCloseMatter_Click"></asp:Button>
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
        <div class="box round first fullpage" id='inline_content2' style="width:575px;margin-top:2px">
            <h2>
                <asp:Label ID="lblMangeFall" runat="server" meta:resourcekey="Managefallower" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="FallowerPanel" runat="server">
                    <ContentTemplate>
                        <table class="form" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblFallowerMatter" runat="server" meta:resourcekey="Matter" Text=""
                                        CssClass="HeaderText"></asp:Label>
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    <asp:Label ID="lblFallowerMatterno" runat="server" AutoPostBack="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFallowerEmp" runat="server" meta:resourcekey="FallowerEmp" Text=""
                                        CssClass="HeaderText"></asp:Label>
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td style="width: 30%">
                                    <asp:DropDownList ID="ddlemp" runat="server" DataTextField="UserName" DataValueField="Employee_Id"
                                        CssClass="NormalText">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Button class="btn" runat="server" ID="btn" Text="Add Fallower" CausesValidation="true"
                                        OnClick="AddFallower_Click"></asp:Button>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" align="center">
                                    <asp:GridView ID="DtgFallower" runat="server" Width="100%" CssClass="GridViewStyle"
                                        GridLines="Both" AllowPaging="true" PageSize="10" AutoGenerateColumns="False"
                                        DataKeyNames="FallowerID" AutoGenerateDeleteButton="true" OnRowDeleting="Delete_Fallower">
                                        <Columns>
                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                            <asp:BoundField DataField="Matter_Id" SortExpression="Matter_Id" meta:resourcekey="HMatterNo" />
                                            <asp:BoundField DataField="Employee_Id" SortExpression="Employee_Id" meta:resourcekey="HEmpname" />
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
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $("#ctl00_ContentPlaceHolder1_ddlMatterNumber").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlOfficeName").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcMatterStatusdata").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlemp").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlOfficeID").chosen();
            $("#colorbox, #cboxOverlay").appendTo('form:first');
            $(".inline").colorbox({ inline: true, width: "53%", height: "60%" });
            $(".inline1").colorbox({ inline: true, width: "50%", height: "60%" });
            $(".inline2").colorbox({ inline: true, width: "50%", height: "60%" });

        }
        
    </script>
</asp:Content>
