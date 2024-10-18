<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PageMappingEdit.aspx.cs" Inherits="HRSystemWeb.PageMapping.PageMappingEdit"
    Title="Untitled Page" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="2" runat="server" TailName="Page Mapping Edit" />
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblSearchHeaderText" Text="Page Mapping Edit" SkinID="LabelPageTitle"
                    runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="lnkUpdate" runat="server" CssClass="btn btn-primary btn-sm" Text="Save" OnClick="lnkUpdate_Click">
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
    <table width="100%">
        <tr>
            <td class="containerHdBg">
                &nbsp;<br />
            </td>
        </tr>
    </table>
    <br />
    <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0" style="width: 99.5%;
        border-style: none solid; border-left: 1px solid rgb(1, 53, 112); border-right: 1px solid rgb(1, 53, 112);
        width: 100%; border-top: 1px solid rgb(1, 53, 112); border-bottom: 1px solid rgb(1, 53, 112);">
        <tr>
            <td class="CenterPageTop">
                <table width="100%">
                    <tr>
                        <td>
                            <table id="tblInput" cellpadding="5" cellspacing="5">
                                <tr>
                                    <td>
                                        Page Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPageMappingX" runat="server" Width="312px" Columns="35" Text='<%# ds.Tables[0].Rows[0]["PageMappingX"] %>'
                                            MaxLength="50">
                                        </asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="valPageMappingX" runat="server" ErrorMessage="This field is required"
                                            ControlToValidate="txtPageMappingX" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        PageMapping Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPageMappingXX" runat="server" Width="312px" Columns="35" Text='<%# ds.Tables[0].Rows[0]["PageMappingXX"] %>'
                                            MaxLength="50">
                                        </asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required"
                                            ControlToValidate="txtPageMappingXX" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
