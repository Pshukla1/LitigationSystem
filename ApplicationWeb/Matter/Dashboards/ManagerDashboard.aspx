<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ManagerDashboard.aspx.cs" Inherits="Matter_Dashboards_ManagerDashboard" %>

<%@ Register Assembly="Highchart" Namespace="Highchart.UI" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Assembly="Highchart" Namespace="Highchart" TagPrefix="Highchart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../js/grid.js" type="text/javascript"></script>
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <%--<link href="../../css/grid.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblLawyerDashboard" runat="server" meta:resourcekey="Managerdashboard"
                Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <%--<asp:Panel ID="CreatePleadings" runat="server" Visible="false">
                            <a class='inline1' href="#inline_content1">
                                <asp:Label ID="lblCreatePladins" runat="server" meta:resourcekey="CreatePleadings"
                                    Text=""></asp:Label></a>
                        </asp:Panel>--%>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 1%; margin-right: 1%; margin-top: 0%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                <ContentTemplate>
                    <div>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 23%">
                                                            <asp:DropDownList ID="ddlMatter" runat="server" DataTextField="Matter_number" AppendDataBoundItems="false"
                                                                data-placeholder="Select Matter" CssClass="NormalText" DataValueField="Matter_ID">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 23%">
                                                            <asp:DropDownList ID="ddlcase" runat="server" DataTextField="Case_number" data-placeholder="Select Case"
                                                                CssClass="NormalText" DataValueField="Case_ID">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 23%">
                                                            <asp:DropDownList ID="ddlclient" runat="server" DataTextField="Company_Name" data-placeholder="Select Client"
                                                                DataValueField="Party_ID" CssClass="NormalText">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 23%">
                                                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" data-placeholder="Select Status"
                                                                CssClass="NormalText" DataTextField="Staus_Desc" DataValueField="Satus_id">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 8%">
                                                            <asp:Button class="btn" runat="server" ID="btnsearch" Text="Search" CausesValidation="true"
                                                                OnClick="btnsearch_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50%" valign="top" class="box round first grid" align="center">
                                                <h2>
                                                    <asp:Label ID="lblUpcomingGrid" runat="server" meta:resourcekey="Stats" Text=""></asp:Label></h2>
                                                <br />
                                                <cc1:ColumnChart ID="Statices" runat="server" Height="200px" />
                                            </td>
                                            <td style="width: 50%" valign="top" class="box round first grid" align="center">
                                                <h2>
                                                    <asp:Label ID="lblPleadingGrid" runat="server" meta:resourcekey="Case_Court" Text=""></asp:Label></h2>
                                                <br />
                                                <cc1:ColumnChart ID="ChartByCase" runat="server" Height="200px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2" class="box round first grid" align="center">
                                                <h2>
                                                    <asp:Label ID="lblMyMatter" runat="server" meta:resourcekey="Emp_Matter" Text=""></asp:Label></h2>
                                                <br />
                                                <cc1:ColumnChart ID="ChartByEmployee" runat="server" Height="200px" />
                                                <div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50%" valign="top" class="box round first grid">
                                                <h2>
                                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="UcomingHearings" Text=""></asp:Label></h2>
                                                <asp:LinkButton ID="lnlHearingShowAll" runat="server" meta:resourcekey="ShowAll"
                                                    OnClick="lnlHearingShowAll_Click"></asp:LinkButton>
                                                |
                                                <asp:LinkButton ID="lnkhearingPrint" runat="server" meta:resourcekey="PrintList"></asp:LinkButton>
                                                <div>
                                                    <asp:GridView ID="DtgUpcomingHearings" runat="server" Width="100%" CssClass="grid-view"
                                                        OnRowCreated="DtgUpcomingHearings_RowCreated" OnPageIndexChanging="DtgUpcomingHearings_PageIndexChanging"
                                                        AutoGenerateColumns="false" OnRowDataBound="DtgUpcomingHearings_RowDataBound"
                                                        OnSelectedIndexChanged="DtgUpcomingHearings_SelectedIndexChanged" DataKeyNames="Case_ID"
                                                        GridLines="Both" AllowPaging="true" PageSize="15">
                                                        <Columns>
                                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                                            <asp:BoundField DataField="Case_ID" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="Case_ID"
                                                                Visible="false" />
                                                            <asp:BoundField DataField="Matter_ID" HeaderText="Matter#" SortExpression="Matter_number"
                                                                meta:resourcekey="HMatter" Visible="false" />
                                                            <asp:BoundField DataField="Hearing_ID" HeaderText="Case #" SortExpression="Case_number"
                                                                meta:resourcekey="HCase" Visible="false" />
                                                            <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HMatter">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkmatter" runat="server" Text='<%# Eval("Matter_number") %>'
                                                                        NavigateUrl='<%# "~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id="+Server.UrlEncode(Eval("Matter_Id").ToString())%>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HCase">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkcase" runat="server" Text='<%# Eval("Case_number") %>' NavigateUrl='<%# "~/Matter/Cases/CasesDetails.aspx?Case_ID="+Server.UrlEncode(Eval("Case_ID").ToString())%>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HHearingDateNext">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkhearings" runat="server" NavigateUrl='<%# "~/Matter/Hearings/Hearings.aspx?Hearing_ID="+Server.UrlEncode(Eval("Hearing_ID").ToString())%>'
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,"Hearing_Date","{0:dd-MMM-yyyy}") %>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Pleading_status_desc_en" HeaderText="Pleading" SortExpression="Pleading_status_desc_en"
                                                                meta:resourcekey="HPleadings" />
                                                            <asp:BoundField DataField="Hearings_Notes" HeaderText="Hearing Notes" SortExpression="Hearings_Notes"
                                                                meta:resourcekey="HNote" />
                                                        </Columns>
                                                       
                                                      <SelectedRowStyle BackColor="#90AA1E" ForeColor="White" Font-Bold="false" />
                                                       <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                                    </asp:GridView>
                                                    <asp:Label ID="lbl" runat="server" Text="" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblcase" runat="server" Text="" Visible="false"></asp:Label>
                                                </div>
                                            </td>
                                            <td style="width: 50%" valign="top" class="box round first grid">
                                                <h2>
                                                    <asp:Label ID="Label2" runat="server" meta:resourcekey="Unpreparedpleadings" Text=""></asp:Label></h2>
                                                <asp:LinkButton ID="lnkUnprepared" runat="server" meta:resourcekey="ShowAll" OnClick="lnkUnprepared_Click"></asp:LinkButton>
                                                <div>
                                                    <asp:GridView ID="dtgUnpreparedPleadings" runat="server" Width="100%" CssClass="grid-view"
                                                        OnRowCreated="dtgUnpreparedPleadings_RowCreated" OnPageIndexChanging="dtgUnpreparedPleadings_PageIndexChanging"
                                                        AutoGenerateColumns="false" OnRowDataBound="dtgUnpreparedPleadings_RowDataBound"
                                                        OnSelectedIndexChanged="dtgUnpreparedPleadings_SelectedIndexChanged" DataKeyNames="Case_ID"
                                                        GridLines="Both" AllowPaging="true" PageSize="15">
                                                        <Columns>
                                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                                            <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="HMatter"
                                                                Visible="false" />
                                                            <asp:BoundField DataField="Matter_number" HeaderText="Matter#" SortExpression="Matter_number"
                                                                meta:resourcekey="HMatter" />
                                                            <asp:BoundField DataField="Case_number" HeaderText="Case #" SortExpression="Case_number"
                                                                meta:resourcekey="HCase" />
                                                            <asp:BoundField DataField="Hearing_Date" HeaderText="Hearing Date" SortExpression="Hearing_Date"
                                                                meta:resourcekey="HHearingDateNext" DataFormatString="{0:dd-MMM-yyyy}" />
                                                            <asp:BoundField DataField="Last_date" HeaderText="Last Date For Submission" SortExpression="Last_date"
                                                                meta:resourcekey="HLastDate" DataFormatString="{0:dd-MMM-yyyy}" />
                                                        </Columns>
                                                        
                                                         <SelectedRowStyle BackColor=" #90AA1E" ForeColor="White" Font-Bold="false" />
                                                         <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%-- <asp:PostBackTrigger  ControlID="ImageSave"/>--%>
                    <asp:AsyncPostBackTrigger ControlID="DtgUpcomingHearings" EventName="SelectedIndexChanged" />
                    <%-- <asp:PostBackTrigger ControlID="ddlSuperWiseSerach"  />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $("#ctl00_ContentPlaceHolder1_ddlStatus").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlclient").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcase").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlMatter").chosen();
            $("#colorbox, #cboxOverlay").appendTo('form:first');

        }
        
    </script>
</asp:Content>
