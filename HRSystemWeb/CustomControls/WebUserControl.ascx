<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs"
    Inherits="CustomControls_WebUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div id="dng_photo2" style="background-color: #333333; color: #ffffff; position: absolute;
    width: 303px; height: 23px; display: none;">
    <asp:Label ID="lblDesc" runat="server" Text="Label" CssClass="labelHeaderTitle"></asp:Label>
</div>
<div id="dvimg" style="text-align: left">
    <asp:Image runat="server" ID="image1" Width="190px" Height="200" AlternateText="Please Wait..." />
    <ajaxToolkit:SlideShowExtender ID="SlideShowExtender1" runat="server" TargetControlID="image1"
        SlideShowServiceMethod="GetCauseImage" PlayInterval="2000" AutoPlay="true" Loop="true"
        SlideShowServicePath="../SlideShow.asmx">
    </ajaxToolkit:SlideShowExtender>
</div>
