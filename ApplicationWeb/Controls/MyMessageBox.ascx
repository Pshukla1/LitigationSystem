<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyMessageBox.ascx.cs"
    Inherits="MyMessageBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:LinkButton ID="LinkButtonTargetControl" runat="server"></asp:LinkButton>
<link rel="stylesheet" href="../css/popupstyle.css" type="text/css" />
<cc1:ModalPopupExtender ID="ModalPopupExtenderMessage" runat="server" TargetControlID="LinkButtonTargetControl"
    PopupControlID="MessageBox" OkControlID="ButtonOK" CancelControlID="CloseButton"
    BackgroundCssClass="messagemodalbackground" />
<asp:Panel ID="MessageBox" runat="server" Style="display: none">
    <div class="messageheader">
        <%-- <asp:Image ID="ImgMsgType" runat="server" />&nbsp;--%>
        <%--<asp:Label ID="LabelPopupHeader" Text="Polyplex" CssClass="messageheadertext" ForeColor="#A71930"
            runat="server" />--%>
        <asp:HyperLink runat="server" ID="CloseButton">
            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/delete.gif" AlternateText="Close" />--%>
        </asp:HyperLink>
    </div>
    <div>
        <p>
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </p>
    </div>
    <div class="messagefooter">
        <asp:Button ID="ButtonOK" runat="server" Text="OK" CausesValidation="false" />
    </div>
</asp:Panel>
