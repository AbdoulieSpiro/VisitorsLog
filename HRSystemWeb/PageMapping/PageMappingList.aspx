<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PageMappingList.aspx.cs" Inherits="HRSystemWeb.PageMapping.PageMappingList"
    Title="Untitled Page" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="2" runat="server" TailName="Page Mapping List" />
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%" class="pageTitleBar">
        <tr>
            <td>
                <asp:Label ID="lblSearchHeaderText" Text="Page Mapping" runat="server" SkinID="LabelPageTitle"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="lnkCreate" runat="server" CssClass="linkButton1" Text="Create" OnClick="lnkCreate_Click1" />
                <asp:Button ID="lnkBack" runat="server" Text="Back" CssClass="linkButton1" OnClick="lnkBack_Click" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="containerHdBg">
                &nbsp;<br />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td class="grid-top-border">
                <asp:DataGrid ID="grdPage" runat="server" PageSize="40" AllowPaging="True" AutoGenerateColumns="False"
                    EnableTheming="true" BorderStyle="Solid">
                    <PagerStyle HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
                    <Columns>
                        <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                            HeaderText="Page Name" DataTextField="PageMappingX">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:HyperLinkColumn>
                        <asp:BoundColumn DataField="PageMappingXX" HeaderText="Page Mapping Name"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
                <br />
                <table id="tblTitle" runat="server">
                    <tr>
                        <td>
                            <%--<asp:LinkButton ID="lnkCreate1" runat="server" OnClick="lnkCreate_Click">Create</asp:LinkButton>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
