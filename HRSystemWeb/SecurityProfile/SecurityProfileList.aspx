<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SecurityProfileList.aspx.cs" Inherits="HRSystemWeb.SecurityProfile.SecurityProfileList"
    Title="Untitled Page" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link href="../assets/css/theme.css" rel="stylesheet">
      <link href="../Content/bootstrap.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="2" runat="server" TailName="Security Profile Maintenance" />
    <table width="100%">
        <tr>
            <td>
                <table id="tblTitle" border="0" cellpadding="0" cellspacing="0" width="100%" class="pageTitleBar">
                    <tr>
                        <td>
                            <asp:Label ID="lblSearchHeaderText" Text="Security Profile Maintenance" runat="server"
                                SkinID="LabelpageTitle"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Button ID="lnkCreate" runat="server" CssClass="linkButton1" Text="Create" OnClick="lnkCreate_Click1" />
                            <asp:Button ID="lnkBack" runat="server" Text="Back" CssClass="linkButton1" OnClick="lnkBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="containerHdBg">
                &nbsp;<br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="grid-top-border">
                <asp:DataGrid ID="grdPage" runat="server" PageSize="20" AllowPaging="True" AutoGenerateColumns="False"
                    EnableTheming="True" Width="100%">
                    <PagerStyle HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
                    <Columns>
                        <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                            HeaderText="Security Profile Name" DataTextField="SecurityProfileX">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:HyperLinkColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
