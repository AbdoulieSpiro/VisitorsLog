<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ControlPanelAdministratorList.aspx.cs" Inherits="HRSystemWeb.ControlPanel_ControlPanelAdministratorList"
    Title="Control Panel" %>

<%@ Register Src="../CustomControls/AdministratorPortal.ascx" TagName="AdministratorPortal"
    TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <asp:AdministratorPortal ID="ControlPanel" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
