<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Matter_ViewMatter_Default" %>

<%@ Register Assembly="Highchart" Namespace="Highchart.UI" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <cc1:ScatterChart ID="CaseChart" runat="server" Height="250px" />
</asp:Content>

