<%@ Page Language="c#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Inherits="HRSystemWeb.RolePageMappingList" CodeFile="RolePageMappingList.aspx.cs" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="3" runat="server" TailName="Role Page Mapping Maintenance" />
    <table class="tableinput" width="100%">
        <tr>
            <td align="right">
                <table id="Table2" border="0" cellpadding="0" cellspacing="0" width="100%" class="pageTitleBar">
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
                <asp:Button ID="lnkSave" runat="server" CssClass="linkButton1" Text="Save" OnClick="lnkSave_Click"></asp:Button>
            </td>
        </tr>
    </table>
    <table id="field-table" cellspacing="0" cellpadding="0">
        <tr>
            <td class="darkgreybgcolor">
                <h1>
                    <asp:Label ID="lblPageName" runat="server" CssClass="sectionStandout"></asp:Label></h1>
            </td>
        </tr>
        <tr>
            <td class="borderwithbgcolor">
                <br />
                <asp:UpdatePanel ID="pnl" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid ID="grdPage" runat="server" GridLines="None" BorderWidth="1px" BorderStyle="None"
                            AutoGenerateColumns="False" OnItemCommand="grdPage_ItemCommand">
                            <Columns>
                                <asp:TemplateColumn HeaderText="Select">
                                    <HeaderTemplate>
                                        &nbsp;<asp:CheckBox ID="chkCheckall" runat="server" AutoPostBack="true" OnCheckedChanged="chkCheckall_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" runat="server" value='<%# Eval("Pagemapping") %>' id="chkSelect"
                                            checked='<%# Convert.ToBoolean( Eval("IsSelect")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                                    HeaderText="System Forms" DataTextField="PageMappingXX"></asp:HyperLinkColumn>
                            </Columns>
                        </asp:DataGrid>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
