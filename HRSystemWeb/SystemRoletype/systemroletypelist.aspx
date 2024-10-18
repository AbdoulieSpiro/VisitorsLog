<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SystemRoleTypeList.aspx.cs" Inherits="HRSystemWeb.SystemRoleType.SystemRoleTypeList"
    Title="System Roles" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="2" runat="server" TailName="System Roletype Maintenance " />
    <table width="99%" cellspacing="0" cellpadding="0" height="30px">
        <tr>
            <td>
                <table id="tblTitle" border="0" cellpadding="0" cellspacing="0" width="100%" class="pageTitleBar">
                    <tr>
                        <td>
                            <asp:Label ID="lblSearchHeaderText" Text="System Roletype Maintenance" EnableTheming="false"
                                runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Button ID="lnkCreate" runat="server" CssClass="linkButton1" Text="Create" OnClick="lnkCreate_Click1" />
                            <asp:Button ID="lnkBack" runat="server" Text="Back" CssClass="linkButton1" OnClick="lnkBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:DataGrid ID="grdPage" runat="server" PageSize="20" AllowPaging="True" CellPadding="3"
                    AutoGenerateColumns="False" EnableTheming="true">
                    <PagerStyle HorizontalAlign="Left" CssClass="gridPage" Mode="NumericPages"></PagerStyle>
                    <Columns>
                        <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                            HeaderText="System Role Type Name" DataTextField="SystemRoleTypeX">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:HyperLinkColumn>
                        <%-- <asp:BoundColumn HeaderText="Access All Schools" DataField="AllowAllSchoolAccess"></asp:BoundColumn>--%>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
