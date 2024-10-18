<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdministratorCalanderEvent.ascx.cs"
    Inherits="HRSystemWeb.AdministratorCalanderEvent" %>
<div align="center">
    <table width="100%" cellspacing="4" cellpadding="4" align="center">
        <tr>
            <td style="width: 33%">
                <asp:ImageButton ID="ImageButton11" runat="server" SkinID="imgBTYearCalender" PostBackUrl="~/Admin/SchoolCalander.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label11" runat="server" Text="Year Calendar" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 33%">
                <asp:ImageButton ID="ImageButton7" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Admin/AddEditEvents.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Event List" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 34%">
                <asp:ImageButton ID="ImageButton8" runat="server" SkinID="imgBTArchiveUnArchive"
                    PostBackUrl="~/Admin/AddEditCalander.aspx"></asp:ImageButton>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Calendar List" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
</div>
