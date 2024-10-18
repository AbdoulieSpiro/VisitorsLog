<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SystemRoleTypeEdit.aspx.cs" Inherits="HRSystemWeb.SystemRoleTypeEdit"
    Title="System Role" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="3" runat="server" TailName="Create/ Update System Roletype " />
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblSearchHeaderText" Text="Create/ Update System Roletype" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="lnkUpdate" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="lnkUpdate_Click">
                </asp:Button>
                <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-primary btn-sm" Text="Cancel" CausesValidation="False"
                    OnClick="lnkCancel_Click"></asp:Button>
                <asp:Button ID="lnkDelete" runat="server" CssClass="btn btn-primary btn-sm" Text="Delete" OnClick="lnkDelete_Click">
                </asp:Button>
                <asp:Label ID="lblMsg" runat="server" Visible="false" Text="Role can not be deleted.It is assigned to some other User."
                    ForeColor="red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0" style="width: 99.5%;
        border-style: none solid; border-left: 1px solid rgb(1, 53, 112); border-right: 1px solid rgb(1, 53, 112);
        width: 100%; border-top: 1px solid rgb(1, 53, 112); border-bottom: 1px solid rgb(1, 53, 112);"
        cellpadding="5" cellspacing="5">
        <tr>
            <td>
                <br />
                <asp:Panel ID="pnlInput" runat="server">
                    <table id="tblInput" width="95%" border="0" align="center" cellpadding="5" cellspacing="5"
                        runat="server">
                        <tr>
                            <td width="12%">
                                System Roletype:
                            </td>
                            <td width="32%">
                                <asp:TextBox ID="txtSystemRoleTypeX" runat="server" Width="268px" Columns="35" Text='<%# ds.Tables[0].Rows[0]["SystemRoleTypeX"] %>'
                                    MaxLength="50">
                                </asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="valSystemRoleTypeX" runat="server" ErrorMessage="This field is required"
                                    ControlToValidate="txtSystemRoleTypeX" Display="Dynamic" Width="272px"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Security Profile:
                            </td>
                            <td>
                                <asp:DropDownList ID="lstSecurityProfile" runat="server" Width="272px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="tdAllCompanies" runat="server" visible="false">
                            <td>
                                Access All Companies:
                            </td>
                            <td>
                                <asp:CheckBox ID="chkAllowAllCompanyAccess" runat="server" Checked='<%# ds.Tables[0].Rows[0]["AllowAllCompanyAccess"] %>'>
                                </asp:CheckBox>
                            </td>
                        </tr>
                        <tr id="tdAllSchools" runat="server" visible="false">
                            <td>
                                Access All Schools:
                            </td>
                            <td>
                                <asp:CheckBox ID="chkAllowAllSchoolAccess" runat="server" Checked='<%# ds.Tables[0].Rows[0]["AllowAllSiteAccess"] %>'>
                                </asp:CheckBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
