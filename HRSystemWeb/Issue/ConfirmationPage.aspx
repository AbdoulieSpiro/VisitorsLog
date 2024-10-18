<%@ Page Language="C#" ValidateRequest="false"  AutoEventWireup="true"
    CodeFile="ConfirmationPage.aspx.cs" Inherits="HRSystemWeb.Issue.ConfirmationPage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<body class="f-small custom bg-grey iehandle" id="ff-palatino">
    <form id="frmMaster" runat="server">
    <div id="divContent" runat="server">
        <table id="tblTitle">
            <tr>
                <td>
                    <asp:Label ID="lblPageName" runat="server"> Confirmation Page:</asp:Label>
                </td>
                <td align="right">
                    <asp:LinkButton ID="lnkHome" runat="server" CssClass="linkButton1" Width="56px" CausesValidation="False">Home</asp:LinkButton>
                    <asp:HyperLink ID="lnkReturn" runat="server" CssClass="linkButton1" NavigateUrl="javascript:history.go(-1)"
                        Visible="False">Return</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:Label ID="lblSection" runat="server" EnableViewState="False"></asp:Label>
    </form>
    <%--</asp:Content>--%>
</body>
</html>
