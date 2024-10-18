<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RestrictedSecurity.aspx.cs"
    Inherits="HRSystemWeb.Issue.RestrictedSecurity"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Restricted Access</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0">
        <tr>
            <td>
                <h1>
                    Restricted Access</h1>
            </td>
            <td align="right">
                <asp:LinkButton ID="lnkHome" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                    OnClick="lnkHome_Click">Home</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
