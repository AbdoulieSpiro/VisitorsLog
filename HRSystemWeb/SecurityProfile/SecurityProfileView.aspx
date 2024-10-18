<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SecurityProfileView.aspx.cs" Inherits="HRSystemWeb.SecurityProfile.SecurityProfileView"
    Title="Untitled Page" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link href="../assets/css/theme.css" rel="stylesheet">
      <link href="../Content/bootstrap.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="3" runat="server" TailName=" Security Profile View  " />
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%" class="pageTitleBar">
        <tr>
            <td>
                <asp:Label ID="lblPageTitle" runat="server" SkinID="LabelPageTitle" Text="Security Profile View"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="lnkEdit" runat="server" CssClass="linkButton1" Text="Edit" OnClick="lnkEdit_Click" />
                <asp:Button ID="lnkClone" runat="server" CssClass="linkButton1" Text="Clone" OnClick="lnkClone_Click" />
                <asp:Button ID="lnkCancel" runat="server" Text="Back" CssClass="linkButton1" OnClick="lnkCancel_Click" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="containerHdBg">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSecurityProfileX" runat="server" Text='<%# ds.Tables[0].Rows[0]["SecurityProfileX"] %>'>
                </asp:Label>
            </td>
        </tr>
    </table>
    <div class="searchborder" align="center">
        <table width="98%">
            <tr>
                <td>
                    <br />
                    <asp:DataGrid ID="grdPageMapping" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                                HeaderText="System Forms" DataTextField="PageMappingX"></asp:HyperLinkColumn>
                        </Columns>
                    </asp:DataGrid>
                    <br />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
