<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="LawyerDashBoard.aspx.cs" Inherits="Matter_Dashboards_LawyerDashBoard" %>

<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
       <div class="box round first grid" style="width: 950px; margin-top: 12px;">
        <h2>
            <asp:Label ID="lblLawyerDashboard" runat="server" meta:resourcekey="LawyerDashboard"
                Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <asp:Panel ID="CreatePleadings" runat="server" Visible="false">
                            <a class='inline1' href="#inline_content1">
                                <asp:Label ID="lblMAddHearings" runat="server" meta:resourcekey="CreatePleadings"
                                    Text=""></asp:Label></a>
                        </asp:Panel>
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
                                            <td colspan="3">
                                                <table style="width: 100%" cellpadding="0" cellspacing="0">
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
                                                            <asp:Button class="btn" runat="server" ID="btnsearch" Text="Search" 
                                                                OnClick="btnsearch_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="3" class="box round first grid">
                                                <h2>
                                                    <asp:Label ID="lblMyMatter" runat="server" meta:resourcekey="lblMyMatter" Text=""></asp:Label></h2>
                                                <asp:LinkButton ID="lnlshowAllMatter" runat="server" meta:resourcekey="ShowAll" OnClick="lnlshowAllMatter_Click"></asp:LinkButton>
                                                |
                                                <asp:LinkButton ID="lnlprintCaseMatter" runat="server" meta:resourcekey="PrintCase"
                                                    OnClick="lnlprintCaseMatter_Click"></asp:LinkButton>
                                                <div>
                                                    <asp:GridView ID="MatterGrid" runat="server" Width="100%" CssClass="grid-view" OnRowCreated="gvHover_RowCreated"
                                                        OnPageIndexChanging="MatterGrid_PageIndexChanging" AutoGenerateColumns="false"
                                                        OnRowDataBound="DtgViewStage_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                                        DataKeyNames="Matter_Id" GridLines="Both" AllowPaging="true" PageSize="15">
                                                        <Columns>
                                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                                            <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="HMatter"
                                                                Visible="false" />
                                                            <asp:BoundField DataField="Matter_number" HeaderText="Matter#" SortExpression="Matter_number"
                                                                meta:resourcekey="HMatter" />
                                                            <asp:BoundField DataField="stage_type_desc" HeaderText="Current Stage" SortExpression="CO"
                                                                meta:resourcekey="Hstage" />
                                                            <asp:BoundField DataField="Case_number" HeaderText="Matter#" SortExpression="Case_number"
                                                                meta:resourcekey="HCase" />
                                                            <asp:BoundField DataField="Company_Name" HeaderText="Client" SortExpression="Company_Name"
                                                                meta:resourcekey="Hclient" />
                                                            <asp:BoundField DataField="Hearing_Date" HeaderText="Supervising Lawyer" SortExpression="Hearing_Date"
                                                                meta:resourcekey="HHearingDate" />
                                                            <asp:BoundField DataField="Hearing_Notes" HeaderText="Assigned lawyer" SortExpression="Hearing_Notes"
                                                                meta:resourcekey="HLastDecision" />
                                                        </Columns>
                                                        
                                                        <SelectedRowStyle BackColor=" #90AA1E" ForeColor="White" Font-Bold="false" />
                                                        
                                                        <%--<HeaderStyle CssClass="HeaderStyle" />--%>
                                                        <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                        NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                                    </asp:GridView>
                                                    <asp:Label ID="lbl" runat="server" Text="" Visible="false"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 49%" valign="top" class="box round first grid">
                                                <h2>
                                                    <asp:Label ID="lblUpcomingGrid" runat="server" meta:resourcekey="lblUpcomingGrid"
                                                        Text=""></asp:Label></h2>
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
                                                            <asp:BoundField DataField="Matter_ID" HeaderText="Matter#" SortExpression="Matter_number" meta:resourcekey="HMatter" Visible="false" />
                                                            <asp:BoundField DataField="Hearing_ID" HeaderText="Case #" SortExpression="Case_number"  meta:resourcekey="HCase" Visible="false" />
                                                            <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HMatter">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkmatter" runat="server" Text='<%# Eval("Matter_number") %>' NavigateUrl='<%# "~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id="+Server.UrlEncode(Eval("Matter_Id").ToString())%>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HCase">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkcae" runat="server" Text='<%# Eval("Case_number") %>' NavigateUrl='<%# "~/Matter/Cases/CasesDetails.aspx?Case_ID="+Server.UrlEncode(Eval("Case_ID").ToString())%>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HHearingDateNext">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkhearings" runat="server"  NavigateUrl='<%# "~/Matter/Hearings/Hearings.aspx?Hearing_ID="+Server.UrlEncode(Eval("Hearing_ID").ToString())%>'
                                                                        Text='<%#DataBinder.Eval(Container.DataItem,"Hearing_Date","{0:dd-MMM-yyyy}") %>' ></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:BoundField DataField="Pleading_status_desc_en" HeaderText="Pleading" SortExpression="Pleading_status_desc_en"
                                                                meta:resourcekey="HPleadings" />
                                                            <asp:BoundField DataField="Hearings_Notes" HeaderText="Hearing Notes" SortExpression="Hearings_Notes"
                                                                meta:resourcekey="HNote" />
                                                        </Columns>
                                                        <SelectedRowStyle BackColor="#90AA1E" ForeColor="White" Font-Bold="false" />
                                                        <%--<HeaderStyle CssClass="HeaderStyle" />--%>
                                                        <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                        NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                                    </asp:GridView>
                                                    <asp:Label ID="lblcase" runat="server" Text="" Visible="false"></asp:Label>
                                                </div>
                                            </td>
                                            <td style="width: 1%" valign="top">
                                            </td>
                                            <td style="width: 50%" valign="top" class="box round first grid">
                                                <h2>
                                                    <asp:Label ID="lblPleadingGrid" runat="server" meta:resourcekey="lblPleadingGrid"
                                                        Text=""></asp:Label></h2>
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
                                                        <SelectedRowStyle BackColor="#90AA1E" ForeColor="White" Font-Bold="false" />
                                                        <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 49%" valign="top" class="box round first grid">
                                                <h2>
                                                    <asp:Label ID="lblUcomingAppeals" runat="server" meta:resourcekey="lblUcomingAppeals"
                                                        Text=""></asp:Label></h2>
                                                <asp:LinkButton ID="lnkupcomingAppeals" runat="server" meta:resourcekey="ShowAll"
                                                    OnClick="lnkupcomingAppeals_Click"></asp:LinkButton>
                                                |
                                                <asp:LinkButton ID="lnkupcomingAppealsCaseList" runat="server" meta:resourcekey="PrintCase"></asp:LinkButton>
                                                <div>
                                                    <asp:GridView ID="dtgAppeals_Cassation" runat="server" Width="100%" CssClass="grid-view"
                                                        OnRowCreated="dtgAppeals_Cassation_RowCreated" OnPageIndexChanging="dtgAppeals_Cassation_PageIndexChanging"
                                                        AutoGenerateColumns="false" OnRowDataBound="dtgAppeals_Cassation_RowDataBound"
                                                        OnSelectedIndexChanged="dtgAppeals_Cassation_SelectedIndexChanged" DataKeyNames="Matter_ID"
                                                        GridLines="Both" AllowPaging="true" PageSize="15">
                                                        <Columns>
                                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                                            <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="HMatter"
                                                                Visible="false" />
                                                            <asp:BoundField DataField="Matter_number" HeaderText="Matter#" SortExpression="Matter_number"
                                                                meta:resourcekey="HMatter" />
                                                            <asp:BoundField DataField="Case_number" HeaderText="Matter#" SortExpression="Case_number"
                                                                meta:resourcekey="HCase" />
                                                            <asp:BoundField DataField="stage_type_desc" HeaderText="Current Stage" SortExpression="CO"
                                                                meta:resourcekey="Hstage" />
                                                            <asp:BoundField DataField="Last_date" HeaderText="Supervising Lawyer" SortExpression="Last_date"
                                                                meta:resourcekey="HLastDateFiling" DataFormatString="{0:dd-MMM-yyyy}" />
                                                        </Columns>
                                                        <SelectedRowStyle BackColor="#90AA1E" ForeColor="White" Font-Bold="false" />
                                                        <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                            <td style="width: 1%" valign="top">
                                            </td>
                                            <td style="width: 50%" valign="top" class="box round first grid">
                                                <h2>
                                                    <asp:Label ID="lblNotificationandAlert" runat="server" meta:resourcekey="lblNotificationandAlert"
                                                        Text=""></asp:Label></h2>
                                                <asp:LinkButton ID="lnkalerts" runat="server" meta:resourcekey="ShowAll" OnClick="lnkalerts_Click"></asp:LinkButton>
                                                <div>
                                                    <asp:GridView ID="dtgAlerts" runat="server" Width="100%" CssClass="grid-view" OnRowCreated="dtgAlerts_RowCreated"
                                                        OnPageIndexChanging="dtgAlerts_PageIndexChanging" AutoGenerateColumns="false"
                                                        OnRowDataBound="dtgAlerts_RowDataBound" OnSelectedIndexChanged="dtgAlerts_SelectedIndexChanged"
                                                        DataKeyNames="Matter_ID" GridLines="Both" AllowPaging="true" PageSize="15">
                                                        <Columns>
                                                            <asp:ButtonField CommandName="Select" Visible="false" />
                                                            <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="HMatter"
                                                                Visible="false" />
                                                            <asp:BoundField DataField="Matter_number" HeaderText="Matter#" SortExpression="Matter_number"
                                                                meta:resourcekey="HMatter" />
                                                            <asp:BoundField DataField="Alert_Type_En" HeaderText="Alert Type" SortExpression="Alert_Type_En"
                                                                meta:resourcekey="HAlertType" />
                                                            <asp:BoundField DataField="Due_date" HeaderText="Due Date" SortExpression="Due_date"
                                                                meta:resourcekey="HDuedate" DataFormatString="{0:dd-MMM-yyyy}" />
                                                            <asp:BoundField DataField="Discription" HeaderText="Discription" SortExpression="Discription"
                                                                meta:resourcekey="HDiscription" />
                                                        </Columns>
                                                       
                                                        <SelectedRowStyle BackColor="#90AA1E" ForeColor="White" Font-Bold="false" />
                                                       
                                                        <%--<HeaderStyle CssClass="HeaderStyle" />--%>
                                                        <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                        NextPageText="Next" PreviousPageText="Previous" />--%>
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
                    <%--<asp:AsyncPostBackTrigger ControlID="lnkupcomingAppeals" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lnkUnprepared" EventName="Click" />
                     <asp:AsyncPostBackTrigger ControlID="lnlHearingShowAll" EventName="Click" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content1' style="width: 640px">
            <h2>
                <asp:Label ID="Createpladings" runat="server" Text="" meta:resourcekey="Createpladings"></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddPleadingsPanel" runat="server">
                    <ContentTemplate>
                        <table class="form" style="width: 75%">
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
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $("#ctl00_ContentPlaceHolder1_ddlStatus").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlclient").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcase").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlMatter").chosen();
            $("#colorbox, #cboxOverlay").appendTo('form:first');
            $("#ctl00_ContentPlaceHolder1_ddlpladingsst").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlreviewby").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlplpreaparedby").chosen();
            $(".inline1").colorbox({ inline: true, width: "55%", height: "60%" });
        }
        
    </script>
</asp:Content>
