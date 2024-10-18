<%@ Control Language="c#" Inherits="HRSystemWeb.SimpleHeaderControl" CodeFile="SimpleHeaderControl.ascx.cs" %>
<table cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td nowrap align="right" valign="top">
            <%-- <asp:ImageButton ID="Imagebutton1" BorderWidth="0" EnableViewState="False" CssClass="StandardSchoolLogo"
                runat="server"></asp:ImageButton>--%><asp:LinkButton ID="lklogout" BorderWidth="0"
                    EnableViewState="False" runat="server" OnClick="lnkLogOut_Click">Log Out</asp:LinkButton>
        </td>
    </tr>
</table>
