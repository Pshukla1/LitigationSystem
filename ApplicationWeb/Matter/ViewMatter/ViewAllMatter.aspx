<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewAllMatter.aspx.cs" Inherits="Matter_ViewMatter_ViewAllMatter" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/grid.css" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblAllMatter" runat="server" meta:resourcekey="MAllMAtter" Text=""></asp:Label></h2>
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
        <div style="margin-left: 1%; margin-right: 1%; margin-top: 0%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                <ContentTemplate>
                    <div>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center">
                                                <div id="example_filter">
                                                    <label>
                                                        <asp:Label ID="lblSearch" runat="server" meta:resourcekey="MSearch" Text=""></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtserach" OnTextChanged="GridSerach_data" AutoPostBack="true"></asp:TextBox></label></div>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblMatterType" runat="server" meta:resourcekey="SuperwiseLawyer" Text=""></asp:Label>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblAssignedlawyer" runat="server" meta:resourcekey="AssignedLawyer"
                                                                Text=""></asp:Label>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="Label1" runat="server" meta:resourcekey="MatterType" Text=""></asp:Label>
                                                        </td>
                                                        <%--  <td style="width: 20%">
                                                            <asp:Label ID="lblstage" runat="server" meta:resourcekey="Stage" Text=""></asp:Label>
                                                        </td>--%>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="lblStatus" runat="server" meta:resourcekey="Status" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%">
                                                            <asp:DropDownList ID="ddlSuperWiseSerach" runat="server" DataTextField="UserName"
                                                                AppendDataBoundItems="false" data-placeholder="Supervising Lawyer" CssClass="NormalText"
                                                                DataValueField="Employee_Id" AutoPostBack="true" OnSelectedIndexChanged="ddlSuperWiseSerach_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:DropDownList ID="ddlAssignedSearch" runat="server" DataTextField="UserName"
                                                                data-placeholder="Assigned Lawyer" CssClass="NormalText" DataValueField="Employee_Id"
                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlAssignedSearch_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:DropDownList ID="ddlMatterType" runat="server" DataTextField="Matter_Type_Desc"
                                                                data-placeholder="Select Mattertype" DataValueField="Matter_Type_Id" CssClass="NormalText"
                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlMatterType_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <%--<td style="width: 20%">
                                                            <asp:DropDownList ID="ddlstage" runat="server" AutoPostBack="true" data-placeholder="Select Stage"
                                                                CssClass="NormalText" DataTextField="stage_type_desc" DataValueField="stage_type_id"
                                                                OnSelectedIndexChanged="ddlstage_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>--%>
                                                        <td style="width: 25%">
                                                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" data-placeholder="Select Status"
                                                                CssClass="NormalText" DataTextField="Staus_Desc" DataValueField="Satus_id" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:LinkButton ID="lnkshowAll" runat="server" OnClick="lnkshowAll_Click">Show All</asp:LinkButton>
                                                <asp:GridView ID="MatterGrid" runat="server" Width="100%" CssClass="grid-view" OnRowCreated="gvHover_RowCreated"
                                                    OnPageIndexChanging="MatterGrid_PageIndexChanging" AutoGenerateColumns="false"
                                                    GridLines="Both" OnRowDataBound="DtgViewStage_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                                    DataKeyNames="Matter_Id" AllowPaging="true" PageSize="15">
                                                    <Columns>
                                                        <asp:ButtonField CommandName="Select" Visible="false" />
                                                        <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="HMatter"
                                                            Visible="false" />
                                                        <asp:BoundField DataField="Matter_number" HeaderText="Matter #" SortExpression="CL"
                                                            meta:resourcekey="HMatter" Visible="false" />
                                                        <asp:TemplateField HeaderText="Matter#" meta:resourcekey="HMatter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="MatterNo" runat="server" Text='<%# Eval("Matter_number") %>' NavigateUrl='<%# "~/Matter/ViewMatter/MatterInfo.aspx?Matter_Id="+Server.UrlEncode(Eval("Matter_Id").ToString())%>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--  <asp:BoundField DataField="Matter_number" HeaderText="Matter#" SortExpression="Matter_number"
                                                            meta:resourcekey="HMatter" />--%>
                                                        <asp:BoundField DataField="Company_Name" HeaderText="Client" SortExpression="EL"
                                                            meta:resourcekey="Hclient" />
                                                        <asp:BoundField DataField="ResponsibileLawyer" HeaderText="Supervising Lawyer" SortExpression="PL"
                                                            meta:resourcekey="HRlawyer" />
                                                        <asp:BoundField DataField="AssignedLawyer" HeaderText="Assigned lawyer" SortExpression="CO"
                                                            meta:resourcekey="HAssigned" />
                                                        <asp:BoundField DataField="Matter_Type_Desc" HeaderText="Last Hearing Decision" SortExpression="CO"
                                                            meta:resourcekey="HLastDescision" />
                                                        <asp:BoundField DataField="Staus_Desc" HeaderText="Last Hearing Date" SortExpression="CO"
                                                            meta:resourcekey="HLastHdate" />
                                                        <asp:TemplateField HeaderText="Current Stage" meta:resourcekey="Hstage">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("stage_type_desc") %>' Width="350px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="stage_type_desc" HeaderText="Current Stage" SortExpression="CO"
                                                            ControlStyle-Width="30%" meta:resourcekey="Hstage" Visible="false" />
                                                    </Columns>
                                                    <SelectedRowStyle BackColor=" #90AA1E" ForeColor="White" Font-Bold="false" />
                                                    <PagerStyle CssClass="PagerStyle" HorizontalAlign="Left" BackColor="#C9C9C9" ForeColor="#A71930" />
                                                </asp:GridView>
                                                <asp:Label runat="server" ID="lbl" Text="" ForeColor="White" Visible="false"></asp:Label>
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
                    <asp:AsyncPostBackTrigger ControlID="txtserach" EventName="TextChanged" />
                    <%--<asp:AsyncPostBackTrigger ControlID="ddlAssignedSearch" EventName="SelectedIndexChanged" />--%>
                    <%-- <asp:PostBackTrigger ControlID="ddlSuperWiseSerach"  />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content' style="width: 612px; margin-top: 2px">
            <h2>
                <asp:Label ID="lbladdMater" runat="server" meta:resourcekey="AddMatter" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="AddMatterPanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="form" style="width: 100%" border="0" align="center">
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
                                        <asp:Label ID="lblclient" runat="server" meta:resourcekey="client" Text="" CssClass="HeaderText"></asp:Label>
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
                                        <asp:Label ID="lblofficeid" runat="server" meta:resourcekey="office" Text="" CssClass="HeaderText"></asp:Label>
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
                                        <asp:Label ID="lblDiscription" runat="server" meta:resourcekey="Discription" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td valign="top" colspan="4">
                                        <asp:TextBox ID="txtMatterDiscription" runat="server" TextMode="MultiLine" Rows="3"
                                            Columns="40"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button CssClass="btn" runat="server" ID="btnAddMatter" Text="Add Matter" ValidationGroup="AddMatter"
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
        <div class="box round first fullpage" id='inline_content1' style="width: 575px; margin-top: 2px">
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
                                        <asp:DropDownList ID="ddlCloseMatter" runat="server" DataTextField="Matter_number"
                                            DataValueField="Matter_ID" CssClass="NormalText" AutoPostBack="true" OnSelectedIndexChanged="GetMatterDetailsClose">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqCloseMatter" runat="server" ControlToValidate="ddlCloseMatter"
                                            InitialValue="Select an Option" ErrorMessage="*"></asp:RequiredFieldValidator>
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
        <div class="box round first fullpage" id='inline_content2' style="width: 575px; margin-top: 2px">
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
                                <td style="width: 30%">
                                    <asp:DropDownList ID="ddlFallowerMatter" runat="server" DataTextField="Matter_number"
                                        DataValueField="Matter_ID" CssClass="NormalText" AutoPostBack="true" OnSelectedIndexChanged="GetFallower">
                                    </asp:DropDownList>
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
                                    <asp:GridView ID="DtgFallower" runat="server" Width="100%" CssClass="grid-view" GridLines="None"
                                        AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="FallowerID"
                                        AutoGenerateDeleteButton="true" OnRowDeleting="Delete_Fallower">
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



            $("#ctl00_ContentPlaceHolder1_ddlFallowerMatter").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlCloseMatter").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlMatterNumber").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlSuperWiseSerach").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlMatterType").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlStatus").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlstage").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlOfficeName").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlAssignedSearch").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlcMatterStatusdata").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlemp").chosen();
            $(".inline").colorbox({ inline: true, width: "53%", height: "60%" });
            $(".inline1").colorbox({ inline: true, width: "50%", height: "60%" });
            $(".inline2").colorbox({ inline: true, width: "50%", height: "60%" });
            $("#colorbox, #cboxOverlay").appendTo('form:first');

        }
        
    </script>
</asp:Content>
