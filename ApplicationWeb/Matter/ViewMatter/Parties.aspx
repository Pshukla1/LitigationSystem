<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Parties.aspx.cs" Inherits="Matter_ViewMatter_Parties" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/grid.css" rel="stylesheet" type="text/css" />
    <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <%--<link href="../../css/colorbox.css" type="text/css" rel="stylesheet" />--%>
    <%--<script src="../../js/jquery.colorbox.js" type="text/javascript"></script>--%>
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            <asp:Label ID="lblFessandPOA" runat="server" meta:resourcekey="Parties" Text=""></asp:Label></h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                       <asp:Panel ID="AddParty" runat="server" Visible="false">
                        <a class='inline' href="#inline_content">
                            <asp:Label ID="lblAddForecase" runat="server" meta:resourcekey="AddParty" Text=""></asp:Label></a>
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
                                    
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <PagerStyle CssClass="PagerStyle" />
                                </asp:GridView>
                                 <asp:Label runat="server" ID="lbl" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                 <asp:Label runat="server" ID="lblMatterno" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dtgPartyGRID" runat="server" Width="100%" CssClass="GridViewStyle"
                                    AllowPaging="true" PageSize="10" GridLines="Both" AutoGenerateColumns="False" DataKeyNames="P_ID">
                                    <Columns>
                                        <asp:BoundField DataField="Matter_number" HeaderText="Matter #" meta:resourcekey="HMatter" />
                                        <asp:BoundField DataField="Company_Name" HeaderText="POA Type" meta:resourcekey="Hparty" />
                                        <asp:BoundField DataField="Party_Type_Desc_En" HeaderText="Issue Date" meta:resourcekey="HPartyType" />
                                        <asp:BoundField DataField="Role_Type_En" HeaderText="Location" meta:resourcekey="HRole" />
                                        <asp:BoundField DataField="Ranking" HeaderText="RANK" meta:resourcekey="HRANK" />
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
        <div class="box round first fullpage" id='inline_content' style="width: 600px;margin-top:2px">
            <h2>
                <asp:Label ID="AddPartyies" runat="server" meta:resourcekey="AddParty" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="FeeDetailsPanel" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td style="width: 5%">
                                        <asp:Label ID="lblMatter" runat="server" meta:resourcekey="Matter" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 5%">
                                    </td>
                                    <td style="width:40%">
                                        <asp:Label ID="txtMatterno" runat="server" Text="" CssClass="NormalText"></asp:Label>
                                    </td>
                                   <td style="width: 5%">
                                        <asp:Label ID="lblparty" runat="server" meta:resourcekey="Party" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 5%">
                                    </td>
                                   <td style="width:40%">
                                        <asp:DropDownList ID="ddlParty" runat="server" AutoPostBack="true" data-placeholder="Select Party Name"
                                            CssClass="NormalText" DataTextField="Company_Name" DataValueField="Party_ID" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 5%">
                                        <asp:Label ID="lblptype" runat="server" meta:resourcekey="Ptype" Text="" CssClass="HeaderText"></asp:Label>
                                    </td>
                                   <td style="width: 5%">
                                    </td>
                                   <td style="width:40%">
                                          <asp:DropDownList ID="ddlPartyType" runat="server" AutoPostBack="true" data-placeholder="Select Type"
                                            CssClass="NormalText" DataTextField="Party_Type_Desc_En" DataValueField="Party_Type_Id" >
                                        </asp:DropDownList>
                                    </td>
                                   <td style="width: 5%">
                                        <asp:Label ID="lblrole" runat="server" meta:resourcekey="RolType" CssClass="HeaderText"
                                            Text=""></asp:Label>
                                    </td>
                                    <td style="width: 5%">
                                    </td>
                                    <td style="width: 40%">
                                         <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" data-placeholder="Select Role"
                                            CssClass="NormalText" DataTextField="Role_Type_En" DataValueField="Role_Id" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btnFeeDetails" Text="Add Party" ValidationGroup="AddParty"
                                            CausesValidation="true" OnClick="btnAddparty_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                <td colspan="6">
                                 <asp:GridView ID="AddPartyGrid" runat="server" Width="100%" CssClass="grid-view" AutoGenerateDeleteButton="true"
                                    AllowPaging="true" PageSize="10" GridLines="Both" AutoGenerateColumns="False" DataKeyNames="P_ID"  OnRowDeleting="Delete_Party">
                                    <Columns>
                                        <asp:BoundField DataField="Matter_number" HeaderText="Matter #" meta:resourcekey="HMatter" />
                                        <asp:BoundField DataField="Company_Name" HeaderText="POA Type" meta:resourcekey="Hparty" />
                                        <asp:BoundField DataField="Party_Type_Desc_En" HeaderText="Issue Date" meta:resourcekey="HPartyType" />
                                        <asp:BoundField DataField="Role_Type_En" HeaderText="Location" meta:resourcekey="HRole" />
                                        <asp:BoundField DataField="Ranking" HeaderText="RANK" meta:resourcekey="HRANK" />
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
            $("#ctl00_ContentPlaceHolder1_ddlRole").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlPartyType").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlParty").chosen();
            $(".inline").colorbox({ inline: true, width: "52%", height: "65%" });
            $("#colorbox, #cboxOverlay").appendTo('form:first');

        }
              
        
    </script>
</asp:Content>
