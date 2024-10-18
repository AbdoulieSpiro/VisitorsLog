<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SecurityProfileEdit.aspx.cs" Inherits="HRSystemWeb.SecurityProfile.SecurityProfileEdit"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%" class="pageTitleBar">
        <tr>
            <td>
                <asp:Label ID="lblSearchHeaderText" Text="Security Profile Edit" SkinID="LabelPageTitle"
                    runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="lnkUpdate" runat="server" CssClass="linkButton1" Text="Save" OnClick="lnkUpdate_Click" />
                <asp:Button ID="lnkCancel" runat="server" CausesValidation="False" Text="Cancel"
                    CssClass="linkButton1" OnClick="lnkCancel_Click" />
                <asp:Button ID="lnkDelete" runat="server" CausesValidation="False" Text="Delete"
                    CssClass="linkButton1" OnClick="lnkDelete_Click" />
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
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="98%" cellpadding="5" cellspacing="5">
        <tr>
            <td>
                Security Profile:
            </td>
            <td>
                <asp:TextBox ID="txtSecurityProfileX" runat="server" Width="312px" Columns="35" Text='<%# ds.Tables[0].Rows[0]["SecurityProfileX"] %>'
                    MaxLength="50">
                </asp:TextBox><br />
                <asp:RequiredFieldValidator ID="valSecurityProfileX" runat="server" CssClass="validator"
                    ErrorMessage="<br/>This field is required" ControlToValidate="txtSecurityProfileX"
                    Display="Dynamic" Width="272px" Height="16px" ForeColor=" "></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</asp:Content>
