<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ItemNotFound.aspx.cs" Inherits="HRSystemWeb.Issue.ItemNotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContent" runat="server">
        <table width="100%" id="tblTitle">
            <tr>
                <td>
                    <asp:Label ID="lblPageName" runat="server"  >The requested item was not found.  It may have been renamed or removed.</asp:Label>
                </td>
                <td align="right">
                    <asp:HyperLink ID="lnkReturn" runat="server" CssClass="btn btn-primary btn-sm" NavigateUrl="javascript:history.go(-1)">Return</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:Label ID="lblSection" runat="server" EnableViewState="False"></asp:Label>
</asp:Content>
