<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="AlertsPage.aspx.cs" Inherits="Matter_Alerts_AlertsPage" %>

<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblAllMatter" runat="server" meta:resourcekey="AlertsNotifications"
                Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="pnladdalert" Visible="false">
                            <a class='inline' href="#inline_content">
                                <asp:Label ID="lblAddcaseh" runat="server" meta:resourcekey="Addalert" Text=""></asp:Label></a>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel runat="server" ID="pnlresendalert" Visible="false">
                            <a class='inline1' href="#inline_content1">
                                <asp:Label ID="lblalert" runat="server" meta:resourcekey="ResendAlerts" Text=""></asp:Label></a>
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
                                    <asp:GridView ID="dtgAlertGrid" runat="server" Width="100%" CssClass="grid-view"
                                        OnRowCreated="gvHover_RowCreated" AutoGenerateColumns="false" DataKeyNames="Alert_ID"
                                        AllowPaging="true" OnPageIndexChanging="dtgAlertGrid_PageIndexChanging" GridLines="Both"
                                        OnRowDataBound="dtgAlertGrid_RowDataBound" OnSelectedIndexChanged="dtgAlertGrid_SelectedIndexChanged"
                                        PageSize="10">
                                        <Columns>
                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                            <asp:BoundField DataField="Matter_number" HeaderText="Matter_number" SortExpression="Matter_number"
                                                meta:resourcekey="Matterno" Visible="true" />
                                            <asp:BoundField DataField="Alert_Type_En" HeaderText="Alert_Type_En" SortExpression="Alert_Type_En"
                                                meta:resourcekey="AlertType" Visible="true" />
                                            <asp:BoundField DataField="Due_date" HeaderText="Due Date" SortExpression="Due_date"
                                                meta:resourcekey="duedate" DataFormatString="{0:dd-MMM-yyy}" />
                                            <asp:BoundField DataField="ConcernEmp" HeaderText="ConcernEmp" SortExpression="ConcernEmp"
                                                meta:resourcekey="ConcernEmp" />
                                            <asp:BoundField DataField="createdby" HeaderText="createdby" SortExpression="createdby"
                                                meta:resourcekey="Createdby" />
                                            <asp:BoundField DataField="Date_Created" HeaderText="Created Date" SortExpression="Date_Created"
                                                meta:resourcekey="Createddate" DataFormatString="{0:dd-MMM-yyy}" />
                                            <asp:BoundField DataField="Discription" SortExpression="Discription" meta:resourcekey="discription" />
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
                                                <asp:Label ID="lblmatter" runat="server" meta:resourcekey="Matter" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblalerttype" runat="server" meta:resourcekey="Alerttye" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblduedate" runat="server" meta:resourcekey="ddate" Text=""></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblcreatdate" runat="server" meta:resourcekey="cdate" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtmatterno" runat="server" CssClass="NormalText"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlalerttype" runat="server" DataTextField="Alert_Type_En"
                                                    AppendDataBoundItems="false" data-placeholder="Select Alert" CssClass="NormalText"
                                                    DataValueField="Alert_Type_ID" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtduedate" runat="server" CssClass="NormalText"></asp:TextBox>
                                                <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtduedate"
                                                    PopupButtonID="txtduedate" Format="dd-MMM-yyyy" Enabled="True">
                                                </AjaxControlToolkit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcreatedate" runat="server" CssClass="NormalText"></asp:TextBox>
                                                <AjaxControlToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtcreatedate"
                                                    PopupButtonID="txtcreatedate" Format="dd-MMM-yyyy" Enabled="True">
                                                </AjaxControlToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblconcernemp" runat="server" meta:resourcekey="Cemp" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcreatedby" runat="server" meta:resourcekey="Cby" Text=""></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lbldscription" runat="server" meta:resourcekey="Discrip" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:DropDownList ID="ddlconcern" runat="server" DataTextField="UserName" AppendDataBoundItems="false"
                                                    data-placeholder="Select Employee" CssClass="NormalText" DataValueField="Employee_Id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="ddlcreated" runat="server" DataTextField="UserName" AppendDataBoundItems="false"
                                                    data-placeholder="Select Employee" CssClass="NormalText" DataValueField="Employee_Id"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtdicription" runat="server" CssClass="NormalText" TextMode="MultiLine"
                                                    Rows="3" Columns="66"></asp:TextBox>
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
                    <asp:AsyncPostBackTrigger ControlID="dtgAlertGrid" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content' style="width: 600px">
            <h2>
                <asp:Label ID="lblAddAlert" runat="server" meta:resourcekey="Addalert" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel runat="server" ID="AddCase">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMatterNo" runat="server" meta:resourcekey="CMatter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="lblalertMatterno" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblatype" runat="server" meta:resourcekey="Alerttye" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="AddlAlerttype" runat="server" DataTextField="Alert_Type_En"
                                            data-placeholder="Select Alert" CssClass="NormalText" DataValueField="Alert_Type_ID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Aduedate" runat="server" meta:resourcekey="ddate" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAduedate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtAduedate"
                                            PopupButtonID="txtAduedate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="AddAlert"
                                            ErrorMessage="*" ControlToValidate="txtAduedate"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Acreateddate" runat="server" meta:resourcekey="Cdate" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAcdate" runat="server" Text="" CssClass="NormalText"></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtAcdate"
                                            PopupButtonID="txtAcdate" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="AddAlert"
                                            ErrorMessage="*" ControlToValidate="txtAcdate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="AconcernEmp" runat="server" meta:resourcekey="Cemp" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="AddlConcernEmp" runat="server" DataTextField="UserName" data-placeholder="Select Employee"
                                            CssClass="NormalText" DataValueField="Employee_Id">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Acreateby" runat="server" meta:resourcekey="Cby" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="AddlCreatedEmp" runat="server" DataTextField="UserName" data-placeholder="Select Employee"
                                            CssClass="NormalText" DataValueField="Employee_Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblCaseDiscription" runat="server" meta:resourcekey="Discrip" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtAdiscription" runat="server" Text="" TextMode="MultiLine" Rows="5"
                                            Columns="53"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqDiscription" runat="server" ValidationGroup="AddAlert"
                                            ErrorMessage="*" ControlToValidate="txtAdiscription"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnCase" Text="Add Alert" ValidationGroup="AddAlert"
                                            CausesValidation="true" OnClick="Addalert_Click"></asp:Button>
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
        <div class="box round first fullpage" id='inline_content1' style="width:600px;margin-top:30px">
            <h2>
                <asp:Label ID="lblRealert" runat="server" meta:resourcekey="ResendAlert" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblresendMatter" runat="server" meta:resourcekey="CMatter" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="lblresendMatterno" runat="server" Text="000-000-0000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnresend" Text="Resend Alert" CausesValidation="true"
                                            OnClick="Resendalert_Click"></asp:Button>
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
            $("#ctl00_ContentPlaceHolder1_ddlconcern").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcreated").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlalerttype").chosen();

            $("#ctl00_ContentPlaceHolder1_AddlConcernEmp").chosen();
            $("#ctl00_ContentPlaceHolder1_AddlCreatedEmp").chosen();
            $("#ctl00_ContentPlaceHolder1_AddlAlerttype").chosen();

            //without this PainFUll
            $("#colorbox, #cboxOverlay").appendTo('form:first');

            $(".inline").colorbox({ inline: true, width: "52%", height: "70%" });
            $(".inline1").colorbox({ inline: true, width: "52%", height: "70%" });

            //event.preventDefault();
        }
        
    </script>
</asp:Content>
