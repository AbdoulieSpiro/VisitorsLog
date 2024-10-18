<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PageMappingView.aspx.cs" Inherits="HRSystemWeb.PageMapping.PageMappingView"
    Title="View Page Mapping" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="3" runat="server" TailName="Edit Page" />
    <table width="99%" cellspacing="0" cellpadding="0" height="30">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblPageMappingX" runat="server" CssClass="labelField" Text='<%# ds.Tables[0].Rows[0]["PageMappingX"].ToString().Replace(".aspx","") %>'
                                SkinID="LabelPageTitle">
                            </asp:Label>
                        </td>
                        <td align="right">
                            <asp:Button ID="lnkEdit" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkEdit_Click1"
                                Text="Edit Page Mapping"></asp:Button>
                            <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkCancel_Click1"
                                Text="Cancel"></asp:Button>
                        </td>
                    </tr>
                </table>
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
    <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0" style="width: 99.5%;">
        <tr>
            <td class="CenterPageTop">
                <asp:DataGrid ID="grdControlMapping" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                            HeaderText="Control Mapping" DataTextField="ControlMappingX"></asp:HyperLinkColumn>
                    </Columns>
                </asp:DataGrid>
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Button ID="lnkCreate" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkCreate_Click"
                                Text="Create New Page Control"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
