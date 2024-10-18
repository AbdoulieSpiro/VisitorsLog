<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ControlMappingEdit.aspx.cs" Inherits="HRSystemWeb.PageMapping.ControlMappingEdit"
    Title="Untitled Page" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="4" runat="server" TailName="Edit Control" />
    <table id="Table1" runat="server" width="100%" border="0">
        <tr>
            <td>
                <asp:Label ID="lblPageName" runat="server" Text="Create Control Mapping" SkinID="LabelPageTitle"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="lnkUpdate" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkUpdate_Click"
                    Text="Save"></asp:Button>
                <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                    OnClick="lnkCancel_Click" Text="Cancel"></asp:Button>
                <asp:Button ID="lnkDelete" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                    OnClick="lnkDelete_Click" Text="Delete"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="containerHdBg" colspan="2">
            </td>
        </tr>
    </table>
    <br />
    <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="darkgreybgcolor">
                Update Page Control
            </td>
        </tr>
        <tr>
            <td class="borderwithbgcolor">
                <table width="95%" border="0" align="center" cellpadding="5" cellspacing="5">
                    <tr>
                        <td width="12%">
                            ControlMapping Name:
                        </td>
                        <td width="38%">
                            <asp:TextBox ID="txtControlMappingX" runat="server" Width="312px" Columns="35" Text='<%# ds.Tables[0].Rows[0]["ControlMappingX"] %>'
                                MaxLength="50">
                            </asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="valControlMappingX" runat="server" ErrorMessage="<br/>This field is required"
                                ControlToValidate="txtControlMappingX" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Control Code:
                        </td>
                        <td>
                            <asp:TextBox ID="txtControlMappingCode" runat="server" MaxLength="50" Text='<%# ds.Tables[0].Rows[0]["ControlMappingCode"] %>'
                                Columns="35" Width="312px">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
