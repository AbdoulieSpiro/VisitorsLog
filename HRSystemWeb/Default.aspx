<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <span id="helpsLinks"><a href="../school/Help/7/screenshots/FileRoom.jpg" class="highslide"
        onclick="return hs.expand(this)">Help Screen</a> | <a href="../Site/Help/7/pdfhelp/FileRoom.html"
            onclick="return hs.htmlExpand(this, { objectType: 'iframe' } )">Help on this page</a>
    </span>
     
</asp:Content>
