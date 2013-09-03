<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="StageDetails.aspx.cs" Inherits="Matter_Stage_StageDetails" %>
    <%@ Register Assembly="Highchart" Namespace="Highchart.UI" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/Controls/MyMessageBox.ascx" TagName="MyMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script src="../../js/grid.js" type="text/javascript"></script>
    <link id="lnkCSS" href="~/css/general.css" runat="server" rel="stylesheet" type="text/css" />
    <link href="../../css/layout1.css" runat="server" rel="stylesheet" type="text/css" />
     <link href="../../css/GridNew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/popupstyle.css" type="text/css" />
    <div class="box round first grid" style="width: 950px; margin-top: 12px">
        <h2>
            Stage Details</h2>
        <div id="add-new">
            <table id="add-new-table">
                <tr>
                    <td>
                        <a class='inline1' href="#inline_content1">
                            <asp:Label ID="lblAddForecase" runat="server" meta:resourcekey="SaddForecast" Text=""></asp:Label></a>
                    </td>
                    <td>
                        <a class='inline' href="#inline_content">
                            <asp:Label ID="lbladdstage" runat="server" meta:resourcekey="SaddStage" Text=""></asp:Label></a>
                    </td>
                    <td>
                        <a class='inline2' href="#inline_content2">
                            <asp:Label ID="lblclosestage" runat="server" meta:resourcekey="Sclosestage" Text=""></asp:Label></a>
                    </td>
                     <td>
                           <a class='inline3' href="#inline_content3">
                            <asp:Label ID="Label1" runat="server" meta:resourcekey="SDeletestage" Text=""></asp:Label></a>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 3%; margin-right: 3%; margin-top: 2%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="1" cellspacing="1">
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="DtgViewStage" runat="server" Width="100%" CssClass="grid-view"
                                    AllowPaging="true" PageSize="10" OnRowCreated="gvHover_RowCreated" AutoGenerateColumns="False"
                                    DataKeyNames="Stage_ID" OnPageIndexChanging="DtgViewStage_PageIndexChanging"
                                    GridLines="Both" OnRowDataBound="DtgViewStage_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select" Visible="false" />
                                        <asp:BoundField DataField="Matter_Id" HeaderText="Matter #" SortExpression="CL" meta:resourcekey="HMatter"
                                            Visible="false" />
                                        <asp:BoundField DataField="stage_type_desc" HeaderText="STAGE" SortExpression="stage_type_desc"
                                            meta:resourcekey="HSstage" />
                                        <asp:BoundField DataField="Staus_Desc" HeaderText="STATUS" SortExpression="Staus_Desc"
                                            meta:resourcekey="HSStatus" />
                                        <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" SortExpression="Description"
                                            meta:resourcekey="HSDescription" />
                                        <asp:BoundField DataField="Open_date" HeaderText="OPEN DATE" SortExpression="Open_date"
                                            meta:resourcekey="HSOpen_date" DataFormatString="{0:dd-MMM-yyy}" />
                                        <asp:BoundField DataField="Close_date" HeaderText="CLOSE DATE" SortExpression="Close_date"
                                            meta:resourcekey="HSClose_date" DataFormatString="{0:dd-MMM-yyy}" />
                                        <asp:BoundField DataField="Exp_Start_Date" HeaderText="FORECAST START" SortExpression="Exp_Start_Date"
                                            meta:resourcekey="HSExp_Start_Date" DataFormatString="{0:dd-MMM-yyy}" />
                                        <asp:BoundField DataField="Exp_End_date" HeaderText="FORECAST END" SortExpression="Exp_End_date"
                                            meta:resourcekey="HSExp_End_date" DataFormatString="{0:dd-MMM-yyy}" />
                                        <asp:BoundField DataField="weighting" HeaderText="EFFORT" SortExpression="weighting"
                                            meta:resourcekey="HSweighting" />
                                        <asp:BoundField DataField="Actual_Effort" HeaderText="COMPLETED" SortExpression="Actual_Effort"
                                            meta:resourcekey="HSActual_Effort" />
                                    </Columns>
                                    
                                     <SelectedRowStyle BackColor=" #90AA1E" ForeColor="White" Font-Bold="false" />
                               
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <PagerStyle CssClass="PagerStyle" />
                                </asp:GridView>
                                <asp:Label runat="server" ID="lbl" Text="" ForeColor="Red" Visible="false"></asp:Label>
                             <uc1:MyMessageBox ID="MyMessageBoxInfo" runat="server" ShowCloseButton="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <cc1:ScatterChart ID="CaseChart" runat="server" Height="250px" />
                                   
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DtgViewStage" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="DtgViewStage" EventName="RowCommand" />
                    <%--<asp:PostBackTrigger  />
                            <asp:PostBackTrigger  />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style='display: none;'>
        <div class="box round first fullpage" id='inline_content' style="width: 575px;margin-top:2px">
            <h2>
                <asp:Label ID="Addstges" runat="server" meta:resourcekey="AddStage" Text=""></asp:Label></h2>
            <div class="block add-matter">
             <asp:UpdatePanel runat="server" ID="pnladdstage" >
                <ContentTemplate>
                <table class="form">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblStageMatter" runat="server" meta:resourcekey="Matter" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td colspan="3">
                                <asp:Label ID="txtStageMatterno" runat="server" Text="" CssClass="NormalText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStageStage" runat="server" meta:resourcekey="Stage" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStageStage" runat="server" DataTextField="stage_type_desc"
                                 data-placeholder="Select Stage"   DataValueField="stage_type_id" CssClass="NormalText">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="ReqCloseMatter" runat="server" ControlToValidate="ddlStageStage" InitialValue="0" ErrorMessage="*"  ValidationGroup="AddStage"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblPreviousStage" runat="server" meta:resourcekey="PreviousStage"
                                    CssClass="HeaderText" Text=""></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPStage" runat="server" DataTextField="stage_type_desc" DataValueField="stage_type_id"
                                   data-placeholder="Select Stage"  CssClass="NormalText">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblstageopebdate" runat="server" meta:resourcekey="stageopebdate"
                                    CssClass="HeaderText" Text=""></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:TextBox ID="txtstageopebdate" runat="server" Text=""></asp:TextBox>
                                <AjaxControlToolkit:CalendarExtender ID="CalStageOpenDate1" runat="server" TargetControlID="txtstageopebdate"
                                    PopupButtonID="txtstageopebdate" Format="dd-MMM-yyyy">
                                </AjaxControlToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqStartDate" runat="server" ValidationGroup="AddStage"
                                    ErrorMessage="*" ControlToValidate="txtstageopebdate"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblstagecloseDate" runat="server" meta:resourcekey="StagecloseDate"
                                    CssClass="HeaderText" Text=""></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:TextBox ID="txtstagecloseDate" runat="server" Text=""></asp:TextBox>
                                <AjaxControlToolkit:CalendarExtender ID="CalStageCloseDate1" runat="server" TargetControlID="txtstagecloseDate"
                                    PopupButtonID="txtstagecloseDate" Format="dd-MMM-yyyy">
                                </AjaxControlToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqEnddate" runat="server" ValidationGroup="AddStage"
                                    ErrorMessage="*" ControlToValidate="txtstagecloseDate"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblstageDiscription" runat="server" meta:resourcekey="stageDiscription"
                                    CssClass="HeaderText" Text=""></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtstageDiscription" runat="server" Text="" TextMode="MultiLine"
                                    Rows="5" Columns="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqDiscription" runat="server" ValidationGroup="AddStage"
                                    ErrorMessage="*" ControlToValidate="txtstageDiscription"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="btn" runat="server" ID="Button1" Text="Add Stage" ValidationGroup="AddStage"
                                    CausesValidation="true" OnClick="btnAddStage_Click"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content1' style="width: 575px;margin-top:2px">
            <h2>
                <asp:Label ID="addForecasts" runat="server" meta:resourcekey="AddForecast" Text=""></asp:Label></h2>
            <div class="block add-matter">
                <asp:UpdatePanel ID="forecastPanel" runat="server">
                    <ContentTemplate>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblForecastMatter" runat="server" meta:resourcekey="Matter" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:Label ID="lblForecastmatterno" runat="server" Text="CN-050513-5561140"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblForecastStage" runat="server" meta:resourcekey="Stage" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlForcastStage" runat="server" DataTextField="stage_type_desc"
                                            DataValueField="stage_type_id" CssClass="NormalText">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblForecastStart" runat="server" meta:resourcekey="ForecastStart"
                                            CssClass="HeaderText" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtForecastStart" runat="server" Text=""></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtForecastStart"
                                            PopupButtonID="txtForecastStart" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqForecastStart" runat="server" ValidationGroup="AddForecast"
                                            ErrorMessage="*" ControlToValidate="txtForecastStart"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblForecastEnd" runat="server" meta:resourcekey="ForecastEnd" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtForecastEnd" runat="server" Text=""></asp:TextBox>
                                        <AjaxControlToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtForecastEnd"
                                            PopupButtonID="txtForecastEnd" Format="dd-MMM-yyyy">
                                        </AjaxControlToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqForecastEnd" runat="server" ValidationGroup="AddForecast"
                                            ErrorMessage="*" ControlToValidate="txtForecastEnd"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblActualEffort" runat="server" meta:resourcekey="ActualEffort" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActualEffort" runat="server" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqActualEffort" runat="server" ValidationGroup="AddForecast"
                                            ErrorMessage="*" ControlToValidate="txtActualEffort"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcompleted" runat="server" meta:resourcekey="completed" Text=""
                                            CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td style="width: 15px">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcompleted" runat="server" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqCompleted" runat="server" ValidationGroup="AddForecast"
                                            ErrorMessage="*" ControlToValidate="txtcompleted"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button class="btn" runat="server" ID="btn" Text="Add Forecast" ValidationGroup="AddForecast"
                                            CausesValidation="true" OnClick="btnAddForecast_Click"></asp:Button>
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
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content2' style="width: 587px;margin-top:2px">
            <h2>
                <asp:Label ID="closestage" runat="server" meta:resourcekey="CloseStage" Text=""></asp:Label></h2>
            <div class="block add-matter">
            <asp:UpdatePanel ID="UpdatePanelClose" runat="server">
             <ContentTemplate>
             <table class="form">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblmatternoclsoe" runat="server" meta:resourcekey="Matter" Text=""
                                    CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td colspan="3">
                                <asp:Label ID="txtmatternoclsoe" runat="server" Text="" CssClass="NormalText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblstage" runat="server" meta:resourcekey="Stage" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                             <td style="width:15px"></td>
                            <td colspan="3">
                             <asp:DropDownList ID="ddlstageprevious" runat="server" DataTextField="stage_type_desc"
                                    DataValueField="stage_type_id" CssClass="NormalText">
                                </asp:DropDownList>
                              
                            </td>
                        
                           <%-- <td>
                                <asp:Label ID="lblpreviousstageclose" runat="server" meta:resourcekey="PreviousStage" Text="" CssClass="HeaderText"> </asp:Label>
                            </td>
                             <td style="width:15px"></td>
                            <td>
                                  <asp:DropDownList ID="ddlstge" runat="server" DataTextField="stage_type_desc"
                                    DataValueField="Stage_Id" CssClass="NormalText">
                                </asp:DropDownList>
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblopendatestage" runat="server" meta:resourcekey="stageopebdate"
                                    Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:TextBox ID="txtopendatestage" runat="server" Text=""></asp:TextBox>
                                
                            </td>
                            <td>
                                <asp:Label ID="lblclosedatestage" runat="server" meta:resourcekey="stagecloseDate"
                                    Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:TextBox ID="txtclosedatestage" runat="server" Text=""></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblstageClose" runat="server" meta:resourcekey="stageDiscription"
                                    Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtdicrptionClose" runat="server" Text="" TextMode="MultiLine" Rows="5"
                                    Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStageStatus" runat="server" meta:resourcekey="Staus" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlStageStatus" runat="server" DataTextField="Staus_Desc" CssClass="NormalText"
                                    DataValueField="Satus_id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="btn" runat="server" ID="btnClStage" Text="Close Stage" ValidationGroup="CloseStage"
                                    CausesValidation="true" OnClick="btnCloseStage_Click"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
            <Triggers></Triggers>
            </asp:UpdatePanel>
               
            </div>
        </div>
    </div>
    <div style='display: none'>
        <div class="box round first fullpage" id='inline_content3' style="width: 587px;margin-top:2px">
            <h2>
                <asp:Label ID="lbldelstage" runat="server" meta:resourcekey="SDeletestage" Text=""></asp:Label></h2>
            <div class="block add-matter">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
             <table class="form">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lbldelmatter" runat="server" meta:resourcekey="Matter" Text=""
                                    CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td colspan="3">
                                <asp:Label ID="txtdelmatter" runat="server" Text="" CssClass="NormalText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="delstgae" runat="server" meta:resourcekey="Stage" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                             <td style="width:15px"></td>
                            <td colspan="3">
                             <asp:DropDownList ID="delddlstgae" runat="server" DataTextField="stage_type_desc"
                                    DataValueField="stage_type_id" CssClass="NormalText">
                                </asp:DropDownList>
                              
                            </td>
                        
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="delopendate" runat="server" meta:resourcekey="stageopebdate"
                                    Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:TextBox ID="txtdelopendate" runat="server" Text=""></asp:TextBox>
                                
                            </td>
                            <td>
                                <asp:Label ID="delclosedate" runat="server" meta:resourcekey="stagecloseDate"
                                    Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td>
                                <asp:TextBox ID="txtdelclosedate" runat="server" Text=""></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="deldeiscription" runat="server" meta:resourcekey="stageDiscription"
                                    Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15px">
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtdeldicription" runat="server" Text="" TextMode="MultiLine" Rows="5"
                                    Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                                <asp:Button class="btn" runat="server" ID="Button2" Text="Delete Stage" 
                                    CausesValidation="true" OnClick="btndeleteStage_Click"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
            <Triggers></Triggers>
            </asp:UpdatePanel>
               
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#ctl00_ContentPlaceHolder1_ddlStageStatus").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlForcastStage").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlPStage").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlStageStage").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlstageprevious").chosen();

            $("#ctl00_ContentPlaceHolder1_delddlstgae").chosen();
            $("#ctl00_ContentPlaceHolder1_ddlstageprevious").chosen();

            $(".inline").colorbox({ inline: true, width: "50%", height: "70%" });
            $(".inline1").colorbox({ inline: true, width: "50%", height: "70%" });
            $("#colorbox, #cboxOverlay").appendTo('form:first');
            $(".inline2").colorbox({ inline: true, width: "51%", height: "70%" });
            $(".inline3").colorbox({ inline: true, width: "51%", height: "70%" });

            //event.preventDefault();
            //            __doPostBack('ctl00_ContentPlaceHolder1_ForecastAdd', 'OnClick');
            //            $(document).ready(function () {
            //                $("#ctl00_ContentPlaceHolder1_ForecastAdd").click(function () {
            //                    alert("button");
            //                });
            //            }); 

        }
              
        
    </script>
</asp:Content>
