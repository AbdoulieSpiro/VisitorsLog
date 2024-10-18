<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SystemRoletypeView.aspx.cs" Inherits="SecurityProfile_SecurityProfileView"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td class="SectionTitleLeft">
            </td>
            <td class="SectionTitleLeftMid" style="width: 20%">
             <%--   <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle" Text="System RoleType View"></asp:Label>--%>
            </td>
            <td class="SectionTitleRightMid">
            </td>
            <td class="SectionTitleRight">
                <table width="100%">
                    <tbody>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upupContent" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" border="0" runat="server" class="pageTitleBar"
                            width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPageName" runat="server" SkinID="LabelPageTitle"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <fieldset>
                            <table cellspacing="1" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td class="fieldPrompt">
                                        System Role Type:
                                    </td>
                                    <td class="fieldpromptvalue">
                                        <asp:Label ID="lblSecurityProfileX" runat="server" Text='<%# ds.Tables[0].Rows[0]["SystemRoleTypeX"] %>'>
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tr>
                                <td>
                                    <table id="Table1" cellspacing="0" cellpadding="0" border="0" runat="server" class="pageTitleBar"
                                        width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" SkinID="LabelPageTitle">Pages and User Controls</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DataGrid ID="grdPageMapping" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        GridLines="None" Width="100%" AllowPaging="True" PageSize="20" OnPageIndexChanged="grdPageMapping_PageIndexChanged"
                                        OnItemCommand="grdPageMapping_ItemCommand1">
                                        <Columns>
                                            <asp:BoundColumn DataField="PageMappingX" HeaderText="Page/User Control Name"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PageMappingXX" HeaderText="Description"></asp:BoundColumn>
                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgView" runat="server" CausesValidation="False" SkinID="ViewButton"
                                                        CommandName="View" CommandArgument='<%# DataBinder.Eval (Container.DataItem, "PageMapping") %>'
                                                        ToolTip="View" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Mode="NumericPages" />
                                    </asp:DataGrid>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
