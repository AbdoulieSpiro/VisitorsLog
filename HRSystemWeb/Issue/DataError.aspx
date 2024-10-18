<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="DataError.aspx.cs" Inherits="HRSystemWeb.Issue.DataError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContent" runat="server">
        <table width="100%" id="tblTitle">
            <tr>
                <td>
                    <asp:Label ID="lblPageName" runat="server"  ></asp:Label>
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
